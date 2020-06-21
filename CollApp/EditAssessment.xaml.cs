using CollApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAssessment : ContentPage
    {
        public static string AStart { get; set; }
        public static string AEnd { get; set; }

        public static DateTime strt { get; set; }
        public static DateTime nd { get; set; }

        public EditAssessment(Assessment SelectedAssessment)
        {
            InitializeComponent();

            Globals.SelectedAssessment = SelectedAssessment;

            //AssessmentTypePicker = SelectedAssessment.Type.ToString(); <<<picker code
            Start.Date = Convert.ToDateTime(SelectedAssessment.Start);
            End.Date = Convert.ToDateTime(SelectedAssessment.End);

        }

        private void EASaveButton_Clicked(object sender, EventArgs e)
        {
            if (strt < nd)
            {
                DisplayAlert("Alert", "Assessment start date must be prior to assessment end date", "OK");
                return;
            }

            Globals.SelectedAssessment.Type = AssessmentTypePicker.SelectedItem.ToString();
            Globals.SelectedAssessment.Start = AStart;
            Globals.SelectedAssessment.End = AEnd;

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Term>();
                int rows = con.Update(Globals.SelectedTerm);

                if (rows > 0)
                    DisplayAlert("Success", "Assessment Updated", "Ok");
                else
                    DisplayAlert("Failed", "Assessment Not Updated", "Ok");
            }

            Navigation.PushAsync(new MainPage());
        }

        private void Start_DateSelected(object sender, DateChangedEventArgs e)
        {
            AStart = e.NewDate.ToString();
            strt = e.NewDate;
        }

        private void End_DateSelected(object sender, DateChangedEventArgs e)
        {
            AEnd = e.NewDate.ToString();
            nd = e.NewDate;
        }
    }
}
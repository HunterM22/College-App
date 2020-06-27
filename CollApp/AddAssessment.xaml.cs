using CollApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAssessment : ContentPage
    {

        public static string AStart { get; set; }
        public static string AEnd { get; set; }

        public static DateTime strt { get; set; }
        public static DateTime nd { get; set; }

        public AddAssessment()
        {
            InitializeComponent();

            pickerAssessmentType.Items.Add("Objective Assessment");
            pickerAssessmentType.Items.Add("Performance Assessment");

        }

        private void AStartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            AStart = e.NewDate.ToString();
            strt = e.NewDate;
        }

        private void AEndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            AEnd = e.NewDate.ToString();
            nd = e.NewDate;
        }

        private void ASaveButton_Clicked(object sender, EventArgs e)
        {
            if (strt > nd)
            {
                DisplayAlert("Alert", "Assessment start date must be prior to assessment end date", "OK");
                return;
            }

            var db = new SQLiteConnection(Globals.completePath);

            int PCount = (db.Query<Assessment>("SELECT AssessmentID from Assessment WHERE Type = 'Performance Assessment' AND CourseID = '"+ Globals.SelectedCourse.CourseID +"' ;")).Count;
            int OCount = (db.Query<Assessment>("SELECT AssessmentID from Assessment WHERE Type = 'Objective Assessment' AND CourseID = '" + Globals.SelectedCourse.CourseID + "';")).Count;

            if (PCount < 1 )
            {
                if (OCount < 1)
                {
                    Assessment asmt = new Assessment()
                    {
                        Name = tbassessName.Text,
                        CourseID = Globals.SelectedCourse.CourseID,
                        Type = pickerAssessmentType.SelectedItem.ToString(),
                        Start = AStart,
                        End = AEnd
                    };

                    using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
                    {
                        con.CreateTable<Assessment>();
                        int rowsAdded = con.Insert(asmt);
                    }
                }
            }

            Navigation.PushAsync(new AssessmentView());

        }
    }
}
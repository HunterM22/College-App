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
    public partial class AssessmentView : ContentPage
    {
        public AssessmentView()
        {
            InitializeComponent();
            coursenamelabel.Text = Globals.SelectedCourse.CourseName;
        }

        private void ADDASSESSMENT_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAssessment());
        }

        private void EDITASSESSMENT_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditAssessment(Globals.SelectedAssessment));
        }

        private void DROPASSESSMENT_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                try
                {
                    con.CreateTable<Assessment>();
                    int rows = con.Delete(Globals.SelectedAssessment);

                    if (rows > 0)
                        DisplayAlert("Success", "Assessment Deleted", "Ok");
                    else
                        DisplayAlert("Failed", "Assessment Not Deleted", "Ok");
                }
                catch
                {
                    return;
                }
            }
            Navigation.PushAsync(new AssessmentView());

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Assessment>();
                var Assess = con.Table<Assessment>().ToList();

                AssessmentLV.ItemsSource = Assess;

            }

        }

        private void AssessmentLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Globals.SelectedAssessment = AssessmentLV.SelectedItem as Assessment;
        }
    }
}
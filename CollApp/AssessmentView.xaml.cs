using CollApp.Classes;
using Plugin.LocalNotifications;
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
        public static string AEnd { get; set; }

        public DateTime xyz { get; set; }

        public AssessmentView()
        {
            InitializeComponent();
            coursenamelabel.Text = Globals.SelectedCourse.CourseName;

            if (Globals.AssessmentAlert == 1)
            {
                AEnableNotifications.IsToggled = true;
            }

        }

        private void ADDASSESSMENT_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAssessment());
        }

        private void EDITASSESSMENT_Clicked(object sender, EventArgs e)
        {
            if (Globals.SelectedAssessment is null)
            {
                DisplayAlert("Alert", "Please select an assessment to edit", "Ok");
            }
            else
            {
                Navigation.PushAsync(new EditAssessment(Globals.SelectedAssessment));
            }
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
                try
                {
                    var Assesslist = con.Query<Assessment>("SELECT * FROM Assessment WHERE CourseID = '" + Globals.SelectedCourse.CourseID + "';");

                    var Asmt = (Assesslist.ToList());

                    AssessmentLV.ItemsSource = Asmt;

                }
                catch
                {
                    return;
                }
            }

        }

        private void AssessmentLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Globals.SelectedAssessment = AssessmentLV.SelectedItem as Assessment;
        }

        private void AEnableNotifications_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                Globals.AssessmentAlert = 1;

                using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
                {
                    var Assesslist = con.Query<Assessment>("SELECT * from Assessment;").ToList();

                    if (Assesslist.Count > 0)
                    {
                        foreach (Assessment i in Assesslist)
                        {
                            if (i.Start == DateTime.Today)
                            {
                                CrossLocalNotifications.Current.Show("Alert", "You have an assessment starting today. Good luck!", 101);
                            }
                        }
                        foreach (Assessment k in Assesslist)
                        {
                            if (k.End == DateTime.Today)
                            {
                                CrossLocalNotifications.Current.Show("Reminder", "You have an assessment due today.", 102);
                            }
                        }
                    if (Assesslist.Count < 1)
                        {
                            DisplayAlert("Success", "Alerts Enabled", "Ok");
                        }

                    }

                }
            }
            if (!e.Value)
            {
                return;
            }
        }

        private void ViewCourses_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CourseView());
        }


        //private void AEnableNotifications_Toggled_1(object sender, ToggledEventArgs e)
        //{

        //}
    }
}
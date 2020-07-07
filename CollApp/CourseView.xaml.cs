using CollApp.Classes;
using Plugin.LocalNotifications;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseView : ContentPage
    {
        public static string TStart { get; set; }
        public static string TEnd { get; set; }

        public CourseView()
        {
            InitializeComponent();


            if (Globals.CourseAlert == 1)
            {
                EnableNotificationsC.IsToggled = true;
            }
        }

        private void ADDCOURSE_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCourse());
        }

        private void EDITCOURSE_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditCourse(Globals.SelectedCourse));
        }

        private void DROPCOURSE_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                try
                {
                    con.CreateTable<Course>();
                    int rows = con.Delete(Globals.SelectedCourse);

                    if (rows > 0)
                        DisplayAlert("Success", "Course Deleted", "Ok");
                    else
                        DisplayAlert("Failed", "Course Not Deleted", "Ok");
                }
                catch
                {
                    return;
                }
            }
            Navigation.PushAsync(new CourseView());

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                try
                {
                    var Courselist = con.Query<Course>("SELECT * FROM Course WHERE TermID = '" + Globals.SelectedTerm.TermID + "';");

                    var Courses = (Courselist.ToList());

                    CourseLV.ItemsSource = Courses;

                    TStart = (Globals.SelectedTerm.Start).ToShortDateString();
                    TEnd = (Globals.SelectedTerm.End).ToShortDateString();
                    Termname.Text = Globals.SelectedTerm.TermName;
                    TermDates.Text = TStart + "  -  " + TEnd;


                }
                catch
                {
                    DisplayAlert("Alert", "Please select a term", "OK");
                    Navigation.PushAsync(new MainPage());
                }

            }
        }

        private void CourseLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Globals.SelectedCourse = CourseLV.SelectedItem as Course;
            var SelectedCourse = CourseLV.SelectedItem as Course;
        }

        private void ViewCourseDetails_Clicked(object sender, EventArgs e)
        {
            if (Globals.SelectedCourse is null)
            {
                DisplayAlert("Alert", "Please select a Course", "OK");
            }
            else 
            {
                Navigation.PushAsync(new CourseDetail(Globals.SelectedCourse));
            }
        }

        private void ViewAssessments_Clicked(object sender, EventArgs e)
        {

        }

        private void EnableNotificationsC_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                Globals.CourseAlert = 1;

                using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
                {
                    var Courselist = con.Query<Course>("SELECT * from Course;").ToList();

                    if (Courselist.Count > 0)
                    {
                        foreach (Course i in Courselist)
                        {
                            if (i.Start == DateTime.Today)
                            {
                                CrossLocalNotifications.Current.Show("Alert", "You have a course starting today. Good luck!", 104);
                            }
                        }
                        foreach (Course k in Courselist)
                        {
                            if (k.End == DateTime.Today)
                            {
                                CrossLocalNotifications.Current.Show("Reminder", "You have a course ending today.", 105);
                            }
                        }
                        if (Courselist.Count < 1)
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
    }
}
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
    public partial class CourseView : ContentPage
    {
        public CourseView()
        {
            InitializeComponent();
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
                con.CreateTable<Course>();
                con.Table<Course>().ToList();

                var Courses = con.Table<Course>().ToList();

                CourseLV.ItemsSource = Courses;

            }

        }

        private void CourseLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Globals.SelectedCourse = CourseLV.SelectedItem as Course;
            var SelectedCourse = CourseLV.SelectedItem as Course;
        }

        private void ViewCourseDetails_Clicked(object sender, EventArgs e)
        {

        }

        private void ViewAssessments_Clicked(object sender, EventArgs e)
        {

        }
    }
}
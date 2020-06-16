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
    public partial class EditCourse : ContentPage
    {
        public static string CourseStart { get; set; }
        public static string CourseEnd { get; set; }

        
        public EditCourse(Course SelectedCourse)
        {

            InitializeComponent();

            Globals.SelectedCourse = SelectedCourse;

                                 
            CName.Text = SelectedCourse.CourseName;
            CStatusPicker.SelectedItem = SelectedCourse;
            CStart.Date = Convert.ToDateTime(SelectedCourse.Start);
            CEnd.Date = Convert.ToDateTime(SelectedCourse.End);
            CNotes.Text = SelectedCourse.Note;
            CInst.SelectedItem = SelectedCourse.InstName;
            CInstPhone.SelectedItem = SelectedCourse.InstPhone;
            CInstEmail.SelectedItem = SelectedCourse.InstEmail;

        }

        private void CStart_DateSelected(object sender, DateChangedEventArgs e)
        {
            CourseStart = e.NewDate.ToString();
        }

        private void CEnd_DateSelected(object sender, DateChangedEventArgs e)
        {
            CourseEnd = e.NewDate.ToString();
        }

        private void CSaveButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Course>();
                int rows = con.Update(Globals.SelectedCourse);

                if (rows > 0)
                    DisplayAlert("Success", "Course Updated", "Ok");
                else
                    DisplayAlert("Failed", "Course Not Updated", "Ok");
            }

            Navigation.PushAsync(new CourseView());
        }
    }
}
using CollApp.Classes;
using Plugin.LocalNotifications;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetail : ContentPage
    {
        public static string CStart { get; set; }
        public static string CEnd { get; set; }
        public CourseDetail(Course SelectedCourse)
        {

            InitializeComponent();
            

            try
            {

                coursenamelabel.Text = SelectedCourse.CourseName;
                statuslabel.Text = SelectedCourse.Status;
                startdatelabel.Text = CStart;
                enddatelabel.Text = CEnd;
                noteseditor.Text = SelectedCourse.Note;
                instructornamelabel.Text = SelectedCourse.InstName;
                instructorphonelabel.Text = SelectedCourse.InstPhone;
                instructoremaillabel.Text = SelectedCourse.InstEmail;

                Globals.SelectedCourse = SelectedCourse;
                CStart = Convert.ToDateTime(Globals.SelectedCourse.Start).ToShortDateString();
                CEnd = Convert.ToDateTime(Globals.SelectedCourse.End).ToShortDateString();
            }
            catch
            {
                DisplayAlert("Alert", "Please select a course", "OK");

                Navigation.PushAsync(new CourseView());
            }

            Navigation.PushAsync(new CourseView());
        }


        private void ViewAssessments_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AssessmentView());

        }

        private void sharenotesbutton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(noteseditor.Text))
            {
                DisplayAlert("Alert", "No notes exist. Please edit the course to add a note.", "OK");

            }
            else
            {
                Share.RequestAsync(Globals.SelectedCourse.Note.ToString());
            }
        }

        private void EditCourse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditCourse(Globals.SelectedCourse));
        }

        //private async Task ImageButton_ClickedAsync(object sender, EventArgs e)
        //{

        //    await Share.RequestAsync(Globals.SelectedCourse.Note.ToString());
        //}


    }
}
using CollApp.Classes;
using Plugin.LocalNotifications;
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
        public CourseDetail(Course SelectedCourse)
        { 

            InitializeComponent();

            Globals.SelectedCourse = SelectedCourse;

            try
            {
                coursenamelabel.Text = SelectedCourse.CourseName;
                statuslabel.Text = SelectedCourse.Status;
                startdatelabel.Text = SelectedCourse.Start;
                enddatelabel.Text = SelectedCourse.End;
                noteseditor.Text = SelectedCourse.Note;
                instructornamelabel.Text = SelectedCourse.InstName;
                instructorphonelabel.Text = SelectedCourse.InstPhone;
                instructoremaillabel.Text = SelectedCourse.InstEmail;
            }
            catch 
            {
                Navigation.PushAsync(new CourseView());
                DisplayAlert("Alert", "Please select a course", "OK");
            }

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
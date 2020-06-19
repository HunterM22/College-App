using CollApp.Classes;
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
    public partial class CourseDetail : ContentPage
    {
        public CourseDetail(Course SelectedCourse)
        {
            InitializeComponent();

            Globals.SelectedCourse = SelectedCourse;

            coursenamelabel.Text = SelectedCourse.CourseName;
            statuslabel.Text = SelectedCourse.Status;
            startdatelabel.Text = SelectedCourse.Start;
            enddatelabel.Text = SelectedCourse.End;
            noteseditor.Text = SelectedCourse.Note;
            instructornamelabel.Text = SelectedCourse.InstName;
            instructorphonelabel.Text = SelectedCourse.InstPhone;
            instructoremaillabel.Text = SelectedCourse.InstEmail;
        }

        private void ViewAssessments_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AssessmentView());

        }
    }
}
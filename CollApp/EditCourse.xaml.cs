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
        public static DateTime CourseStart { get; set; }
        public static DateTime CourseEnd { get; set; }

               
        public EditCourse(Course SelectedCourse)
        {

            InitializeComponent();

           
        
            CName.Text = Globals.SelectedCourse.CourseName;
            CStart.Date = Convert.ToDateTime(Globals.SelectedCourse.Start);
            CEnd.Date = Convert.ToDateTime(Globals.SelectedCourse.End);
            CNotes.Text = Globals.SelectedCourse.Note;
            CInst.Text = Globals.SelectedCourse.InstName;
            CInstPhone.Text = Globals.SelectedCourse.InstPhone;
            CInstEmail.Text = Globals.SelectedCourse.InstEmail;
            

            CStatusPicker.Items.Add("Open");
            CStatusPicker.Items.Add("In Progress");
            CStatusPicker.Items.Add("Completed");
            CStatusPicker.Title = Globals.SelectedCourse.Status.ToString();

        }

        private void CStart_DateSelected(object sender, DateChangedEventArgs e)
        {
            Globals.SelectedCourse.Start = e.NewDate;
        }

        private void CEnd_DateSelected(object sender, DateChangedEventArgs e)
        {
            Globals.SelectedCourse.End = e.NewDate;
        }

        private void CSaveButton_Clicked(object sender, EventArgs e)
        {
            if (CStart.Date > CEnd.Date)
            {
                DisplayAlert("Alert", "Course start date must be prior to course end date", "OK");
                return;
            }


            if (String.IsNullOrEmpty(CInst.Text))
            {
                DisplayAlert("Alert", "Please enter a value for Instructor Name", "OK");
                return;
            }

            if (String.IsNullOrEmpty(CInstEmail.Text))
            {
                DisplayAlert("Alert", "Please enter a value for Instructor Email", "OK");
                return;
            }

            if (String.IsNullOrEmpty(CInstPhone.Text))
            {
                DisplayAlert("Alert", "Please enter a value for Instructor Phone", "OK");
                return;
            }

            if (String.IsNullOrEmpty(CName.Text))
            {
                DisplayAlert("Alert", "Please enter a value for Course Name", "OK");
                return;
            }

            

            Globals.SelectedCourse.CourseName = CName.Text;
            Globals.SelectedCourse.Start = Globals.SelectedCourse.Start;
            Globals.SelectedCourse.End = Globals.SelectedCourse.End;
            Globals.SelectedCourse.Note = CNotes.Text;
            Globals.SelectedCourse.InstName =  CInst.Text;
            Globals.SelectedCourse.InstPhone = CInstPhone.Text;
            Globals.SelectedCourse.InstEmail =CInstEmail.Text;


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

        private void CStatusPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seltype = (CStatusPicker.Items[CStatusPicker.SelectedIndex]).ToString();
            Globals.SelectedCourse.Status = seltype;

        }
    }
}
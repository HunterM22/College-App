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
    public partial class AddCourse : ContentPage
    {
        public static string CStart { get; set; }
        public static string CEnd { get; set; }

        public static DateTime strt { get; set; }
        public static DateTime nd { get; set; }

        public AddCourse()
        {
            InitializeComponent();

            StatusPicker.Items.Add("Open");
            StatusPicker.Items.Add("In Progress");
            StatusPicker.Items.Add("Complete");

            CStart = DateTime.Now.ToString();
            CEnd = DateTime.Now.ToString();

            strt = DateTime.Now;
            nd = DateTime.Now;          
                       

        }

        private void CStartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            CStart = e.NewDate.ToString();
            strt = e.NewDate;
        }

        private void CEndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            CEnd = e.NewDate.ToString();
            nd = e.NewDate;
        }

        private void CSaveButton_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbInst.Text))
            {
                DisplayAlert("Alert", "Please enter a value for Instructor Name", "OK");
                return;
            }

            if (String.IsNullOrEmpty(tbInstEmail.Text))
            {
                DisplayAlert("Alert", "Please enter a value for Instructor Email", "OK");
                return;
            }

            if (String.IsNullOrEmpty(tbInstPhone.Text))
            {
                DisplayAlert("Alert", "Please enter a value for Instructor Phone", "OK");
                return;
            }

            if (String.IsNullOrEmpty(tbCourseName.Text))
            {
                DisplayAlert("Alert", "Please enter a value for Course Name", "OK");
                return;
            }

            if (String.IsNullOrEmpty(StatusPicker.SelectedItem.ToString()))
            {
                DisplayAlert("Alert", "Please enter a value for Course Name", "OK");
                return;
            }

            if (strt > nd)
            {
                DisplayAlert("Alert", "Course start date must be prior to course end date", "OK");
                return;
            }

            Course crs = new Course()
            {
                CourseName = tbCourseName.Text,
                Start = CStart,
                End = CEnd,
                Status = StatusPicker.SelectedItem.ToString(),  //Get pickers into string format? May need to create variable here
                Note = tbNotes.Text,
                InstName = tbInst.Text, //picker
                InstEmail = tbInstEmail.Text, //picker
                InstPhone = tbInstPhone.Text,
                TermID = Globals.SelectedTerm.TermID,
            };

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Course>();
                int rowsAdded = con.Insert(crs);
            }

            Navigation.PushAsync(new CourseView());
        }
    }
}
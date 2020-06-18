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

        public AddCourse()
        {
            InitializeComponent();

            StatusPicker.Items.Add("Open");
            StatusPicker.Items.Add("In Progress");
            StatusPicker.Items.Add("Complete");

            CStart = DateTime.Now.ToString();
            CEnd = DateTime.Now.ToString();
                       

        }

        private void CStartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            CStart = e.NewDate.ToString();
        }

        private void CEndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            CEnd = e.NewDate.ToString();
        }

        private void CSaveButton_Clicked(object sender, EventArgs e)
        {
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
                TermID = 1
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
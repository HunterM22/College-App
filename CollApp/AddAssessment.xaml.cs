using CollApp.Classes;
using Java.Sql;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CollApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAssessment : ContentPage
    {

        public static DateTime AStart { get; set; }
        public static DateTime AEnd { get; set; }

        //public static DateTime strt { get; set; }
        //public static DateTime nd { get; set; }

        public static string seltype { get; set; }

        public AddAssessment()
        {
            InitializeComponent();

            pickerAssessmentType.Items.Add("Objective Assessment");
            pickerAssessmentType.Items.Add("Performance Assessment");
            pickerAssessmentType.Title = "Pick Assessment Type";
            pickerAssessmentType.SelectedItem = null;

            AStart = DateTime.Today;
            AEnd = DateTime.Today;


        }

        private void AStartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            AStart = e.NewDate;
        }

        private void AEndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            AEnd = e.NewDate;
        }

        private void ASaveButton_Clicked(object sender, EventArgs e)
        {
            if (AStart > AEnd)
            {
                DisplayAlert("Alert", "Assessment start date must be prior to assessment end date", "OK");
                return;
            }

            if (pickerAssessmentType is null)
            {
                DisplayAlert("Alert", "Please choose an assessment type", "OK");
                return;
            }

            var db = new SQLiteConnection(Globals.completePath);

            int PCount = (db.Query<Assessment>("SELECT AssessmentID from Assessment WHERE Type = 'Performance Assessment' AND CourseID = '" + Globals.SelectedCourse.CourseID + "' ;")).Count;
            int OCount = (db.Query<Assessment>("SELECT AssessmentID from Assessment WHERE Type = 'Objective Assessment' AND CourseID = '" + Globals.SelectedCourse.CourseID + "';")).Count;


            if (PCount > 0)
            {
                if (seltype is "Performance Assessment")
                {
                    DisplayAlert("Alert", "Performance Assessment already exists for this course (Limit 1).", "OK");
                    return;
                }

            }
            if (OCount > 0)
            {
                if (seltype is "Objective Assessment")
                {
                    DisplayAlert("Alert", "Objective Assessment already exists for this course (Limit 1).", "OK");
                    return;
                }

            }
            Assessment asmt = new Assessment()
            {
                Name = tbassessName.Text,
                CourseID = Globals.SelectedCourse.CourseID,
                Type = pickerAssessmentType.SelectedItem.ToString(),
                Start = AStart,
                End = AEnd
            };

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Assessment>();
                int rowsAdded = con.Insert(asmt);
            }
           
            Navigation.PushAsync(new AssessmentView());

        }

        private void pickerAssessmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            seltype = (pickerAssessmentType.Items[pickerAssessmentType.SelectedIndex]).ToString();

        }
    }
}
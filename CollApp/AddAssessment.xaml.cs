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
    public partial class AddAssessment : ContentPage
    {

        public static string AStart { get; set; }
        public static string AEnd { get; set; }

        public AddAssessment()
        {
            InitializeComponent();
        }

        private void AStartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            AStart = e.NewDate.ToString();
        }

        private void AEndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            AEnd = e.NewDate.ToString();
        }

        private void ASaveButton_Clicked(object sender, EventArgs e)
        {
            Assessment asmt = new Assessment()
            {
                CourseID = pickerCourseID.ToString(),
                Type = pickerAssessmentType.ToString(),
                Start = AStart,
                End = AEnd
            };

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Term>();
                int rowsAdded = con.Insert(asmt);
            }

            Navigation.PushAsync(new AssessmentView());

        }
    }
}
﻿using CollApp.Classes;
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
    public partial class EditAssessment : ContentPage
    {
        public static DateTime AStart { get; set; }
        public static DateTime AEnd { get; set; }

      
        public static string seltype { get; set; }

        public EditAssessment(Assessment SelectedAssessment)
        {
            InitializeComponent();

            AssessmentTypePicker.Title = Globals.SelectedAssessment.Type.ToString();

            AName.Text = Globals.SelectedAssessment.Name;
            Start.Date = Globals.SelectedAssessment.Start;
            End.Date = Globals.SelectedAssessment.End;

        }

        private void EASaveButton_Clicked(object sender, EventArgs e)
        {
            if (Globals.SelectedAssessment.Start > Globals.SelectedAssessment.End)
            {
                DisplayAlert("Alert", "Assessment start date must be prior to assessment end date", "OK");
                return;
            }

            Globals.SelectedAssessment.Name = AName.Text;
            Globals.SelectedAssessment.Type = Globals.SelectedAssessment.Type;
            Globals.SelectedAssessment.Start = Globals.SelectedAssessment.Start;
            Globals.SelectedAssessment.End = Globals.SelectedAssessment.End;

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Assessment>();
                int rows = con.Update(Globals.SelectedAssessment);

                if (rows > 0)
                    DisplayAlert("Success", "Assessment Updated", "Ok");
                else
                    DisplayAlert("Failed", "Assessment Not Updated", "Ok");
            }

            Navigation.PushAsync(new AssessmentView());
        }

        private void Start_DateSelected(object sender, DateChangedEventArgs e)
        {
            Globals.SelectedAssessment.Start = e.NewDate;
            
        }

        private void End_DateSelected(object sender, DateChangedEventArgs e)
        {
            Globals.SelectedAssessment.End = e.NewDate;
            
        }

        public void AssessmentTypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(Globals.completePath);

            int PCount = (db.Query<Assessment>("SELECT AssessmentID from Assessment WHERE Type = 'Performance Assessment' AND CourseID = '" + Globals.SelectedCourse.CourseID + "' ;")).Count;
            int OCount = (db.Query<Assessment>("SELECT AssessmentID from Assessment WHERE Type = 'Objective Assessment' AND CourseID = '" + Globals.SelectedCourse.CourseID + "';")).Count;


            if (PCount > 0)
            {
                if (seltype is "Performance Assessment")
                {
                    DisplayAlert("Alert", "Performance Assessment already exists for this course (Limit 1).", "OK");
                    AssessmentTypePicker.Title = Globals.SelectedAssessment.Type.ToString();
                    return;
                }

            }
            if (OCount > 0)
            {
                if (seltype is "Objective Assessment")
                {
                    DisplayAlert("Alert", "Objective Assessment already exists for this course (Limit 1).", "OK");
                    AssessmentTypePicker.Title = Globals.SelectedAssessment.Type.ToString();
                    return;
                }

            }

            seltype = (AssessmentTypePicker.Items[AssessmentTypePicker.SelectedIndex]).ToString();

            Globals.SelectedAssessment.Type = seltype;

        }
    }
}
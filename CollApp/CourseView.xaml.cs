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
    public partial class CourseView : ContentPage
    {
        public CourseView()
        {
            InitializeComponent();
        }

        private void ADDCOURSE_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCourse());
        }

        private void EDITCOURSE_Clicked(object sender, EventArgs e)
        {

        }

        private void DROPCOURSE_Clicked(object sender, EventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Course>();
                var Courses = con.Table<Course>().ToList();

                CourseLV.ItemsSource = Courses;

            }

        }
    }
}
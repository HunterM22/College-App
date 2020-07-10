using Android.Content.Res;
using CollApp.Classes;
using Plugin.LocalNotifications;
using SQLite;
using System;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollApp
{
    public partial class App : Application
    {
        public static string FilePath;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string filePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            FilePath = filePath;
        }

        protected override void OnStart()
        {//Notifications for Course start/end and Assessnment start/end

           // using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
           // {
                //con.CreateTable<Course>();
                //var CourseStart = ((con.Query<Course>("SELECT * FROM Course WHERE TermID = '" + Globals.SelectedTerm.TermID + "';")).ToList()).Count;

                ////var Courses = (Courselist.ToList());

                //if (CourseStart > 0)
                //    CrossLocalNotifications.Current.Show("Alert", "You have a new class starting today", 101, DateTime.Now.AddSeconds(5));

           // }

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                try
                {
                    int TCount = (con.Query<Term>("SELECT * from Term;")).Count;
                }
                catch       
                {
                    Globals.AddTermData();
                }
            }

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                try
                { 
                    int CCount = (con.Query<Course>("SELECT * from Course;")).Count;
                }
                catch
                {
                    Globals.AddCourseData();
                }
            }

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                try
                {
                    int ACount = (con.Query<Assessment>("SELECT * from Assessment;")).Count;
                }
                catch
                {
                    Globals.AddAssessmentData();
                }
            }



        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

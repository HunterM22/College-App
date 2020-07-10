using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CollApp.Classes
{
    public static class Globals
    {
        public static DateTime StartDate { get; set; }
        public static DateTime EndDate { get; set; }

        public static Term SelectedTerm { get; set; }

        public static Course SelectedCourse { get; set; }

        public static Assessment SelectedAssessment { get; set; }

        public static string fileName = "college.db3";
        public static  string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public static string completePath = Path.Combine(folderPath, fileName);

        public static int AssessmentAlert = 0;

        public static int CourseAlert = 0;

        public static void AddTermData()
        {
            Term t1 = new Term()
            {
                TermName = "Summer 2020",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Term>();
                int rowsAdded = con.Insert(t1);
            };
        }

        public static void AddCourseData()
        {
            Course c1 = new Course()
            {
                CourseID = 1,
                TermID = 1,
                CourseName = "Database Management",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
                Note = "testnote",
                InstName = "Melissa Nicole",
                InstEmail = "professor@wgu.edu",
                InstPhone = "216-867-5309",
                Status = "Complete",
            };

            Course c2 = new Course()
            {
                CourseID = 2,
                TermID = 1,
                CourseName = "UX Design",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
                Note = "testnote",
                InstName = "Melissa Nicole",
                InstEmail = "professor@wgu.edu",
                InstPhone = "216-867-5309",
                Status = "Complete",
            };

            Course c3 = new Course()
            {
                CourseID = 3,
                TermID = 1,
                CourseName = "Software I",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
                Note = "testnote",
                InstName = "Melissa Nicole",
                InstEmail = "professor@wgu.edu",
                InstPhone = "216-867-5309",
                Status = "Complete",
            };

            Course c4 = new Course()
            {
                CourseID = 4,
                TermID = 1,
                CourseName = "Software II",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
                Note = "testnote",
                InstName = "Melissa Nicole",
                InstEmail = "professor@wgu.edu",
                InstPhone = "216-867-5309",
                Status = "Complete",
            };

            Course c5 = new Course()
            {
                CourseID = 5,
                TermID = 1,
                CourseName = "Mobile Development",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
                Note = "testnote",
                InstName = "Melissa Nicole",
                InstEmail = "professor@wgu.edu",
                InstPhone = "216-867-5309",
                Status = "In Progress",
            };

            Course c6 = new Course()
            {
                CourseID = 6,
                TermID = 1,
                CourseName = "Software Capstone",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
                Note = "testnote",
                InstName = "Melissa Nicole",
                InstEmail = "professor@wgu.edu",
                InstPhone = "216-867-5309",
                Status = "Complete",
            };

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Course>();
                con.Insert(c1);
                con.Insert(c2);
                con.Insert(c3);
                con.Insert(c4);
                con.Insert(c5);
                con.Insert(c6);
            };
        }

       public static void AddAssessmentData()
       { 
            Assessment a1 = new Assessment
            {
                AssessmentID = 1,
                Name = "Exam",
                CourseID = 1,
                Type = "Objective Assessment",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            Assessment a2 = new Assessment
            {
                AssessmentID = 2,
                Name = "Paper",
                CourseID = 1,
                Type = "Performance Assessment",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            Assessment a3 = new Assessment
            {
                AssessmentID = 3,
                Name = "Exam",
                CourseID = 2,
                Type = "Objective Assessment",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            Assessment a4 = new Assessment
            {
                AssessmentID = 4,
                Name = "Paper",
                CourseID = 2,
                Type = "Performance Assessment",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            Assessment a5 = new Assessment
            {
                AssessmentID = 5,
                Name = "Exam",
                CourseID = 3,
                Type = "Objective Assessment",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            Assessment a6 = new Assessment
            {
                AssessmentID = 6,
                Name = "Paper",
                CourseID = 3,
                Type = "Performance Assessment",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            Assessment a7 = new Assessment
            {
                AssessmentID = 7,
                Name = "Exam",
                CourseID = 4,
                Type = "Objective Assessment",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            Assessment a8 = new Assessment
            {
                AssessmentID = 8,
                Name = "Paper",
                CourseID = 4,
                Type = "Performance Assessment",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            Assessment a9 = new Assessment
            {
                AssessmentID = 9,
                Name = "Exam",
                CourseID = 5,
                Type = "Objective Assessment",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            Assessment a10 = new Assessment
            {
                AssessmentID = 10,
                Name = "Paper",
                CourseID = 5,
                Type = "Performance Assessment",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            Assessment a11 = new Assessment
            {
                AssessmentID = 11,
                Name = "Exam",
                CourseID = 6,
                Type = "Objective Assessment",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            Assessment a12 = new Assessment
            {
                AssessmentID = 12,
                Name = "Paper",
                CourseID = 6,
                Type = "Performance Assessment",
                Start = Convert.ToDateTime("06/01/2020"),
                End = Convert.ToDateTime("08/07/2020"),
            };

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Assessment>();
                con.Insert(a1);
                con.Insert(a2);
                con.Insert(a3);
                con.Insert(a4);
                con.Insert(a5);
                con.Insert(a6);
                con.Insert(a7);
                con.Insert(a8);
                con.Insert(a9);
                con.Insert(a10);
                con.Insert(a11);
                con.Insert(a12);
            }
       }        
    }
}

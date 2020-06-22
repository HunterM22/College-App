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


    }
}

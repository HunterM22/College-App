using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollApp.Classes
{
    public class Course
    {
        [PrimaryKey, AutoIncrement] public int CourseID { get; set; }

        public int TermID { get; set; }
        public string CourseName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Note { get; set; }
        public string InstName { get; set; }
        public string InstPhone { get; set; }
        public string InstEmail { get; set; }
        public string Status { get; set; }


        public Course()
        {

        }

    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollApp.Classes
{
    public class Assessment
    {
        [PrimaryKey, AutoIncrement] public int AssessmentID { get; set; }

        public string Name { get; set; }
        public int CourseID { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Assessment()
        {

        }
    }
}

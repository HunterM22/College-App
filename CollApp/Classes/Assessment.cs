using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollApp.Classes
{
    class Assessment
    {
        [PrimaryKey, AutoIncrement] public int AssessmentID { get; set; }
        public string CourseID { get; set; }
        public string Type { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

        public Assessment()
        {

        }
    }
}

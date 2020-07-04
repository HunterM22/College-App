using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollApp.Classes
{
    public class Term
    {    
        [PrimaryKey, AutoIncrement] public int TermID { get; set; }
        public string TermName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Term()
        {
            
        }

    }
}

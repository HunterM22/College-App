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
        public string Start { get; set; }
        public string End { get; set; }

        public Term()
        {
            
        }

    }
}

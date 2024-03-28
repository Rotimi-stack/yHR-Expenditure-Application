using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace yHR.Common.Data
{
    public class Expenditures
    {
        public int ExpenditureID { get; set; }
        public string? Description { get; set; }
        public Decimal Amount { get; set; }
        public int Month { get; set; } = DateTime.Now.Date.Month;
        public int Year { get; set; } = DateTime.Now.Date.Year;
        public int Day { get; set; } = DateTime.Now.Date.Day;
        public DateTime DateCreated { get; set; }
        public string? ExpType { get; set; }
        public string? ExpTypeSub { get; set; }
        public string? ExpTypeDescrip { get;}
        public string? ExpSubTypeDescrip { get;}
        
       
    }
    
   
}

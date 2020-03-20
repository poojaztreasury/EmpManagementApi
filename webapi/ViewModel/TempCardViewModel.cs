using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.ViewModel
{
    public class TempCardViewModel
    {
        
        public int tempno { get; set; }

        
        public int empid { get; set; }

       
        public int tempcardno { get; set; }

       
        public bool IsDeleted { get; set; }

       
        public bool IsActive { get; set; }

        
        public string addedby { get; set; }

        
       // public DateTime addedon { get; set; }

        
        public string modifiedby { get; set; }

        
       //public DateTime modifiedon { get; set; }

    }
}

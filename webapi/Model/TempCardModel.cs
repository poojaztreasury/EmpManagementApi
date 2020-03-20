using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace webapi.Model
{
    public class TempCardModel
    {
        [DataMember(Name = "tempno")]
        public int tempno { get; set; }

        [DataMember(Name = "empid")]
        public int empid { get; set; }

        [DataMember(Name = "tempcardno")]
        public int tempcardno { get; set; }

        [DataMember(Name = "IsDeleted")]
        public bool IsDeleted { get; set; }

        [DataMember(Name = "IsActive")]
        public bool IsActive { get; set; }

        [DataMember(Name = "addedby")]
        public string addedby { get; set; }

        [DataMember(Name = "addedon")]
        public DateTime? addedon { get; set; }

        [DataMember(Name = "modifiedby")]
        public string modifiedby { get; set; }

        [DataMember(Name = "modifiedon")]
        public DateTime? modifiedon { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.Serialization;

namespace webapi.Model
{
    public class EmpModel
    {
        [DataMember(Name = "empid")]
        public int empid { get; set; }

        [DataMember(Name = "empname")]
        public string empname { get; set; }

        [DataMember(Name = "empemail")]
        public string empemail { get; set; }

        [DataMember(Name = "emphomeadd")]
        public string emphomeadd { get; set; }

        [DataMember(Name = "empdep")]
        public string empdep { get; set; }

        [DataMember(Name = "empphone")]
        public int? empphone { get; set; }

        [DataMember(Name = "emprepmanager")]
        public string emprepmanager { get; set; }

        

        [DataMember(Name = "empofficeadd")]
        public string empofficeadd { get; set; }

        [DataMember(Name = "IsDeleted")]
        public string IsDeleted { get; set; }

        [DataMember(Name = "IsActive")]
        public string IsActive { get; set; }

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

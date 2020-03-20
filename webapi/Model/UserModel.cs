using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace webapi.Model
{
    public class UserModel
    {
        [DataMember(Name = "username")]
        public string username { get; set; }

        [DataMember(Name = "Password")]
        public string Password { get; set; }
    }
}

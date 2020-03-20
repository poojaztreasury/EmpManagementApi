using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Model;
using webapi.Utility;
using webapi.ViewModel;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DataAccessLayer dataobj = new DataAccessLayer();

        [HttpPost]
        [Route("login")]
        public string LoginCheck(UserViewModel usm)
        {
            var usmodel = new UserModel()
            {
                username = usm.username,
                Password = usm.Password

            };

           Int32 k= dataobj.logincheck(usmodel);
            if(k==-1)
            {
                return "wrong username";
            }
            else if(k==-2)
            {
                return "wrong password";

            }
            else
            {
                return "logged in";
            }

        }

        [HttpPost]
        [Route("adduser")]
        public string AddUser(UserViewModel usm)
        {
            var usmodel = new UserModel()
            {
                username = usm.username,
                Password = usm.Password

            };

           Int32 k = dataobj.AddUser(usmodel);
            if(k==1)
            {
                return "user added";

            }
            else
            {
                return "not added";
            }

        }
    }
}
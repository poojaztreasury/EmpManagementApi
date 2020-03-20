using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Model;
using webapi.ViewModel;


namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        DataAccessLayer dataobj = new DataAccessLayer();
        IEnumerable<EmpModel> es;
        public EmpController()
        {
        }


        [HttpGet]
        [Route("showEmp")]
        public IEnumerable<EmpModel> ShowEmp()
        {
            es = dataobj.GetAllEmp();
            return es.ToList();
        }
        [HttpPost]
        [Route("createmp")]
        public Int32 CreateEmp(EmpViewModel emp)
        {
            var empModel = new EmpModel()
            {
                empname = emp.Name,

                addedby = "1",
                empemail = emp.Email,
                emphomeadd = emp.HomeAdd,
                empdep = emp.EmpDep,
                empphone = emp.EmpPhone,
                emprepmanager = emp.RepManager,
                empofficeadd = emp.OfficeAdd,
                IsDeleted = "false",
                IsActive = "true",
                modifiedby = "1",
                addedon = DateTime.Now,
                modifiedon = DateTime.Now



            };
            dataobj.AddEmp(empModel);
            return 1;
        }
        [HttpGet]
        [Route("findemp/{id}")]
        public IEnumerable<EmpModel> FindEmp(int id)
        {

            EmpModel es = dataobj.FindEmp(id);
            List<EmpModel> lstemp = new List<EmpModel>();
            lstemp.Add(es);
            return lstemp;
        }
        [HttpPut]
        [Route("updatemp/{id}")]
        public Int32 UpdatEmp(EmpEditModel emp, int id)
        {

           // List<EmpModel> uplist = new List<EmpModel>();
            //IEnumerable<EmpModel> uplist=FindEmp(id);
            var empmodel = new EmpModel()
                {
                    empname = emp.Name,
                    empid = id,

                    empemail = emp.Email,
                    emphomeadd = emp.HomeAdd,
                    empdep = emp.EmpDep,
                    empphone = emp.EmpPhone,
                    emprepmanager = emp.RepManager,
                    empofficeadd = emp.OfficeAdd,
                    IsDeleted = "false",
                    IsActive = "true",
                    modifiedby = "1",

                    modifiedon = DateTime.Now


                };
                dataobj.UpdateEmp(empmodel, empmodel.empid);

            
            return 1;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public Int32 DelEmp(int id)
        {
            dataobj.DelEmp(id);
            return 1;
        }

    }
}
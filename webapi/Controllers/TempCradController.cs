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
    public class TempCradController : ControllerBase
    {
        DataAccessLayer dataobj = new DataAccessLayer();

        [HttpGet]
        [Route("show")]
        public IEnumerable<TempCardModel> ShowCardDetails()
        {
            IEnumerable<TempCardModel> tm = dataobj.GetTempCardDetails();
            return tm.ToList();

        }
        [HttpPost]
        [Route("addcard")]
        public string AddCard(TempCardViewModel tmp)
        {
            var tmpmodel = new TempCardModel()
            {
                empid = tmp.empid,
                tempcardno = tmp.tempcardno,
                IsDeleted = tmp.IsDeleted,
                IsActive = tmp.IsActive,
                addedby = "pooja",
                addedon = DateTime.Now,
                modifiedby = "pooja",
                modifiedon = DateTime.Now





            };
            int k = dataobj.AddCardEntry(tmpmodel);
            if (k == 1)
            {
                return "record added";
            }
            else
            {
                return "record not added";
            }
        }
        [HttpPut]
        [Route("updatecard/{id}")]
        public string UpdateTempCard(TempCardViewModel tmp, int id)
        {
            var tmpmodel = new TempCardModel()
            {
                tempno=id,
                empid = tmp.empid,
                tempcardno = tmp.tempcardno,
                IsDeleted = tmp.IsDeleted,
                IsActive = tmp.IsActive,
               // addedby = "pooja",
               // addedon = DateTime.Now,
                modifiedby = tmp.modifiedby,
                modifiedon = DateTime.Now





            };
            int k = dataobj.UpdateTempCard(tmpmodel, tmpmodel.tempno);
            if (k == 1)
            {
                return "record added";
            }
            else
            {
                return "record not added";
            }
        }  
        [HttpDelete]
        [Route("delcard/{id}")]
        public string DelTempCard(int id)
        {
           int k= dataobj.DelTempCard(id);
            if(k==1)
            {
                return "record deleted";
            }
            else
            {
                return "not deleted";
            }

        }
            
    }
}
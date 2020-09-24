using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Service;

namespace ElasticSearchWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticController : ControllerBase
    {
        private readonly IUserBL _IUserBL;

        public ElasticController(IUserBL _IUserBL)
        {
            this._IUserBL = _IUserBL;
        }


        [HttpGet]
        public ActionResult Search()
        {
            return Ok("search");
        }

        [HttpGet]
        [Route("{UserRole}")]
        public ActionResult DataSearch(string UserRole)
        {
            try
            {
                var Data = _IUserBL.DataSearch(UserRole);
                return Ok(new { success = true, message = "data successfully fetched", data = Data  });
            }
            catch(Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}

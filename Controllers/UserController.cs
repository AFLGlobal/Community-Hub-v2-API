using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Community_Hub_v2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public ActionResult Get()
        {
            Models.Db.CommunityHubDbContext _ctx = new Models.Db.CommunityHubDbContext();
            return Ok(_ctx.Employee);
        }

    }
}
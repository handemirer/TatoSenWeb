using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TatoSen.Helpers;

namespace TatoSen.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TatosenApiController : ControllerBase
    {
        // [AuthorizeApi]
        [AllowAnonymous]
        [ApiAuthorize]
        [HttpGet]
        [Route("getsentence")]
        public IActionResult GetSentence()
        {
            var response = "sentence";
            return Ok(response);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CoursesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> TesteUm()
        {
            return new string[] {"Isso", "Funcionou"};
        }
    }
}
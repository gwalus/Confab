using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confab.Modules.Speakers.Api.Controllers
{
    [Route(SpeakersModule.BasePath)]
    internal class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Speakers API";
    }
}
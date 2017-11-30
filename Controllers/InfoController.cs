using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace DockerTest03.Controllers
{
    [Produces("application/json")]
    [Route("api/Info")]
    public class InfoController : Controller
    {

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var dic = new Dictionary<string, string>();

            dic.Add("MachineName", Environment.MachineName);
            dic.Add("OSVersion", Environment.OSVersion.VersionString);
            dic.Add("ProcessorCount", Environment.ProcessorCount.ToString());
            dic.Add("UserName", Environment.UserName);
            dic.Add("UserDomainName", Environment.UserDomainName);
            dic.Add("CurrentDirectory", System.IO.Directory.GetCurrentDirectory().ToString());

            var httpConnectionFeature = HttpContext.Features.Get<IHttpConnectionFeature>();
            var localIpAddress = httpConnectionFeature?.LocalIpAddress;
            dic.Add("IP Address", localIpAddress.ToString());

            return Json(dic);
        }
    }
}
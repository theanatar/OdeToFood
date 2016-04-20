using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    [Route("[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "61684186161";
        }

        [Route("[action]")]
        public string Country()
        {
            return "Greece";
        }
    }
}

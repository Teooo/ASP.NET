using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DistCalcRESTService.Controllers
{

    
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            return "a+b";
        }

        // GET api/values/5
        [Route("dist")]
        public double distance(int x1, int y1, int x2,int y2)
        {
            Point startPoint = new Point()
            {
                X = x1,
                Y = y1
            };
            Point endPoint = new Point()
            {
                X = x2,
                Y = y2
            };

            return Point.distance(startPoint,endPoint);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

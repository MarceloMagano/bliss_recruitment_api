using System;
using System.Collections.Generic;
using System.Web.Http;

namespace bliss_recruitment_api.Controllers
{
    public class HealthController : ApiController
    {
        // GET: api/Health
        public IHttpActionResult GetHealth()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if (randomNumber % 2 == 0)
            {
                return Ok("OK");
            }
            else
            {
                return InternalServerError();
            }

        }
    }
}

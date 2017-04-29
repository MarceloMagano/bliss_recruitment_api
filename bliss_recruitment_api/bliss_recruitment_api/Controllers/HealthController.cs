using bliss_recruitment_api.Models.DTO;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Description;


namespace bliss_recruitment_api.Controllers
{
    public class HealthController : ApiController
    {
        /// <summary>
        /// Get Health Status
        /// </summary>
        /// <returns>Status Code 200 with message { "status" : "OK" } or code 503 with message { "status" = "Service Unavailable. Please try again later." }</returns>
        [ResponseType(typeof(QuestionDTO))]
        // GET: api/Health
        public IHttpActionResult GetHealth()
        {
            //for just for test purpose use Random number and check for the number parity to send diferent status code
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if (randomNumber % 2 == 0)
            {
                return Ok(new HealthDTO() { status = "OK" });
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    Content = new ObjectContent<HealthDTO>(new HealthDTO() { status = "Service Unavailable. Please try again later." }, new JsonMediaTypeFormatter())
                });

            }

        }
    }
}

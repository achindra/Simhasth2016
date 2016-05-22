using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ResourceManager.WebAPI.Models;

namespace ResourceManager.WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class ResourceController : ApiController
    {
        private static readonly ResourceHelper ResourceHelper = new ResourceHelper();

        [HttpPost]
        [Route("resource")]
        public Resource UpsertResource([FromBody]Resource resource)
        {
            if (resource == null)
            {
                throw new ArgumentException("resource");
            }
            try
            {
                return ResourceHelper.UpsertResource(resource, Constants.DbConnectionString);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.InnerException.StackTrace),
                    ReasonPhrase = ex.InnerException.Message
                });
            }
        }

        [HttpGet]
        [Route("resource")]
        public List<Resource> GetResources(float latitude, float longitude, float radius)
        {
            try
            {
                return ResourceHelper.GetNearbyResources(latitude, longitude, radius, Constants.DbConnectionString);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.InnerException.StackTrace),
                    ReasonPhrase = ex.InnerException.Message
                });
            }
        }
    }
}

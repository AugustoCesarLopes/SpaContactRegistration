using SpaContactRegistration.Domain.Contracts.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SpaContactRegistration.Api.Attributes;
using SpaContactRegistration.Api.Models.Account;

namespace SpaContactRegistration.Api.Controllers
{
    [RoutePrefix("api/contact")]
    //[apicontroller]
    public class ContactController : ApiController
    {
        private IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        [DeflateCompression]
        //[CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)] //Install-Package Strathweb.CacheOutput.WebApi2
        public Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _service.GetByRange(0, 25);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        /*
        [HttpGet]
        [Route("{id}")]
        [DeflateCompression]
        //[CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)] //Install-Package Strathweb.CacheOutput.WebApi2
        public Task<HttpResponseMessage> Get(int  id)//Guid id
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                //var result = _service.GetById(id);
                var result = _service.GetByRange(0, 25);
                //var resp = result[0];
                //var result = _service.GetByEmail(email);
                response = Request.CreateResponse(HttpStatusCode.OK, result[id]);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        */
        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> Post(RegisterContactModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.Register(model.Name, model.Email, model.Telefone, model.Password, model.ConfirmPassword);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Name, email = model.Email, phone = model.Telefone });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
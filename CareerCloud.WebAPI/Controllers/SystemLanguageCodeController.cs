using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/system/v1")]
    public class SystemLanguageCodeController : ApiController
    {
        private SystemLanguageCodeLogic _logicObj = null;

        public SystemLanguageCodeController()
        {
            _logicObj = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
        }

        [HttpGet]
        [Route("language/{SystemLanguageCode}")]
        [ResponseType(typeof(SystemLanguageCodePoco))]
        public IHttpActionResult GetSystemLanguageCode(string SystemLanguageCode)
        {
            try
            {
                SystemLanguageCodePoco item = _logicObj.Get(SystemLanguageCode);
                if (item != null)
                {
                    return this.Ok(item);
                }
                else
                {
                    return this.NotFound();
                }
            }
            catch (Exception e)
            {
                HttpResponseMessage response =
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                throw new HttpResponseException(response);
            }
        }

        [HttpGet]
        [Route("language/")]
        [ResponseType(typeof(IEnumerable<SystemLanguageCodePoco>))]
        public IHttpActionResult GetAllSystemLanguageCode()
        {
            try
            {
                IEnumerable<SystemLanguageCodePoco> itemList = _logicObj.GetAll();
                if (itemList != null)
                {
                    return this.Ok(itemList);
                }
                else
                {
                    return this.NotFound();
                }

            }
            catch (Exception e)
            {
                HttpResponseMessage response =
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                throw new HttpResponseException(response);
            }
        }

        [HttpGet]
        [Route("language/id/")]
        [ResponseType(typeof(IEnumerable<string>))]
        public IHttpActionResult GetSystemLanguageCode()
        {
            try
            {
                IEnumerable<string> itemIDList = _logicObj.GetAll().Select(c=>c.LanguageID);
                if (itemIDList != null)
                {
                    return this.Ok(itemIDList);
                }
                else
                {
                    return this.NotFound();
                }

            }
            catch (Exception e)
            {
                HttpResponseMessage response =
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                throw new HttpResponseException(response);
            }
        }

        [HttpPost]
        [Route("language/")]
        public IHttpActionResult PostSystemLanguageCode([FromBody]SystemLanguageCodePoco[] pocos)
        {
            try
            {
                _logicObj.Add(pocos);
                return this.Ok();
            }
            catch (AggregateException e)
            {
                IEnumerable<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>();
                HttpResponseMessage response =
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, exceptions.FirstOrDefault());
                throw new HttpResponseException(response);
            }
            catch (Exception e)
            {
                HttpResponseMessage response =
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                throw new HttpResponseException(response);

            }
        }

        [HttpPut]
        [Route("language/")]
        public IHttpActionResult PutSystemLanguageCode([FromBody]SystemLanguageCodePoco[] pocos)
        {
            try
            {
                _logicObj.Update(pocos);
                return this.Ok();
            }
            catch (AggregateException e)
            {
                IEnumerable<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>();
                HttpResponseMessage response =
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, exceptions.FirstOrDefault());
                throw new HttpResponseException(response);

            }
            catch (Exception e)
            {
                HttpResponseMessage response =
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                throw new HttpResponseException(response);

            }
        }

        [HttpDelete]
        [Route("system/")]
        public IHttpActionResult DeleteSystemLanguageCode([FromBody]SystemLanguageCodePoco[] pocos)
        {
            try
            {
                _logicObj.Delete(pocos);
                return this.Ok();
            }
            catch (AggregateException e)
            {
                IEnumerable<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>();
                HttpResponseMessage response =
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, exceptions.FirstOrDefault());
                throw new HttpResponseException(response);

            }
            catch (Exception e)
            {
                HttpResponseMessage response =
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                throw new HttpResponseException(response);

            }
        }
    }
}
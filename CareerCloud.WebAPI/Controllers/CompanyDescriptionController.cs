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
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyDescriptionController : ApiController
    {
        private CompanyDescriptionLogic _logicObj = null;

        public CompanyDescriptionController()
        {
            _logicObj = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
        }

        [HttpGet]
        [Route("description/{CompanyDescriptionId}")]
        [ResponseType(typeof(CompanyDescriptionPoco))]
        public IHttpActionResult GetCompanyDescription(Guid CompanyDescriptionId)
        {
            try
            {
                CompanyDescriptionPoco item = _logicObj.Get(CompanyDescriptionId);
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
        [Route("description/")]
        [ResponseType(typeof(IEnumerable<CompanyDescriptionPoco>))]
        public IHttpActionResult GetAllCompanyDescription()
        {
            try
            {
                IEnumerable<CompanyDescriptionPoco> itemList = _logicObj.GetAll();
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
        [Route("description/id/")]
        [ResponseType(typeof(IEnumerable<Guid>))]
        public IHttpActionResult GetCompanyDescription()
        {
            try
            {
                IEnumerable<Guid> itemIDList = _logicObj.GetAll().Select(c=>c.Id);
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
        [Route("description/")]
        public IHttpActionResult PostCompanyDescription([FromBody]CompanyDescriptionPoco[] pocos)
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
        [Route("description/")]
        public IHttpActionResult PutCompanyDescription([FromBody]CompanyDescriptionPoco[] pocos)
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
        [Route("company/")]
        public IHttpActionResult DeleteCompanyDescription([FromBody]CompanyDescriptionPoco[] pocos)
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
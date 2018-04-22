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
    public class CompanyJobSkillController : ApiController
    {
        private CompanyJobSkillLogic _logicObj = null;

        public CompanyJobSkillController()
        {
            _logicObj = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
        }

        [HttpGet]
        [Route("jobSkill/{CompanyJobSkillId}")]
        [ResponseType(typeof(CompanyJobSkillPoco))]
        public IHttpActionResult GetCompanyJobSkill(Guid CompanyJobSkillId)
        {
            try
            {
                CompanyJobSkillPoco item = _logicObj.Get(CompanyJobSkillId);
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
        [Route("jobSkill/")]
        [ResponseType(typeof(IEnumerable<CompanyJobSkillPoco>))]
        public IHttpActionResult GetAllCompanyJobSkill()
        {
            try
            {
                IEnumerable<CompanyJobSkillPoco> itemList = _logicObj.GetAll();
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
        [Route("jobSkill/id/")]
        [ResponseType(typeof(IEnumerable<Guid>))]
        public IHttpActionResult GetCompanyJobSkill()
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
        [Route("jobSkill/")]
        public IHttpActionResult PostCompanyJobSkill([FromBody]CompanyJobSkillPoco[] pocos)
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
        [Route("jobSkill/")]
        public IHttpActionResult PutCompanyJobSkill([FromBody]CompanyJobSkillPoco[] pocos)
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
        public IHttpActionResult DeleteCompanyJobSkill([FromBody]CompanyJobSkillPoco[] pocos)
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
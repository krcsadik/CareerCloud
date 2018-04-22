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
    [RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantSkillController : ApiController
    {
        private ApplicantSkillLogic _logicObj = null;

        public ApplicantSkillController()
        {
            _logicObj = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
        }

        [HttpGet]
        [Route("skill/{ApplicantSkillId}")]
        [ResponseType(typeof(ApplicantSkillPoco))]
        public IHttpActionResult GetApplicantSkill(Guid ApplicantSkillId)
        {
            try
            {
                ApplicantSkillPoco item = _logicObj.Get(ApplicantSkillId);
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
        [Route("skill/")]
        [ResponseType(typeof(IEnumerable<ApplicantSkillPoco>))]
        public IHttpActionResult GetAllApplicantSkill()
        {
            try
            {
                IEnumerable<ApplicantSkillPoco> itemList = _logicObj.GetAll();
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
        [Route("skill/id/")]
        [ResponseType(typeof(IEnumerable<Guid>))]
        public IHttpActionResult GetApplicantSkill()
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
        [Route("skill/")]
        public IHttpActionResult PostApplicantSkill([FromBody]ApplicantSkillPoco[] pocos)
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
        [Route("skill/")]
        public IHttpActionResult PutApplicantSkill([FromBody]ApplicantSkillPoco[] pocos)
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
        [Route("Skill/")]
        public IHttpActionResult DeleteApplicantSkill([FromBody]ApplicantSkillPoco[] pocos)
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
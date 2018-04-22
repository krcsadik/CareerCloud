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
    public class ApplicantProfileController : ApiController
    {
        private ApplicantProfileLogic _logicObj = null;

        public ApplicantProfileController()
        {
            _logicObj = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
        }

        [HttpGet]
        [Route("profile/{ApplicantProfileId}")]
        [ResponseType(typeof(ApplicantProfilePoco))]
        public IHttpActionResult GetApplicantProfile(Guid ApplicantProfileId)
        {
            try
            {
                ApplicantProfilePoco item = _logicObj.Get(ApplicantProfileId);
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
        [Route("profile/")]
        [ResponseType(typeof(IEnumerable<ApplicantProfilePoco>))]
        public IHttpActionResult GetAllApplicantProfile()
        {
            try
            {
                IEnumerable<ApplicantProfilePoco> itemList = _logicObj.GetAll();
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
        [Route("profile/id/")]
        [ResponseType(typeof(IEnumerable<Guid>))]
        public IHttpActionResult GetApplicantProfile()
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
        [Route("profile/")]
        public IHttpActionResult PostApplicantProfile([FromBody]ApplicantProfilePoco[] pocos)
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
        [Route("profile/")]
        public IHttpActionResult PutApplicantProfile([FromBody]ApplicantProfilePoco[] pocos)
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
        [Route("Profile/")]
        public IHttpActionResult DeleteApplicantProfile([FromBody]ApplicantProfilePoco[] pocos)
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
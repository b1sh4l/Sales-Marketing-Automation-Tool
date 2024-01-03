using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Sales_Marketing_Automation_Tool.Controllers
{
    public class LeadController : ApiController
    {
        [HttpGet]
        [Route("api/lead")]
        public HttpResponseMessage GetAllLeads()
        {
            var leads = LeadService.GetAll();
            if (leads != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, leads);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No leads found");
        }

        [HttpGet]
        [Route("api/lead/{id}")]
        public HttpResponseMessage GetLead(int id)
        {
            var lead = LeadService.Get(id);
            if (lead != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lead);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, $"Lead with Id {id} not found");
        }

        [HttpPost]
        [Route("api/lead")]
        public HttpResponseMessage CreateLead([FromBody] LeadDTO lead)
        {
            var createdLead = LeadService.Create(lead);
            if (createdLead != null)
            {
                return Request.CreateResponse(HttpStatusCode.Created, createdLead);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to create lead");
        }

        [HttpPut]
        [Route("api/lead/{id}")]
        public HttpResponseMessage UpdateLead(int id, [FromBody] LeadDTO lead)
        {
            lead.Id = id;
            var updatedLead = LeadService.Update(lead);
            if (updatedLead != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, updatedLead);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, $"Lead with Id {id} not found");
        }

        [HttpDelete]
        [Route("api/lead/{id}")]
        public HttpResponseMessage DeleteLead(int id)
        {
            var deleted = LeadService.Delete(id);
            if (deleted)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Lead deleted successfully");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, $"Lead with Id {id} not found");
        }

        //[HttpGet]
        //[Route("api/lead/status/{status}")]
        //public HttpResponseMessage GetLeadsByStatus(string status)
        //{
        //    if (Enum.TryParse<LeadStatusEnum>(status, out var leadStatus))
        //    {
        //        var leads = LeadService.GetLeadsByStatus(leadStatus);
        //        return Request.CreateResponse(HttpStatusCode.OK, leads);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid lead status");
        //}


        [HttpGet]
        [Route("api/lead/name/{leadName}")]
        public HttpResponseMessage GetLeadsByName(string leadName)
        {
            var leads = LeadService.GetLeadsByName(leadName);
            return Request.CreateResponse(HttpStatusCode.OK, leads);
        }

        [HttpGet]
        [Route("api/lead/all/{page}/{pageSize}")]
        public HttpResponseMessage GetAllLeadsPaged(int page, int pageSize)
        {
            var leads = LeadService.GetAll(page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, leads);
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        [HttpGet]
        [Route("api/lead/email")]
        public HttpResponseMessage GetLeadByEmail([FromUri] string email)
        {
            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid email format");
            }

            var lead = LeadService.GetLeadByEmail(email);

            if (lead != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lead);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, $"Lead with email {email} not found");
        }


        [HttpGet]
        [Route("api/lead/phone")]
        public HttpResponseMessage GetLeadByPhoneNumber(string phoneNumber)
        {
            var lead = LeadService.GetLeadByPhoneNumber(phoneNumber);
            if (lead != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lead);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, $"Lead with phone number {phoneNumber} not found");
        }

        [HttpGet]
        [Route("api/lead/date")]
        public HttpResponseMessage GetLeadsByDateRange(string startDate, string endDate)
        {
            if (DateTime.TryParse(startDate, out var start) && DateTime.TryParse(endDate, out var end))
            {
                var leads = LeadService.GetLeadsByDateRange(start, end);
                return Request.CreateResponse(HttpStatusCode.OK, leads);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid date format");
        }

        [HttpGet]
        [Route("api/lead/totalcount")]
        public HttpResponseMessage GetTotalLeadCount()
        {
            var totalCount = LeadService.GetTotalLeadCount();
            return Request.CreateResponse(HttpStatusCode.OK, totalCount);
        }

        [HttpGet]
        [Route("api/lead/contacteduser")]
        public HttpResponseMessage GetLeadsByContactedUser(string contactedBy)
        {
            var leads = LeadService.GetLeadsByContactedUser(contactedBy);
            return Request.CreateResponse(HttpStatusCode.OK, leads);
        }
    }
}

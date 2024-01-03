using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        //    if (Enum.TryParse(status, out LeadDTO leadStatus))
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
    }
}

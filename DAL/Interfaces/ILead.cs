using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILead : IRepo<Lead, int, Lead>
    {
        List<Lead> GetLeadsByStatus(LeadStatus status);
        List<Lead> GetLeadsByName(string leadName);
        List<Lead> GetAll(int page, int pageSize);

        Lead GetLeadByEmail(string email);
        Lead GetLeadByPhoneNumber(string phoneNumber);
        List<Lead> GetLeadsByDateRange(DateTime startDate, DateTime endDate);
        int GetTotalLeadCount();
        List<Lead> GetLeadsByContactedUser(string contactedBy);
    }
}

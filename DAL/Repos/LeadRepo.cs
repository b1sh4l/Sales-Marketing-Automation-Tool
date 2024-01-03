using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LeadRepo : Repo, IRepo<Lead, int, Lead>, ILead
    {
        public Lead Create(Lead obj)
        {
            db.Leads.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var LeadToDelete = db.Leads.Find(id);
            if (LeadToDelete != null)
            {
                db.Leads.Remove(LeadToDelete);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public Lead GetAll()
        {
            return db.Leads.FirstOrDefault();
        }

        public Lead Read(int id)
        {
            return db.Leads.Find(id);
        }

        public object Read()
        {
            return db.Leads.ToList();
        }

        public Lead Update(Lead obj)
        {
            var existingLead = db.Leads.Find(obj.Id);
            Console.WriteLine($"existingLead: {existingLead}");

            if (existingLead != null)
            {
                db.Entry(existingLead).CurrentValues.SetValues(obj);

                if (db.SaveChanges() > 0)
                {
                    return existingLead;
                }
            }
            return null;
        }

        public List<Lead> GetLeadsByStatus(LeadStatus status)
        {
            return db.Leads.Where(l => l.LeadStatus == status).ToList();
        }

        public List<Lead> GetLeadsByName(string leadName)
        {
            return db.Leads.Where(l => l.LeadName == leadName).ToList();
        }
        public List<Lead> GetAll(int page, int pageSize)
        {
            //return db.Leads.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return db.Leads.OrderBy(l => l.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

    }
}

using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LeadService
    {

        public static List<LeadDTO> GetAll()
        {
            var data = DataAccessFactory.LeadData().Read();
            if (data == null)
            {
                return null;
            }
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Lead, LeadDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<LeadDTO>>(data);
            return mapped;

        }

        public static LeadDTO Get(int id)
        {
            var data = DataAccessFactory.LeadData().Read(id);
            if(data ==  null)
            {
                return null;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Lead, LeadDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<LeadDTO>(data);
            return mapped;
        }

        public static LeadDTO Create(LeadDTO lead)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeadDTO, Lead>();  // Map from LeadDTO to Lead
                cfg.CreateMap<Lead, LeadDTO>();  // Map from Lead to LeadDTO
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<Lead>(lead);
            var data = DataAccessFactory.LeadData().Create(mapped);

            if (data == null)
            {
                return null;
            }

            var mapped2 = mapper.Map<LeadDTO>(data);
            return mapped2;
        }


        public static LeadDTO Update(LeadDTO lead)
        {
            var existingLead = DataAccessFactory.LeadData().Read(lead.Id);
            if (existingLead != null)
            {
                existingLead.LeadName = lead.LeadName;
                existingLead.Email = lead.Email;
                existingLead.PhoneNumber = lead.PhoneNumber;
                existingLead.Message = lead.Message;
                existingLead.LeadStatus = lead.LeadStatus;

                var updatedLead = DataAccessFactory.LeadData().Update(existingLead);
                if (updatedLead != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Lead, LeadDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var mapped = mapper.Map<LeadDTO>(updatedLead);
                    return mapped;
                }
            }
            return null;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.LeadData().Delete(id);
        }

        private static readonly IMapper Mapper;

        static LeadService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Lead, LeadDTO>();
                cfg.CreateMap<LeadDTO, Lead>();
            });

            Mapper = config.CreateMapper();
        }

        public static List<LeadDTO> GetLeadsByStatus(LeadStatus status)
        {
            var data = DataAccessFactory.LeadData2().GetLeadsByStatus(status);
            return Mapper.Map<List<LeadDTO>>(data);
        }

        public static List<LeadDTO> GetLeadsByName(string leadName)
        {
            var data = DataAccessFactory.LeadData2().GetLeadsByName(leadName);
            return Mapper.Map<List<LeadDTO>>(data);
        }

        public static List<LeadDTO> GetAll(int page, int pageSize)
        {
            var data = DataAccessFactory.LeadData2().GetAll(page, pageSize);
            return Mapper.Map<List<LeadDTO>>(data);
        }

        public static LeadDTO GetLeadByEmail(string email)
        {
            var data = DataAccessFactory.LeadData2().GetLeadByEmail(email);
            return Mapper.Map<LeadDTO>(data);
        }

        public static LeadDTO GetLeadByPhoneNumber(string phoneNumber)
        {
            var data = DataAccessFactory.LeadData2().GetLeadByPhoneNumber(phoneNumber);
            return Mapper.Map<LeadDTO>(data);
        }

        public static List<LeadDTO> GetLeadsByDateRange(DateTime startDate, DateTime endDate)
        {
            var data = DataAccessFactory.LeadData2().GetLeadsByDateRange(startDate, endDate);
            return Mapper.Map<List<LeadDTO>>(data);
        }

        public static int GetTotalLeadCount()
        {
            return DataAccessFactory.LeadData2().GetTotalLeadCount();
        }

        public static List<LeadDTO> GetLeadsByContactedUser(string contactedBy)
        {
            var data = DataAccessFactory.LeadData2().GetLeadsByContactedUser(contactedBy);
            return Mapper.Map<List<LeadDTO>>(data);
        }

    }
}

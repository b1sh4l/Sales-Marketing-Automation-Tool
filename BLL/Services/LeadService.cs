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
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<LeadDTO, LeadDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Lead>(lead);
            var data = DataAccessFactory.LeadData().Create(mapped);
            if (data == null)
            {
                return null;
            }
            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Lead, LeadDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<LeadDTO>(data);
            return mapped2;
        }

    }
}

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
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read();
            if (data == null)
            {
                return null;
            }
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;
        }

        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserData().Read(id);

            if (data == null)
            {
                return null;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;
        }   

        public static UserDTO Create(UserDTO user)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<User>(user);
            var data = DataAccessFactory.UserData().Create(mapped);
            if (data == null)
            {
                return null;
            }
            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<UserDTO>(data);
            return mapped2;
        }

        public static UserDTO Update(int id, UserDTO user)
        {
            
            var existingUser = DataAccessFactory.UserData().Read(id);

            
            if (existingUser != null)
            {
                
                existingUser.Email = user.Email;
                existingUser.Password = user.Password; 
                existingUser.Name = user.Name;
                existingUser.Address = user.Address;
                existingUser.Role = user.Role;

                
                var updatedUser = DataAccessFactory.UserData().Update(existingUser);

                if (updatedUser != null)
                {
                   
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<User, UserDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var mapped = mapper.Map<UserDTO>(updatedUser);
                    return mapped;
                }
            }

            
            return null;
        }


        public static bool Delete(int id)
        {
            return DataAccessFactory.UserData().Delete(id);
        }

        public static UserDTO SignIn(string email, string password)
        {
            var userRepo = DataAccessFactory.UserData2();
            var data = userRepo.GetByEmailAndPassword(email, password);

            if (data == null)
            {
                return null;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;
        }

        
    }
}

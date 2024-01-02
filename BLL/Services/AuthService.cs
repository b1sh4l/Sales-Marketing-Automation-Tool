using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string email, string password)
        {
            var data = DataAccessFactory.AuthData().Authenticate(email, password);
            if (data)
            {
                var token = new Token();
                token.UserEmail = email;
                token.CreatedAt = DateTime.Now;
                token.ExpiresAt = DateTime.Now.AddHours(1);
                token.TKey = Guid.NewGuid().ToString();
                var ret = DataAccessFactory.TokenData().Create(token);

                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }
                else
                {
                    return null;
                }

            }
            return null;
        }

        public static bool IsTokenValid(string tKey)
        {
            var tokens = DataAccessFactory.TokenData().Read(tKey);
            var exTk = tokens?.FirstOrDefault();

            if (exTk != null && exTk.ExpiresAt <= DateTime.Now)
            {
                return true;
            }
            return false;
        }


        public static bool SignOut(string tKey)
        {
            var tokens = DataAccessFactory.TokenData().Read(tKey);

            var exTk = tokens?.FirstOrDefault();

            if (exTk != null)
            {
                exTk.ExpiresAt = DateTime.Now;

                if (DataAccessFactory.TokenData().Update(exTk) != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

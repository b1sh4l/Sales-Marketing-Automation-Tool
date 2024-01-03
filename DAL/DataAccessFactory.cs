using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, User> UserData()
        {
            return new UserRepo();
        }

        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }

        public static IToken<Token, int, Token> TokenData()
        {
            return new TokenRepo();
        }

        public static IUser<User> UserData2()
        {
            return new UserRepo();
        }

        public static IRepo<Payment, int, Payment> PaymentData()
        {
            return new PaymentRepo();
        }

        public static IPayment PaymentData3()
        {
            return new PaymentRepo();
        }

        public static IPayment PaymentData2 { get; } = new PaymentRepo();

    }
}

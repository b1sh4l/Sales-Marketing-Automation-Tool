using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUser<User>
    {
        User GetByEmailAndPassword(string email, string password);
    }
}

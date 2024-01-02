using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<Type, ID, RET>
    {
        RET Create(Type obj);
        List<Type> Read(string tKey);
        RET Read(ID id);
        RET Update(Type obj);
        bool Delete(ID id);
        RET GetAll();
        RET GetByEmailAndPassword(string email, string password);
        object Update(List<Token> exTk);
        object Read();
    }
}

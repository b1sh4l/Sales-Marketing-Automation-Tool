using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<Type, ID, RET>
    {
        RET Create(Type obj);

        RET Read(ID id);
        RET Update(Type obj);
        bool Delete(ID id);
        RET GetAll();
        object Read();
    }
}

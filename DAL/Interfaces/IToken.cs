using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IToken<TYPE, ID, RET>
    {
        RET Create(TYPE obj);
        RET Read(ID id);
        List<RET> Read(string tKey);
        RET Update(TYPE obj);
        object Update(List<Token> exTk);

    }
}

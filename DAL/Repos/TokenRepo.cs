using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo: Repo, IToken<Token, int, Token>
    {

        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

       

        public Token Read(int id)
        {
            return db.Tokens.FirstOrDefault(Token => Token.TKey.Equals(id));
        }

        public List<Token> Read(string tKey)
        {
            return db.Tokens.Where(token => token.TKey.Equals(tKey)).ToList();
        }

 
        public Token Update(Token obj)
        {
            var tokenToUpdate = Read(int.Parse(obj.TKey));
            db.Entry(tokenToUpdate).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return tokenToUpdate;
            }   
            return null;
        }

        object IToken<Token, int, Token>.Update(List<Token> exTk)
        {
            throw new NotImplementedException();
        }

    }
 
}

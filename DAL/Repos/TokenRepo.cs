using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo: Repo, IRepo<Token, int, Token>
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

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Token GetAll()
        {
            throw new NotImplementedException();
        }

        public Token GetByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Token> Read()
        {
            throw new NotImplementedException();
        }

        public Token Read(int id)
        {
            return db.Tokens.FirstOrDefault(Token => Token.TKey.Equals(id));
        }

        public List<Token> Read(string tKey)
        {
            return db.Tokens.Where(token => token.TKey.Equals(tKey)).ToList();
        }

        public Token Update(int id, Token entity)
        {
            throw new NotImplementedException();
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

        public object Update(List<Token> exTk)
        {
            throw new NotImplementedException();
        }

        object IRepo<Token, int, Token>.Read()
        {
            throw new NotImplementedException();
        }
    }
 
}

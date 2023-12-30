using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, User>
    {
        public User Create(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var userToDelete = db.Users.Find(id);

            if (userToDelete != null)
            {
                db.Users.Remove(userToDelete);
                return db.SaveChanges() > 0;
            }

            return false;
        }

        public User GetAll()
        {
            return db.Users.FirstOrDefault();
        }

        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(int id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
            db.Entry(obj).State = EntityState.Modified;

            if (db.SaveChanges() > 0)
            {
                return obj;
            }

            return null;
        }

    }
}

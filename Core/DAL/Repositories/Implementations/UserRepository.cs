using Core.DAL.Repositories.Interfaces;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.DAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private OnlineShopEntities context;

        public UserRepository(OnlineShopEntities context)
        {
            this.context = context;
        }

        public User AddUser(User user)
        {
            return context.Users.Add(user);
        }

        public bool DeleteUser(int userID)
        {
            User user = GetUser(userID);
            if (user != null)
            {
                context.Users.Remove(user);
                return true;
            }

            return false;
        }

        public User GetUser(int userID)
        {
            return context.Users.Find(userID);
        }

        public int GetUserIDByEmail(string email)
        {
            List<User> userList = context.Users.ToList();
            User user = userList.Find(u => { return u.Email == email; });
            int userID = user == null ? -1 : user.ID;
            return userID;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public bool Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool UpdateUser(User user)
        {
            if (GetUser(user.ID) != null)
            {
                context.Entry(user).State = EntityState.Modified;
                return true;
            }

            return false;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
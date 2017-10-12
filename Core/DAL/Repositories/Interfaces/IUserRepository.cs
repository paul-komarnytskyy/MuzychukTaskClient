using Core.Model;
using System;
using System.Collections.Generic;

namespace Core.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();

        User GetUser(int userID);

        User AddUser(User user);

        bool DeleteUser(int userID);

        bool UpdateUser(User user);

        bool Save();

        int GetUserIDByEmail(string username);
    }
}

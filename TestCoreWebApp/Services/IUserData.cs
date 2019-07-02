using Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserData
    {
        User GetByUsername(string username);
        User Add(User newUser);
        int Commit();


    }
}

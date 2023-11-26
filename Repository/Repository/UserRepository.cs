using Domain.Models;
using Repository.Data;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private static int _id = 1;

        public bool Login(User user)
        {
            foreach (var item in AppDbContext<User>.Datas)
            {
                if(item.Email == user.Email && item.Password == user.Password)
                {
                    return true;
                }
            }

            return false;
        }

        public void Register(User user)
        {
            AppDbContext<User>.Datas.Add(user); 
        }
    }
}

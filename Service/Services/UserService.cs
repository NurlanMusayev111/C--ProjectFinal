using Domain.Models;
using Repository.Repository;
using Repository.Repository.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService()
        {
            _userRepo = new UserRepository();
        }

        public bool Login(User user)
        {
            return _userRepo.Login(user);
        }

        public void Register(User user)
        {
            _userRepo.Register(user);
        }
    }
}

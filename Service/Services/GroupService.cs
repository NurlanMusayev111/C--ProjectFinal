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
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;

        public GroupService()
        {
            _groupRepo = new GroupRepository();
        }

        public Group CheckByName(string name)
        {
           return  _groupRepo.CheckByName(name);
        }

        public void Create(Group group)
        {
            _groupRepo.Create(group);
        }

        public void Delete(Group group)
        {
            _groupRepo.Delete(group);
        }

        public void Edit(int id, Group group)
        {
            _groupRepo.Sort(id);
        }

        public List<Group> GetAll()
        {
            return _groupRepo.GetAll();
        }

        public Group GetById(int id)
        {
            return _groupRepo.GetById(id);
        }

        public List<Group> Search(string name)
        {
            return _groupRepo.Search(name);
        }

        public List<Group> Sort(int optionCap)
        {
            return _groupRepo.Sort(optionCap);
        }
    }
}

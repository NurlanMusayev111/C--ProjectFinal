using Domain.Models;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        List<Group> Sort(int optionCap);
        List<Group> Search(string name);

        Group CheckByName(string name);

        void Edit(int id, Group group);
    }
}

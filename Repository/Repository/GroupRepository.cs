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
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public Group CheckByName(string name)
        {
            return AppDbContext<Group>.Datas.FirstOrDefault(m => m.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public void Edit(int id, Group group)
        {
            Group existsgroup = AppDbContext<Group>.Datas.FirstOrDefault(m => m.Id == id);

            if (!string.IsNullOrWhiteSpace(group.Name))
            {
                existsgroup.Name = group.Name;  
            }

            if(group.Capacity != null)
            {
                existsgroup.Capacity = group.Capacity;
            }
        } 

        public List<Group> Search(string name)
        {
            return AppDbContext<Group>.Datas.Where(m =>m.Name.Contains(name)).ToList();
        }

        public List<Group> Sort(int optionCap)
        {
            switch (optionCap)
            {
                case 1:
                    return AppDbContext<Group>.Datas.OrderBy(m => m.Capacity).ToList();
                case 2:
                    return AppDbContext<Group>.Datas.OrderByDescending(m => m.Capacity).ToList();
            }

            return default;
        }


    }
}

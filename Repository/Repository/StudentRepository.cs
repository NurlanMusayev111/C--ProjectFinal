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
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public List<Student> Search(string name)
        {
            return AppDbContext<Student>.Datas.Where(m => m.Fullname.Contains(name)).ToList();
        }

        public List<Student> Sort(int optionAge)
        {
            switch (optionAge)
            {
                case 1:
                    AppDbContext<Student>.Datas.OrderBy(m => m.Age).ToList();
                    break;
                case 2:
                    AppDbContext<Student>.Datas.OrderByDescending(m => m.Age).ToList();
                    break;
            }

            return default;
        }
    }
}

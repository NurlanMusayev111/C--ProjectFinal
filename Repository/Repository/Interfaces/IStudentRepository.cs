using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        List<Student> Sort(int optionAge);
        List<Student> Search(string name);
    }
}

using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        void Create(Student student);
        void Delete(Student student);
        void Edit(int id ,Student student);
        Student GetById(int id);
        List<Student> GetAll();
        List<Student> Sort(int optionAge);
        List<Student> Search(string name);
    }
}

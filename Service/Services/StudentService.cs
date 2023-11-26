using Domain.Models;
using Repository.Data;
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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;

        public StudentService()
        {
            _studentRepo = new StudentRepository();
        }

        public void Create(Student student)
        {
            _studentRepo.Create(student);   
        }

        public void Delete(Student student)
        {
            _studentRepo.Delete(student);   
        }

        public void Edit(int id, Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            return AppDbContext<Student>.Datas.ToList();
        }

        public Student GetById(int id)
        {
            return _studentRepo.GetById(id);    
        }

        public List<Student> Search(string name)
        {
            return _studentRepo.Search(name);
        }

        public List<Student> Sort(int optionAge)
        {
            return _studentRepo.Sort(optionAge);
        }
    }
}

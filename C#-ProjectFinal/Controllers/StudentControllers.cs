using Domain.Models;
using Service.Helpers.Extension;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ProjectFinal.Controllers
{
    public class StudentControllers
    {
        private readonly IStudentService _studentService;

        public StudentControllers()
        {
            _studentService = new StudentService();
        }

        
        public void Create()
        {

            GroupService groupService = new();

            // Student fullname
            StuFullName: Console.WriteLine("Add fullname:");
            string stuName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(stuName))
            {
                ConsoleColor.Red.WriteConsole("Please fill input!!");
                goto StuFullName;
            }

            StuAddress: Console.WriteLine("Enter your address:");
            string stuAdress = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(stuAdress))
            {
                ConsoleColor.Red.WriteConsole("Please fill input!!");
                goto StuAddress;
            }


            //Student phone

            StuPhone: Console.WriteLine("Enter your phone:");
            string stuPhone = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(stuPhone))
            {
                ConsoleColor.Red.WriteConsole("Please fill input!!");
                goto StuPhone;
            }

            // Stuident age
            Age: Console.WriteLine("Enter age :");
            string ageStr = Console.ReadLine();

            int age;
            bool isTrueAge = int.TryParse(ageStr, out age);

            if(!isTrueAge)
            {
                ConsoleColor.Red.WriteConsole("Age format is wrong , please enter again");
                goto Age;
            }
           


            // Include groupId

            GroupId: Console.WriteLine("Include group ID");
            string groupIdStr = Console.ReadLine();

            int groupId;
            bool isTrueGroupId = int.TryParse(groupIdStr, out groupId); 

            if(!isTrueGroupId)
            {
                ConsoleColor.Red.WriteConsole("Wrong ID format,please try again");
                goto GroupId;
            }
            else
            {
                var res = groupService.GetById(groupId);

                if(res is null)
                {
                    ConsoleColor.Red.WriteConsole("This group ID not exists");
                   
                }

                _studentService.Create(new Student { Fullname = stuName, Age = age, Address = stuAdress, group = res });
                
            };

        }

        public void Delete()
        {
            Id: Console.WriteLine("Add delete ID student");
            string idStr = Console.ReadLine();

            int id;
            bool isTrueId = int.TryParse(idStr, out id);

            if (string.IsNullOrEmpty(idStr))
            {
                ConsoleColor.Red.WriteConsole("Please fill id input");
            }

            if(isTrueId)
            {
                var res = _studentService.GetById(id);

                if(res is null)
                {
                    ConsoleColor.Red.WriteConsole("Id not exists,please try again");
                    goto Id;
                }
                else
                {
                    _studentService.Delete(res);    
                }
            }

            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong");
            }
        }

        public void GetAll()
        {
            var result = _studentService.GetAll();

            foreach( var student in result )
            {
                Console.WriteLine($"{student.Id} - {student.Fullname} - {student.Age}");
            }
        }


        public void Search()
        {
            Console.WriteLine("Search student name:");
            Search: string search = Console.ReadLine();

            if (string.IsNullOrEmpty(search))
            {
                ConsoleColor.Red.WriteConsole("Please fill search input!!");
                goto Search;
            }

            var res = _studentService.Search(search);

            foreach (var item in res)
            {
                Console.WriteLine($"{item.Id} - {item.Fullname} - {item.Age}");
            }
        }


        public void Sort()
        {
            Sort: Console.WriteLine("Select sort type : (1) Asc - (2)Dsc");
            string sortStr = Console.ReadLine();

            int sort;
            bool isTrueSortType = int.TryParse(sortStr, out sort);
            if (!isTrueSortType)
            {
                ConsoleColor.Red.WriteConsole("SortType format is wrong, please try again");
                goto Sort;
            }
            else
            {
                switch (sort)
                {
                    case 1:
                        var res = _studentService.Sort(sort);
                        foreach (var item in res)
                        {
                            Console.WriteLine($"{item.Id} - {item.Fullname} - {item.Age}");
                        }
                        break;
                    case 2:
                        var resDesc = _studentService.Sort(sort);
                        foreach (var item in resDesc)
                        {
                            Console.WriteLine($"{item.Id} - {item.Fullname} - {item.Age}");
                        }
                        break;
                    default:
                        ConsoleColor.Red.WriteConsole("This sort type not found");
                        break;

                }
            }
        }


        public void GetById()
        {
            Id: Console.WriteLine("Please enter ID");
            string IdStr = Console.ReadLine();

            int Id;
            bool isTrueId = int.TryParse(IdStr, out Id);


            if (isTrueId)
            {
                var res = _studentService.GetById(Id);

                if (res is null)
                {
                    ConsoleColor.Red.WriteConsole("This id is not exists,please enter again");
                    goto Id;
                }
                else
                {
                    Console.WriteLine($"{res.Id} - {res.Fullname} - {res.Age}");
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Format is not correct,please try again");
                goto Id;
            }
        }

    }
}

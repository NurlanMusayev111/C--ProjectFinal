using Domain.Models;
using Service.Helpers.Extension;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__ProjectFinal.Controllers
{
    public class GroupControllers
    {
        private readonly IGroupService _groupService;

        public GroupControllers()
        {
            _groupService = new GroupService();
        }


        public void Create()
        {
            Console.WriteLine("Add group name:");
            Group: string groupNameStr = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(groupNameStr))
            {
                ConsoleColor.Red.WriteConsole("Please fill group name...");
                goto Group;
            }

            var checkName = _groupService.CheckByName(groupNameStr.ToLower());

            if(checkName != null) 
            {
                ConsoleColor.Red.WriteConsole("This group name already exists");
                goto Group;
            }

            Console.WriteLine("Add group capacity:");
            GroupCap: string groupCapStr = Console.ReadLine();

            int groupCap;
            bool isTrueGroupCap = int.TryParse(groupCapStr, out groupCap);
            
            if(!isTrueGroupCap)
            {
                ConsoleColor.Red.WriteConsole("Wrong format count,please try again");
                goto GroupCap;
            }
            else
            {
                _groupService.Create(new Group { Name = groupNameStr , Capacity = groupCap});
            }
        }


        public void Delete()
        {
            Id: Console.WriteLine("Add delete ID:");
            string idStr = Console.ReadLine();
            int id;

            bool isTrueId = int.TryParse(idStr, out id);

            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Please fill id input");
            }

            if (isTrueId)
            {
                var res = _groupService.GetById(id);

                if (idStr is null)
                {
                    ConsoleColor.Red.WriteConsole("This id is not exists,please enter again");
                    goto Id;
                }
                else
                {
                    _groupService.Delete(res);
                }
            }

            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong");
            }

        }

        public void GetAll()
        {
            var result = _groupService.GetAll();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Capacity}");
            }
        }


        public void GetById()
        {
            Id: Console.WriteLine("Please enter ID");
            string IdStr =  Console.ReadLine();

            int Id;
            bool isTrueId = int.TryParse(IdStr, out Id);


            if(isTrueId)
            {
                var res = _groupService.GetById(Id);

                if(res is null)
                {
                    ConsoleColor.Red.WriteConsole("This id is not exists,please enter again");
                    goto Id;
                }
                else
                {
                    Console.WriteLine($"{res.Id} - {res.Name} - {res.Capacity}");
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Format is not correct,please try again");
                goto Id;
            }

            
        }

        
        public void Search()
        {
            Console.WriteLine("Search group name:");
            Search: string search =  Console.ReadLine();

            if(string.IsNullOrWhiteSpace(search))
            {
                ConsoleColor.Red.WriteConsole("Please fill search input!!");
                goto Search;
            }

            var res = _groupService.Search(search);

            foreach (var item in res)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Capacity}");
            }
        }


        public void Sort()
        {
            Sort: Console.WriteLine("Select sort type : (1) Asc - (2)Dsc");
            string sortStr = Console.ReadLine();

            int sort;
            bool isTrueSortType = int.TryParse(sortStr, out sort);
            if(!isTrueSortType)
            {
                ConsoleColor.Red.WriteConsole("SortType format is wrong, please try again");
                goto Sort;
            }
            else
            {
                switch (sort)
                {
                    case 1:
                        var res = _groupService.Sort(sort);
                        foreach (var item in res)
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - {item.Capacity}");
                        }
                        break;
                    case 2:
                        var resDesc = _groupService.Sort(sort);
                        foreach (var item in resDesc)
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - {item.Capacity}");
                        }
                        break;
                    default:
                        ConsoleColor.Red.WriteConsole("This sort type not found");
                        break;

                }
            }
        }



        public void Edit()
        {
            Id: Console.WriteLine("Enter id for editing:");
            string idStr = Console.ReadLine();

            int id;
            bool isTrueId = int.TryParse(idStr, out id);

            if (isTrueId)
            {
                var result = _groupService.GetById(id);

                Console.WriteLine("Please enter name:");
                string name = Console.ReadLine();


                Capacity: Console.WriteLine("Please capacity:");
                string capacityStr = Console.ReadLine();

                int capacity;
                bool isTrueCap = int.TryParse(capacityStr, out capacity);

                if(isTrueCap)
                {
                    _groupService.Edit(id,new Group { Name = name , Capacity = capacity});
                    ConsoleColor.Green.WriteConsole("Change succesfully");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Format is wrong please try again");
                    goto Capacity;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Format is wrong!");
            }


            

        }

    }
}

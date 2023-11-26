

using C__ProjectFinal.Controllers;
using Service.Enums;
using Service.Helpers.Extension;

GroupControllers groupControllers = new GroupControllers();  
UserControllers userControllers = new UserControllers();
StudentControllers studentControllers = new StudentControllers();



while (true)
{
    GetMenues();

    Console.WriteLine("Select one:");
    Option: string optionStr = Console.ReadLine();

    int option;
    bool isTrueOption = int.TryParse(optionStr, out option);

    if (isTrueOption)
    {
        switch (option)
        {
            case (int)AccesOption.Login:
                userControllers.Login();


                while (true)
                {
                    GetOptions();

                    string optionsStr = Console.ReadLine();
                    int options;

                    bool isTrueOptions = int.TryParse(optionsStr, out options);

                    switch (options)
                    {
                        case (int)GroupOption.GroupCreate:
                            groupControllers.Create();
                            break;
                        case (int)GroupOption.GroupDelete:
                            groupControllers.Delete();
                            break;
                        case (int)GroupOption.GroupGetAll:
                            groupControllers.GetAll();
                            break;
                        case (int)GroupOption.GroupSearch:
                            groupControllers.Search();
                            break;
                        case (int)GroupOption.GroupSorting:
                            groupControllers.Sort();
                            break;
                        case (int)GroupOption.GroupEdit:
                            groupControllers.Edit();
                            break;
                        case (int)GroupOption.GroupGetById:
                            groupControllers.GetById();
                            break;
                        case (int)StudentOption.StudentCreate:
                            studentControllers.Create();
                            break;
                        case (int)StudentOption.StudentDelete:
                            studentControllers.Delete();
                            break;
                        case (int)StudentOption.StudentEdit:
                            Console.WriteLine("Student edit"); 
                            break;
                        case (int)StudentOption.StudentGetById:
                            studentControllers.GetById(); 
                            break;
                        case (int)StudentOption.StudentGetAll:
                            studentControllers.GetAll();
                            break;
                        case (int)StudentOption.StudentSearch:
                            studentControllers.Search();
                            break;
                        case (int)StudentOption.StudentFilter:
                            studentControllers.Sort();
                            break;
                    }
                }


                
            case (int)AccesOption.Register:
                userControllers.Register();
                break;
                
        }
    }
    else
    {
        Console.WriteLine("Operation format is wrong,please try again");
        goto Option;
    }
}















static void GetMenues()
{
    Console.WriteLine("(1) Login - (2) Register");
}
static void GetOptions()
{
    ConsoleColor.Cyan.WriteConsole("\nGroup operations: 1-Create, 2-Delete, 3-GetAll, 4-Search, 5-Sorting,6-Edit, 7-GetById");
    ConsoleColor.Cyan.WriteConsole("Student operations : 8-Create, 9-Delete, 10-Edit, 11-GetById, 12-GetAll, 13-Search, 14-Filter");
}
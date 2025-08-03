using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class DisplayAllTasks
    {
        public void WelcomePage(TodoItem user) 
        {
            string choice="";
            while (choice != "e")
            {

                Console.WriteLine("To view all your tasks, press: 1");
                Console.WriteLine("To add a task, press: 2");
                Console.WriteLine("To exit, press: e");
                choice= Console.ReadLine();
                if (choice == "1")
                {
                    foreach (var index in user.Tasks)
                    {
                        Console.WriteLine(index.Title);
                        Console.WriteLine(index.Description);
                        Console.Write("Status: ");
                        if(index.IsCompleted == true)
                        {
                        Console.WriteLine("Completed");

                        }
                        else
                        {
                            Console.WriteLine("Incomplete");
                        }
                    }
                }
                else if (choice == "2")
                {

                }
                else
                {

                }
            }
        }
    }
}

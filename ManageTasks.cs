using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ManageTasks
    {
        public static void WelcomePage(TodoItem user) 
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
                    if (user==null)
                    {
                        Console.WriteLine("No Tasks to view");
                    }
                    else
                    {

                        foreach (var index in user.Tasks)
                        {
                            Console.WriteLine(index.Title);
                            Console.WriteLine(index.Description);
                            Console.Write("Status: ");
                            if (index.IsCompleted == true)
                            {
                                Console.WriteLine("Completed");

                            }
                            else
                            {
                                Console.WriteLine("Incomplete");
                            }
                        }
                    }
                }
                else if (choice == "2")
                {
                    AddTasks(user);
                }
                else
                {

                }
            }
        }

        public static void AddTasks(TodoItem user)
        {
            string title="";
            string description="";
            Console.Write("Please provide a title for the task: ");
            title = Console.ReadLine();
            Console.Write("Please describe the task: ");
            description=Console.ReadLine();
            JsonHandler jsonHandler = new JsonHandler();
            var json = jsonHandler.Readjson();
            TaskItem task = new TaskItem
            {
                Title = title,
                Description = description,
                IsCompleted = false
            };
            json[user.Id].Tasks.Add(task);
            File.WriteAllText(jsonHandler.JsonPath, JsonSerializer.Serialize(json, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}

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
                Console.WriteLine("To Logout, press: e");
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
                            Console.WriteLine("-----------------------------");
                            Console.Write("Title: ");
                            Console.WriteLine(index.Title);
                            Console.Write("Description: ");
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
                            Console.WriteLine("-----------------------------");
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
                JsonHandler jsonHandler =new JsonHandler();
                var json = jsonHandler.Readjson();
                foreach (var index in json)
                {
                    if (index.Id == user.Id)
                    {
                        user = index;
                    }
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
            json[json.Count-1].Tasks.Add(task);
            File.WriteAllText(jsonHandler.JsonPath, JsonSerializer.Serialize(json, new JsonSerializerOptions { WriteIndented = true }));
            json = jsonHandler.Readjson();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class SignIn
    {
        public TodoItem SignInCheck()
        {
            JsonHandler readjson = new JsonHandler();
            var json = readjson.Readjson();
            Object userinfo;
            bool loggedIn = false;
            string username;
            string password;
            string userexit = "f";
            bool exit = false;
            while (userexit != "e")
            {

                Console.WriteLine("Please enter your username: ");
                username = Console.ReadLine();
                Console.WriteLine("Please enter your password");
                password = Console.ReadLine();
                foreach (var index in json)
                {
                    if (index.Username == username && index.Password == password)
                    {
                        userinfo = index;
                        loggedIn = true;
                        return index;
                    }
                }
                if (!loggedIn)
                {
                    Console.WriteLine("Entered Password or username is wrong!");
                    Console.WriteLine("press e to exit,or hit any key to try again");
                    userexit = Console.ReadLine();
                }

            }
            TodoItem nullItem = new TodoItem
            {
                Username = null,
                Password = null,
                Tasks = null,
                Title = null,
                Description = null
                // int and bool are value types — can't be null unless you make them nullable
            };

            return (nullItem);
        }
        
    }
}

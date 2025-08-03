using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDoList
{
    public class CreateAccount
    {
        public static TodoItem UserAccount()
        {
            bool validusername = false;
            int id;
            string name;
            string password;
            var handler = new JsonHandler();
            List<TodoItem> jsondata = handler.Readjson();

            string chooseusername()
            {
            Console.WriteLine("Please choose a username:");
            string userNameChoice=Console.ReadLine();
            while (userNameChoice.Length <= 1)
            {
                Console.WriteLine("name length must be at least 2 characters");
                Console.WriteLine("Please choose a username");
                userNameChoice = Console.ReadLine();
            }
                for (int index = 0; index < jsondata.Count; index++)
                {
                    if (jsondata[index].Username == userNameChoice)
                    {
                        Console.WriteLine("username has already been chosen, please a unique username");
                        userNameChoice=Console.ReadLine();
                        index = 0;
                    }
                }
                return userNameChoice;
            } 


            string choosepassword()
            {
                string password="";
                while (password.Length <= 3)
                {
                Console.WriteLine("Pleasev choose a password with a minimum of 4 characters");
                password = Console.ReadLine();
                }
                return password;
            }

            name = chooseusername();
            password = choosepassword();
            id = jsondata.Count+1;

            JsonHandler jsonhandler = new JsonHandler();
            jsonhandler.AddUserIntoJsonFile(id,name,password);
            return null;
            }

            
        }
    }


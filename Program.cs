// See https://aka.ms/new-console-template for more information
using ToDoList;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using SQLite;
namespace ToDoList
{
    public class MainProj
    {
        public int id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string task { get; set; }
        public bool status { get; set; }

        public string password { get; set; }
        public static void Main()
        {
            List<TodoItem> todoList = new List <TodoItem>();
            MainProj p = new MainProj();
            ManageTasks manageTasks = new ManageTasks();
            string choice="";
            while (choice != "e")
            {

            Console.WriteLine("Welcome!");
            Console.WriteLine("would you like to signin or create an account");

            Console.WriteLine("Press 1 to signin, 2 to create an account, or e to exit");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                SignIn signin = new SignIn();
                var signincheck = signin.SignInCheck();
                Console.WriteLine("you are logged in");
                 ManageTasks.WelcomePage(signincheck);
            }
            else if (choice == "2")
            {
               // var accountCreationHandler = new CreateAccount();
             var accountInstance= CreateAccount.UserAccount();
                Console.WriteLine("Account created.");
                 ManageTasks.WelcomePage(accountInstance);
               
            }
            else
            {
                Console.WriteLine("Please enter either 1 or 2");
            }
            }
        }
    }

}

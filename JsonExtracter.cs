using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToDoList
{
    public class JsonHandler
    {
        public string JsonPath= @"C:\Users\abdi\source\repos\ToDoList\ToDoList\Todo.json";
        public List<TodoItem> Readjson()
        {
            string json = File.ReadAllText(JsonPath);
        List<TodoItem> todos = JsonSerializer.Deserialize <List<TodoItem>> (json);
            return todos;   
        }
        public TodoItem AddUserIntoJsonFile(int id,string Username,string Password)
        {
            var jsonValues = Readjson();
            TodoItem newUser = new TodoItem
            {
                Id = id,
                Username = Username,
                Password = Password,
                Tasks = new List<TaskItem>(), // empty tasks list
                Title = null,
                Description = null,
                IsCompleted = false
            };


            jsonValues.Add(newUser);
            File.WriteAllText(JsonPath, JsonSerializer.Serialize(jsonValues, new JsonSerializerOptions { WriteIndented = true }));
            jsonValues = Readjson();
            return newUser;




        }


    }
}

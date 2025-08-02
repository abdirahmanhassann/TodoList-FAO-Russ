using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDoList
{
    public class JsonHandler
    {
        public List<TodoItem> Readjson()
        {
            string jsonPath = @"C:\Users\abdi\source\repos\ToDoList\ToDoList\Todo.json";
            string json = File.ReadAllText(jsonPath);
        List<TodoItem> todos = JsonSerializer.Deserialize <List<TodoItem>> (json);
            return todos;   
        }
        public List<TodoItem> AddUserIntoJsonFile(int id,string Username,string Password)
        {
            string jsonPath = @"C:\Users\abdi\source\repos\ToDoList\ToDoList\Todo.json";
            var jsonValues = Readjson();
            var newAccount = new TodoItem
            {
                Id = id,
                Username = Username,
                Password = Password,
                Title = "",
                Description = "",
                IsCompleted = false
            };

            jsonValues.Add(newAccount);
            File.WriteAllText(jsonPath, JsonSerializer.Serialize(jsonValues, new JsonSerializerOptions { WriteIndented = true }));
            return jsonValues;
            

        }

    }
}

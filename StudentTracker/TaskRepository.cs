using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace StudentTracker
{
    public class TaskRepository : IRepository<TaskItem>
    {
        
        private List<TaskItem> _tasks;

        
        private readonly string _filePath = "tasks.json";

        public TaskRepository()
        {
            _tasks = new List<TaskItem>();
            LoadFromFile(); 
        }

        public IEnumerable<TaskItem> GetAll() => _tasks;

        public TaskItem GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public void Add(TaskItem entity)
        {
            if (entity != null)
            {
                _tasks.Add(entity);
                Save(); 
            }
        }

        public void Remove(TaskItem entity)
        {
            if (entity != null)
            {
                _tasks.Remove(entity);
                Save(); 
            }
        }

       

        public void Save()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_tasks, options);
            File.WriteAllText(_filePath, jsonString);
        }

        private void LoadFromFile()
        {
            if (File.Exists(_filePath))
            {
                string jsonString = File.ReadAllText(_filePath);
                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    _tasks = JsonSerializer.Deserialize<List<TaskItem>>(jsonString);
                }
            }
        }
    }
}
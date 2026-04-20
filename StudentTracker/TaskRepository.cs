using System.Collections.Generic;
using System.Linq;

namespace StudentTracker
{
    
    public class TaskRepository : IRepository<TaskItem>
    {
        
        private readonly List<TaskItem> _tasks;

        public TaskRepository()
        {
            _tasks = new List<TaskItem>();
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _tasks;
        }

        public TaskItem GetById(int id)
        {
           
            return _tasks.FirstOrDefault(task => task.Id == id);
        }

        public void Add(TaskItem entity)
        {
            if (entity != null)
            {
                _tasks.Add(entity);
            }
        }

        public void Remove(TaskItem entity)
        {
            if (entity != null)
            {
                _tasks.Remove(entity);
            }
        }

        
        public IEnumerable<TaskItem> SearchByTitle(string keyword)
        {
            return _tasks.Where(task => task.Title.ToLower().Contains(keyword.ToLower()));
        }
    }
}
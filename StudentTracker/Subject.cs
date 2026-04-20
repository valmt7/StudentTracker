using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace StudentTracker
{
    public class Subject
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }

      
        private List<TaskItem> _tasks;

     
        public Subject(int id, int userId, string name, string teacherName)
        {
            Id = id;
            UserId = userId;
            Name = name;
            TeacherName = teacherName;
            _tasks = new List<TaskItem>();
        }

        
        public List<TaskItem> GetTasks()
        {
            return _tasks;
        }

       
        public void AddTask(TaskItem task)
        {
            if (task != null)
            {
                _tasks.Add(task);
            }
        }
    }
}

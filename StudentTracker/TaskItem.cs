using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracker
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed
    }
    public class TaskItem
    {
        public int Id { get; private set; }
        public int SubjectId { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

       
        public TaskStatus Status { get; private set; }

        
        public TaskItem(int id, int subjectId, string title, string description, DateTime dueDate)
        {
            Id = id;
            SubjectId = subjectId;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = TaskStatus.Pending; 
        }

       
        public void MarkAsDone()
        {
            Status = TaskStatus.Completed;
        }

       
        public void ChangeStatus(TaskStatus newStatus)
        {
            Status = newStatus;
        }
    }
}

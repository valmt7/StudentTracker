using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        
        [Required(ErrorMessage = "Назва завдання є обов'язковою.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Назва має містити від 3 до 100 символів.")]
        public string Title { get; set; }

        
        [StringLength(500, ErrorMessage = "Опис не може перевищувати 500 символів.")]
        public string Description { get; set; }

        
        [FutureDate(ErrorMessage = "Дедлайн не може бути встановлений у минулому часі.")]
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


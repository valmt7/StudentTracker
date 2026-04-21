using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentTracker; 
using System;
using System.Linq;

namespace StudentTracker.Tests
{
   
    [TestClass]
    public class TaskItemTests
    {
        [TestMethod]
        public void MarkAsDone_ShouldChangeStatusToCompleted()
        {
           
            var task = new TaskItem(1, 1, "Тестове завдання", "Опис", DateTime.Now.AddDays(1));

            
            task.MarkAsDone();

           
            Assert.AreEqual(TaskStatus.Completed, task.Status, "Статус не змінився на 'Виконано'.");
        }
    }

    [TestClass]
    public class TaskRepositoryTests
    {
        [TestMethod]
        public void AddTask_ShouldSaveTaskToRepository()
        {
            // Arrange
            var repo = new TaskRepository();
            var task = new TaskItem(99, 1, "Тест для репозиторію", "", DateTime.Now.AddDays(2));

            // Act
            repo.Add(task);
            var result = repo.GetById(99);

            // Assert
            Assert.IsNotNull(result, "Завдання не було додано до репозиторію.");
            Assert.AreEqual("Тест для репозиторію", result.Title);

            
            repo.Remove(task);
        }
    }
}
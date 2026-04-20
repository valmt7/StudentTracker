using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracker
{
    public class User
    {
      
        private int _id;
        public int Id
        {
            get { return _id; }
            private set { _id = value; } 
        }

        public string Username { get; set; } 
        public string Email { get; set; }

       
        public List<Subject> Subjects { get; private set; }

      
        public User(int id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
            Subjects = new List<Subject>(); 
        }

        public void Login()
        {
            // Логіка
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations; 

namespace StudentTracker
{
   
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
               
                return dateTime.Date >= DateTime.Now.Date;
            }
            return false;
        }
    }
}
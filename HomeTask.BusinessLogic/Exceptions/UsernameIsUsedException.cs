using System;

namespace HomeTask.BusinessLogic.Exceptions
{
    public class UsernameIsUsedException : Exception
    {
        public UsernameIsUsedException(string message) : base(message) 
        {
            
        }
    }
}
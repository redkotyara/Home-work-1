using System;

namespace HomeTask.DataAccess.Entities
{
    public class UserEntity
    {
        public string HashedPassword { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }

        public DateTime? LastActionTime { get; set; }
    }
}
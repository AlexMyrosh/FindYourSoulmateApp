using System;

namespace Data_Access_Layer.Models
{
    public class UserAnswer
    {
        public Guid Id { get; set; }

        public string Answer { get; set; }

        public User User { get; set; }

        public Question Question { get; set; }
    }
}

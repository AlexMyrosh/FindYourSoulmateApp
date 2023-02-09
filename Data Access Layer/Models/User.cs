using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string TelegramUsername { get; set; }

        public string Email { get; set;}

        public bool IsDeleted { get; set; }

        public IEnumerable<UserAnswer> Answers { get; set; }
    }
}

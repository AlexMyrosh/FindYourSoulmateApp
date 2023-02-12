using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string TelegramUsername { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public List<UserAnswerModel> Answers { get; set; }
    }
}

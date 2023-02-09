using System;
using System.Collections.Generic;

namespace Presentation_Layer.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<string> Answers { get; set; }

    }
}

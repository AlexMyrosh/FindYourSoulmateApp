﻿using PL.ViewModels;

namespace PL.ViewModels
{
    public class InterestViewModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public List<UserViewModel>? Users { get; set; }

        public bool IsDeleted { get; set; }
    }
}

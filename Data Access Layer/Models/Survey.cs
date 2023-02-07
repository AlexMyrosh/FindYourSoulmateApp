﻿using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public class Survey
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<Question> Questions { get; set; }
    }
}
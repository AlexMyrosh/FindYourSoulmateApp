using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public class Question
    {
        public Guid Id { get; set; }

        public string Body { get; set; }

        public double Coefficient { get; set; }

        public bool IsDeleted { get; set; }

        public Survey Survey { get; set; }

        public IEnumerable<AnswerOption> Options { get; set; }
    }
}

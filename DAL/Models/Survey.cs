﻿using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Survey
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime StopDateTime { get; set; }

        public bool IsDeleted { get; set; }

        public List<Question> Questions { get; set; }
    }
}

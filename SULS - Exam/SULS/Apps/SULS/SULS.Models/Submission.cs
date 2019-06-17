namespace SULS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Submission
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(800)]
        public string Code { get; set; }

        [Required]
        [Range(0, 300)]
        public int AchievedResult { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public Problem Problem { get; set; }

        public User User { get; set; }
    }
}

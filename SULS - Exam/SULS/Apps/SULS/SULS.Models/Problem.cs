namespace SULS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Problem
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Range(50, 300)]
        public int Points { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}

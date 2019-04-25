using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Data
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public int Rank { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public bool Injured { get; set; }
        [Required]
        public bool Drafted { get; set; }
        public string Note { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

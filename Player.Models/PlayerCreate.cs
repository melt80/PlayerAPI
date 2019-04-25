using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Models
{
    public class PlayerCreate
    {
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
        public DateTimeOffset CreatedUtc { get; set; }
        public string Note { get; set; }
    }
}

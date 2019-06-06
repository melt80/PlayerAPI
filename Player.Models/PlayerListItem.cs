using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Player.Models
{
    public class PlayerListItem
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Player.Models
{
    public class PlayerEdit
    {
        public int PlayerId { get; set; }
        public int Rank { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public bool Injured { get; set; }
        public bool Drafted { get; set; }
        public string Note { get; set; }
    }
}

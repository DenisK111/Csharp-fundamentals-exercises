﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Director { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        /*⦁	Id – integer, Primary Key
        ⦁	Name – text with length [4, 30] (required)
        ⦁	NumberOfHalls – sbyte between [1…10] (required)
        ⦁	Director – text with length [4, 30] (required)
        ⦁	Tickets - a collection of type Ticket
        */
    }
}

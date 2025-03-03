﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal NetWorth { get; set; }
        public ICollection<SongPerformer> PerformerSongs { get; set; }

    }
}

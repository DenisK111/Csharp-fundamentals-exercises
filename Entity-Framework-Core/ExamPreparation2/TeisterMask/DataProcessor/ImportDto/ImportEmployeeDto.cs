﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    
    public class ImportEmployeeDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\d]+$")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[\d]{3}-[\d]{3}-[\d]{4}$")]
        public string Phone { get; set; }

        public HashSet<int> Tasks  { get; set; }

    }

    

}

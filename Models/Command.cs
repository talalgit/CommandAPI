﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CommandAPI.Models
{
    public class Command
    {
        [Key]
        [Required]
        public long Id { get; set; }


        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }


        [Required]
        public string Platform { get; set; }

        [Required]
        public string CommandLine { get; set; }


    }
}

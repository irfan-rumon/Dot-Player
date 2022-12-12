﻿using System.ComponentModel.DataAnnotations;

namespace PlayerApp.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }


        [Required]  
        public string? Country { get; set; }


        [Required]  
        public int Age { get; set; } 

    }
}

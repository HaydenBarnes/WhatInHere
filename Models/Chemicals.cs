using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatInHere.Models
{
    public class Chemicals
    {
        public int Id { get; set; }
        [Display(Name = "Chemical Name")]
        [StringLength(60, MinimumLength = 2), Required]
        public string Chemical { get; set; }
        [Required]
        public string Effects { get; set; }
        [StringLength(9, MinimumLength = 7), Required]
        public string Natural { get; set; }
        [DataType(DataType.Url), Required]
        public string Source { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatInHere.Models
{
    public class Chemicals
    {
        public int Id { get; set; }
        [Display(Name = "Chemical Name")]
        public string Chemical { get; set; }
        public string Effects { get; set; }
        public string Natural { get; set; }
        [DataType(DataType.Url)]
        public string Source { get; set; }
    }
}

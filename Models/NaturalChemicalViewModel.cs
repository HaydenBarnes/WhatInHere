using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WhatInHere.Models
{
    public class NaturalChemicalViewModel
    {
        public List<Chemicals> Chemicals { get; set; }
        public SelectList Natural { get; set; }
        public string NaturalChemical { get; set; }
        public string SearchString { get; set; }
    }
}

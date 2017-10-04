using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminWebSite.Models
{
    public class CountryViewModel
    {
        [Display(Name="Coutry Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime DateCreate { get; set; }
        [Display(Name = "Priority")]
        public int Priority { get; set; }
    }
    public class CountryCreateViewModel
    {
        [Required(ErrorMessage ="Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        [Range(1, short.MaxValue, ErrorMessage ="Range: 1-31456")]
        [Display(Name = "Priority")]
        public int Priority { get; set; }
    }
    public class CountryEditViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        [Range(1, short.MaxValue, ErrorMessage = "Range: 1-31456")]
        [Display(Name = "Priority")]
        public int Priority { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminWebSite.Models
{
    public class CityViewModel
    {
        [Display(Name = "City Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime DateCreate { get; set; }
        [Display(Name = "Priority")]
        public int Priority { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
    }
    public class CityCreateViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Priority")]
        public int Priority { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public List<SelectItemViewModel> Countries { get; set; }
    }
    public class CityEditViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Priority")]
        public int Priority { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public List<SelectItemViewModel> Countries { get; set; }
    }
}
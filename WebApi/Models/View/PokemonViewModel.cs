using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDevLab9.Models.View;
using WebDevLab9.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.View
{
    public class PokemonViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pokemon's Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Pokemon's Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Next Checkup")]
        public DateTime NextCheckup { get; set; }

        [Required]
        [Display(Name = "Vet Name")]
        public string VetName { get; set; }

        public bool CheckupAlert { get; set; }

        public int UserId { get; set; }
    }
}
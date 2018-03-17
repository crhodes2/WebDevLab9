using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entities
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime NextCheckup { get; set; }

        public string VetName { get; set; }
    }
}
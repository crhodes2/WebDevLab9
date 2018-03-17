using System;
using System.ComponentModel.DataAnnotations;

namespace WebDevLab9.Data.Entities
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime NextCheckup { get; set; }

        public string VetName { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
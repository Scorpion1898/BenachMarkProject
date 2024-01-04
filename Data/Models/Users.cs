using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BanchMarkProject.Data.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public virtual List<Address> Address { get; set; }
    }
}

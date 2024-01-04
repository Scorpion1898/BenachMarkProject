using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanchMarkProject.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public Users User { get; set; }

    }
}

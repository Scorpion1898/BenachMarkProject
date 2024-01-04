using System;

namespace BanchMarkProject.Data
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

    }
}

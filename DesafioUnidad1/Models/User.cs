using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioUnidad1.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}

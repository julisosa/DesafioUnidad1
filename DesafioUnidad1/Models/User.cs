using DesafioUnidad1.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioUnidad1.Models
{
    public class User : IBaseEntity
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "A name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "A password is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters", MinimumLength = 3)]
        public string Password { get; set; }

        [Required(ErrorMessage = "An email is required")]
        [StringLength(50, ErrorMessage = "You can use letters, numbers and punctuation marks", MinimumLength = 3)]
        public string Email { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}

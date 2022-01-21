using DesafioUnidad1.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioUnidad1.Models
{
    public class Comments : IBaseEntity
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [StringLength(150, ErrorMessage = "Comment cannot be longer than 150 characters", MinimumLength = 1)]
        public string Comment { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}

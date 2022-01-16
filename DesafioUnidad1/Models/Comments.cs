using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioUnidad1.Models
{
    internal class Comments
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }

    }
}

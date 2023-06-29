using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel.Request
{
    public class AddBook
    {
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [MaxLength(200)]
        public string Author { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }



    }
}

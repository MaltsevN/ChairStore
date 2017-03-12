using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Chair
    {
        [HiddenInput(DisplayValue = false)]
        public int ChairId { get; set; }

        [Required(ErrorMessage = "Please, enter chair name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please, enter chair description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please, enter chair category")]
        public string Category { get; set; }

        [Display(Name = "Price (hrn)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please, enter the positive price number")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}

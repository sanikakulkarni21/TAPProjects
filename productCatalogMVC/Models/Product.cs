using System.ComponentModel.DataAnnotations;

namespace MyAssessment.WebMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string? Name { get; set; }

        [Required, StringLength(500)]
        public string? Des { get; set; }

        public string? ImgUrl { get; set; }

        [Range(0, 99999)]
        public double UnitPrice { get; set; }

        public int Likes { get; set; }

        public int Quantity { get; set; }
    }
}

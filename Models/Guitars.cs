using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcGuitars10.Models
{
    public class Guitars
    {
        public int Id { get; set; }
        [Display(Name = "Guitar Model")]
        public string GuitarModel { get; set; }
        [Display(Name = "Guitar Brand")]
        public string GuitarBrand { get; set; }
        [Display(Name = "Issure year")]

        public int IssueYear { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}

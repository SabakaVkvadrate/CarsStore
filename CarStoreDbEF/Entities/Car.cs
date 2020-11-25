using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarStoreDbEF.Entities
{
    public class Car:BaseEntity
    {
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public DateTime ManafDate { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string ImgLink { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuId { get; set; }

        [Required]
        public string AdSoyad { get; set; }

        [Required]
        public string Telefon { get; set; }

        [Required]
        public DateTime RandevuTarihi { get; set; }

        [Required]
        public string RandevuDetayi { get; set; }
    }

}

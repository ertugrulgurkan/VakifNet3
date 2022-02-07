using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntroNetCore.Models
{
    public class Katilimci
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı boş olamaz")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş olamaz")]

        public string Soyad { get; set; }
        [EmailAddress]
        public string Eposta { get; set; }
        public bool? KatilimDurumu { get; set; }
    }
}

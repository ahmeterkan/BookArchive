using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookArchive.Models
{
    [Table("Yazar")]
    public class Yazar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, DisplayName("Yazar Adı")]
        public string YazarAd { get; set; }

        [Required, DisplayName("Yazar Soyadı")]
        public string YazarSoyad { get; set; }

        public virtual List<Kitap> Kitap { get; set; }
    }
}
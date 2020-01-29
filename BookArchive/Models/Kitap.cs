using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookArchive.Models
{
    [Table("Kitap")]
    public class Kitap
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required, DisplayName("Kitap Adı")]
        public string KitapAdi { get; set; }

        public virtual Yazar Yazar { get; set; }
    }
}
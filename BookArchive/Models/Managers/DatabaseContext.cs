using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace BookArchive.Models.Managers
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new VeritabaniOlusturucu());
        }
    }

    public class VeritabaniOlusturucu : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {


            Yazar yazar1 = new Yazar();
            yazar1.YazarAd = "Tess";
            yazar1.YazarSoyad = "Gerritsen";
            context.Yazarlar.Add(yazar1);

            Yazar yazar2 = new Yazar();
            yazar2.YazarAd = "John";
            yazar2.YazarSoyad = "Steinbeck";
            context.Yazarlar.Add(yazar2);

            context.SaveChanges();



            Kitap kitap1 = new Kitap();
            kitap1.KitapAdi = "Ruh Koleksiyoncusu";
            kitap1.Yazar = yazar1;
            context.Kitaplar.Add(kitap1);

            Kitap kitap2 = new Kitap();
            kitap2.KitapAdi = "Fareler ve İnsanlar";
            kitap2.Yazar = yazar2;
            context.Kitaplar.Add(kitap2);

            context.SaveChanges();

        }
    }
}
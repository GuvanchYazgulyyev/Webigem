using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyProject.Models.Sinif
{
    public class Context: DbContext
    {
        public DbSet <AdminGiris> AdminGirises { get; set; }
        public DbSet <AdminYetki> AdminYetkis { get; set; }
        public DbSet <Bloglar> Bloglars { get; set; }
        public DbSet <HakkimizdaYazi> HakkimizdaYazis { get; set; }
        public DbSet <HizmetForm> HizmetForms { get; set; }
        public DbSet <Hizmetler> Hizmetlers { get; set; }
        public DbSet <iletisimMesaj> iletisimMesajs { get; set; }
        public DbSet <KVKKSozlesmesi> KVKKSozlesmesis { get; set; }
        public DbSet <Musteriler> Musterilers { get; set; }
        public DbSet <MutluMusYorumu> MutluMusYorumus { get; set; }
        public DbSet <NedenBiz> NedenBizs { get; set; }
        public DbSet <Notlar> Notlars { get; set; }
        public DbSet <Paketler> Paketlers { get; set; }
        public DbSet <Projeler> Projelers { get; set; }
        public DbSet <Referanslar> Referanslars { get; set; }
        public DbSet <SiteiletisimBilgi> SiteiletisimBilgis { get; set; }
        public DbSet <Slider> Sliders { get; set; }
        public DbSet <Sparisler> Sparislers { get; set; }
        public DbSet <SSS> SSSes { get; set; }
        public DbSet <Takim> Takims { get; set; }
        public DbSet <WebSiteTanitma> WebSiteTanitmas { get; set; }
        public DbSet <YapilanPSayisi> YapilanPSayisis { get; set; }
        public DbSet <ProjeilerlemeSureci> ProjeilerlemeSurecis { get; set; }
    }
}
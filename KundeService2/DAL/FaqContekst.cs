using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KundeService2.DAL
{
    public class Faqer
    {
        public int Id { get; set; }  // gir en primærnøkkel med autoincrement fordi attributten heter noe med "id"
        public string Question { get; set; }
        public string Answer { get; set; }
      
    }
    

    public class FaqContext : DbContext
    {
            public FaqContext (DbContextOptions<FaqContext> options)
                    : base(options)
            {
                // setningen under brukes for å opprette databasen fysisk dersom den ikke er opprettet
                // dette er uavhenig av initiering av databasen, se DBInit(seed)
                // når man endrer på strukturen på KundeContext er det fornuftlig å slette "Kunde.Db" fysisk før nye kjøringer
                Database.EnsureCreated();
        }

        public DbSet<Faqer> Faqer { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // må importere pakken Microsoft.EntityFrameworkCore.Proxies
            // og legge til"viritual" på de attriuttene som ønskes å lastes automatisk (LazyLoading)
           // optionsBuilder.UseLazyLoadingProxies();
        }

    }
}

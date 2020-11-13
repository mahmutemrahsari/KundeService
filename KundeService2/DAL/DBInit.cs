using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KundeService2.DAL
{
    public static class DBInit
    {
        public static void Seed(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            
            var db = serviceScope.ServiceProvider.GetService<FaqContext>();

            // må slette og opprette databasen hver gang når den skal initieres (seed`es)
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

    

            var faq1 = new Faqer
            {
                Question = "Lorem ipsum1",
                Answer = "Lorem answer ipsum",
     
            };

            var faq2 = new Faqer
            {
                Question = "Lorem2 ipsum21",
                Answer = "Lorem2 answer2 ipsum2",
            };

            var faq3 = new Faqer
            {
                Question = "Lorem3 ipsum13",
                Answer = "Lorem3 answer3 ipsum3",
            };

            db.Faqer.Add(faq1);
            db.Faqer.Add(faq2);
            db.Faqer.Add(faq3);

            db.SaveChanges();
        }
    }  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KundeService2.Model;
using Microsoft.EntityFrameworkCore;

namespace KundeService2.DAL
{
        public class FaqRepository : IFaqRepository
    {
        private readonly FaqContext _db;

        public FaqRepository(FaqContext db)
        {
            _db = db;
        }

        public async Task<bool> Lagre(Faq innFaq)
        {
            try
            {
                var nyFaqRad = new Faqer();
                nyFaqRad.Question = innFaq.Question;
                nyFaqRad.Answer = innFaq.Answer;

                _db.Faqer.Add(nyFaqRad);
                await _db.SaveChangesAsync();
                return true;
            }



            catch
            {
                return false;
            }
        }


        public async Task<List<Faq>> HentAlle()
        {
            try
            {
                List<Faq> alleFaqer = await _db.Faqer.Select(k => new Faq
                {
                    Id = k.Id,
                    Question = k.Question,
                    Answer = k.Answer,
           
                }).ToListAsync();
                return alleFaqer;
            }
            catch
            {
                return null;
            }
        }

 

        public async Task<Faq> HentEn(int id)
        {
            Faqer enFaq = await _db.Faqer.FindAsync(id);
            var hentetFaq = new Faq()
            {
                Id = enFaq.Id,
                Question = enFaq.Question,
                Answer = enFaq.Answer,
                
            };
            return hentetFaq;
        }
    }
}
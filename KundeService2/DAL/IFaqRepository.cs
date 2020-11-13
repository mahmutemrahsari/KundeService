using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KundeService2.Model;

namespace KundeService2.DAL
{
    public interface IFaqRepository
    {
        Task<bool> Lagre(Faq innFaq);
        Task<List<Faq>> HentAlle();
        Task<Faq> HentEn(int id);
     
    }
}

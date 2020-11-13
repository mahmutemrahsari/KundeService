using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KundeService2.DAL;
using KundeService2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KundeService2.Controllers


{
    [ApiController]
    // dekoratøren over må være med; dersom ikke må post og put bruke [FromBody] som deoratør inne i prameterlisten
    [Route("api/[controller]")]
    public class FaqController : ControllerBase
{
    private IFaqRepository _db;

    private ILogger<FaqController> _log;

    public FaqController(IFaqRepository db, ILogger<FaqController> log)
    {
        _db = db;
        _log = log;
    }

    [HttpPost]
    public async Task<ActionResult> Lagre(Faq innFaq)
    {
        if (ModelState.IsValid)
        {
            bool returOK = await _db.Lagre(innFaq);
            if (!returOK)
            {
                _log.LogInformation("Faq kunne ikke lagres!");
                return BadRequest();
            }
            return Ok(); // kan ikke returnere noe tekst da klient prøver å konvertere deene som en Json-streng
        }
        _log.LogInformation("Feil i inputvalidering");
        return BadRequest();
    }

    [HttpGet]
    public async Task<ActionResult> HentAlle()
    {
        List<Faq> alleFaqer = await _db.HentAlle();
        return Ok(alleFaqer);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult> HentEn(int id)
    {
        if (ModelState.IsValid)
        {
            Faq faqen = await _db.HentEn(id);
            if (faqen == null)
            {
                _log.LogInformation("Fant ikke faqen");
                return NotFound();
            }
            return Ok(faqen);
        }
        _log.LogInformation("Feil i inputvalidering");
        return BadRequest();
    }

}
}

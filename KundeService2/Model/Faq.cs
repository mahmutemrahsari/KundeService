using System;
using System.ComponentModel.DataAnnotations;

namespace KundeService2.Model
{
    public class Faq
    {
        public int Id { get; set; }
        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,30}")]

        public string Question { get; set; }
        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,30}")]

        public string Answer { get; set; }
      //  [RegularExpression(@"[0-9a-zA-ZæøåÆØÅ. \-]{2,30}")]
    }
}


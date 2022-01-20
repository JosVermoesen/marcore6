using System;
using System.ComponentModel.DataAnnotations;

namespace marcore.Entities
{
    public class VsoftMailLog
    {
        public string Id { get; set; }
        public DateTime LoggingDateTime { get; set; }
        public string NameTo { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string HtmlBody { get; set; }
        public string EmailFromApi { get; set; }
        public string NameFromApi { get; set; }        
    }
}

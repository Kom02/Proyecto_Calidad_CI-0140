using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Mail
    {
        public string FromMailId { get; set; } = "emprende.ucr@gmail.com";
        public string FromMailIdPassword { get; set; } = "ingebases21";
        public List<string> ToMailIds { get; set; } = new List<string>();
        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";
        public bool IsBodyHtml { get; set; } = true;
        public List<string> Attachements { get; set; } = new List<string>();
    }
}

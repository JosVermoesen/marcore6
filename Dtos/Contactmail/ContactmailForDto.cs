using System.ComponentModel.DataAnnotations;

namespace marcore.api.Dtos.Contactmail
{
    public class ContactmailForDto
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string RR { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool CopySender { get; set; }
        public string Message { get; set; }
        public string Template { get; set; }
        public string Data { get; set; }
        [Required]
        public string ApiGuid { get; set; }
        [Required]
        public string ApiMailKey { get; set; }
        [Required]
        public string ApiNameKey { get; set; }
    }
}
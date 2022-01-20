namespace marcore.api.Dtos.VsoftMailform
{
    public class MailformForUpdateDto
    {
        public string Id { get; set; }  // Short Description
        public string Subject { get; set; }
        public string Body { get; set; }
        public string PartyCode { get; set; } // D= Debitor  C= Creditor G = Government          
    }
}
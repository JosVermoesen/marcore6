namespace marcore.Entities
{
    public class Contactmail
    {
        public string Subject { get; set; }
        public string Name { get; set; }
        public string RR { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool CopySender { get; set; }
        public string Message { get; set; }           
        public string Template { get; set; }           
        public string Data { get; set; }           
        public string ApiGuid { get; set; }
        public string ApiMailKey { get; set; }
        public string ApiNameKey { get; set; }
    }
}
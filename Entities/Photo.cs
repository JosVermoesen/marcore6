using System;

namespace marcore.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public bool IsApproved { get; set; }
        public virtual User User { get; set; }     // important for ON DELETE CASCADE when User is deleted
        public int UserId { get; set; }    // important for ON DELETE CASCADE when User is deleted
    }
}
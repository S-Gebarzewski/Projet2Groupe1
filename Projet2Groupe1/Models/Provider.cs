namespace Projet2Groupe1.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string ServiceType { get; set; }
       // public int NumberServices { get; set; }
        public Adress Adress { get; set; }
        public int UserId { get; set; }

        public byte[]? PhotoData { get; set; }

    }
}

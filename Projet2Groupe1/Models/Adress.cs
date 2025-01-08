namespace Projet2Groupe1.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string? NamedPlace { get; set; }
        public string? StreetComplement { get; set; }


    }
}

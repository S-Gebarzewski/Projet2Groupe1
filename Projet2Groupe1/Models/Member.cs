namespace Projet2Groupe1.Models
{
    public class Member
    {
        public int Id { get; set; }
        public int Age {  get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public bool IsPremium { get; set; }
        public int UserId { get; set; }


        public override String ToString()
        {
            return $"Creation d'un Member : {Age} ans {IsPremium}. Son UserId est : {UserId}";
        }
    }
}

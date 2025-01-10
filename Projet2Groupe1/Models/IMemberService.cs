namespace Projet2Groupe1.Models
{
    public interface IMemberService : IDisposable
    {

        public int CreateMember(int? Age, string City, string? ZipCode, bool IsPremium, bool IsPayed, int UserId);
        public User searchMember(int id);
        public User ObtainMember(int id);
        public User ObtainMember(string idStr);
    }
}

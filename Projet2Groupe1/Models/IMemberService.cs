namespace Projet2Groupe1.Models
{
    public interface IMemberService : IDisposable
    {

        public int CreateMember(int? Age, string City, string? ZipCode, bool IsPremium, bool IsPayed, int UserId);
        public Member searchMember(int id);
        public Member GetMember(int id);
        public Member GetMember(string idStr);
        public Member UpdateMember(Member UpdatingMember);
    }
}

namespace Projet2Groupe1.Models
{
    public class MemberService : IMemberService
    {
        private DataBaseContext _dbContext;

        public MemberService(DataBaseContext _dbContext) 
        {
            this._dbContext = _dbContext;
        }
        public int CreateMember(int? Age, string City, string? ZipCode, bool IsPayed, bool IsPremium, int UserId)
        {
            Member member = new Member()
            {
                Age = Age,
                City = City,
                ZipCode = ZipCode,
                UserId = UserId
            };

            _dbContext.Members.Add(member);
            _dbContext.SaveChanges();
            Console.WriteLine("Dans la methode create member apres savesChanges, userId vaut  " + UserId);
            return member.Id;
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        public User ObtainMember(int id)
        {
            throw new NotImplementedException();
        }

        public User ObtainMember(string idStr)
        {
            throw new NotImplementedException();
        }

        public User searchMember(int id)
        {
            throw new NotImplementedException();
        }
    }
}

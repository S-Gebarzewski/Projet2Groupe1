namespace Projet2Groupe1.Models
{
    public class MemberService : IMemberService
    {
        private DataBaseContext _dbContext;

        public MemberService(DataBaseContext _dbContext) 
        {
            this._dbContext = _dbContext;
        }

        // Recupere les informations du formulaire d'inscription
        // adherent pour l'enregistrer en BDD

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

        //Recupere une l'id String depuis l'URL
        //et fait une recuperation en BDD du member correspondant
        public Member GetMember(int id)
        {
            return _dbContext.Members.Find(id);
        }

        //Recupere un id de type String depuis l'URL
        //et le tranforme em type int et relance GetMember avec un int
        public Member GetMember(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetMember(id);
            }
            return null;
        }

        // Recupere un membre, reecris toutes ses informations et
        // l'enregsitre avec ses nouvelles informations
        public Member UpdateMember(Member UpdatingMember)
        {
            Member ExistingMember = GetMember(UpdatingMember.Id);

            ExistingMember.Age = UpdatingMember.Age;
            ExistingMember.City = UpdatingMember.City;
            ExistingMember.ZipCode = UpdatingMember.ZipCode;
            ExistingMember.IsPremium = UpdatingMember.IsPremium;
            ExistingMember.IsPayed = UpdatingMember.IsPayed;
            ExistingMember.UserId = UpdatingMember.UserId;

            _dbContext.Members.Update(ExistingMember);
            _dbContext.SaveChanges();

            return ExistingMember;
        }
        public Member searchMember(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}

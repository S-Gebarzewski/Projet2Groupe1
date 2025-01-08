namespace Projet2Groupe1.Models
{
    public class Organizer
    {
        public int Id { get; set; }
       public  string Function { get; set; }   
       public  string Denomination { get; set; }
        public string RIB { get; set; }   
       public  Adress Adress { get; set; }
        public int UserId {  get; set; }    
        //String file = "C:\\Users\\Naciim\\Desktop\\Isika\\.NET\\Projet2Groupe1\\Projet2Groupe1\\wwwroot\\Documents\";

    }
}

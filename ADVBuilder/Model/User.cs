namespace ADVBuilder.Model
{
    public class User
    {
        public int Id { get; set; }             //Identificativo Utente
        public int IdAdv { get; set; }          //Id adv in uso
        public string Name { get; set; }        //Nome Utente
        public string Surname { get; set; }     //Cognome Utente
        public string UserName { get; set; }     //Username per l'accesso
        public string Password { get; set; }     //Password
    }
}
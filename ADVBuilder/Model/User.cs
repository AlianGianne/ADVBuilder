using System.Collections.Generic;

namespace ADVBuilder.Model
{
    public class User
    {
        public int Id { get; set; }             //Identificativo Utente
        public int IdAdv { get; set; }          //Id adv in uso
        public string Name { get; set; } = "Virtuoso";      //Nome Utente
        public string Surname { get; set; } = "Semprettorio";  //Cognome Utente
        public string UserName { get; set; } = "SemVir";     //Username per l'accesso
        public string Password { get; set; }     //Password
        public AdventureData ADD { get; set; } = new AdventureData();  //Avventura giocata
        public int Points { get; set; } = 1;        //Punteggio avventura
        public List<CharactersData> CharactersMeet { get; set; } = new List<CharactersData>();        //Personaggi incontrati
        public List<CharactersData> CharactersSpeek { get; set; } = new List<CharactersData>();         //Personaggi con cui si è parlato
        public List<RoomData> RoomsVisited { get; set; } = new List<RoomData>();         //Stanze visitate
        public List<ObjectsData> ObjectsInteract { get; set; } = new List<ObjectsData>();        //Oggetti con cui si è interragito
        public void AddRoom(RoomData pRoom)
        {
            if(!RoomsVisited.Contains(pRoom)) RoomsVisited.Add(pRoom);
        }
        public void AddCharacterMeet(CharactersData pCharacter)
        {
            if (!CharactersMeet.Contains(pCharacter)) CharactersMeet.Add(pCharacter);
        }
        public int RoomsVisitedCount()
        {
            return RoomsVisited.Count + 1;
        }
        public int CharactersMeetCount()
        {
            return CharactersMeet.Count + 1;
        }
        public int Force { get; set; } = 0;
        public int Wisdom { get; set; } = 0;
        public int Physique { get; set; } = 0;
        public int Dexterity { get; set; } = 0;
        public int Smartness { get; set; } = 0;
        public int Experience { get; set; } = 0;
        public int Life { get; set; } = 0;
        public int Mana { get; set; } = 0;
    }
}
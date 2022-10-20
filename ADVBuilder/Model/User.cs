using ADVBuilder.Model.Abstryact;
using System.Collections.Generic;
using System.Linq;

namespace ADVBuilder.Model
{
    public class User : CharProperties
    {
        public CharacterSkills Skills { get; set; } = new CharacterSkills();
        public int Id { get; set; }             //Identificativo Utente
        public int IdAdv { get; set; }          //Id adv in uso
        public string Name { get; set; } = "Virtuoso";      //Nome Utente
        public string Surname { get; set; } = "Semprettorio";  //Cognome Utente
        public string UserName { get; set; } = "SemVir";     //Username per l'accesso
        public string Password { get; set; }     //Password
        public AdventureData ADD { get; set; } = new AdventureData();  //Avventura giocata
        public List<ObjectsData> Inventario { get; set; } = new List<ObjectsData>();

        public int Points { get; set; } = 1;        //Punteggio avventura
        public List<CharactersData> CharactersMeet { get; set; } = new List<CharactersData>();        //Personaggi incontrati
        public List<CharactersData> CharactersSpeek { get; set; } = new List<CharactersData>();         //Personaggi con cui si è parlato
        public List<RoomData> RoomsVisited { get; set; } = new List<RoomData>();         //Stanze visitate
        public List<ObjectsData> ObjectsInteract { get; set; } = new List<ObjectsData>();        //Oggetti con cui si è interragito
        public void AddRoom(RoomData pRoom)
        {
            if (RoomsVisited.Where(r => r.Id == pRoom.Id).ToList().Count < 1) RoomsVisited.Add(pRoom);
        }
        public void AddCharacterMeet(CharactersData pCharacter)
        {
            if (CharactersMeet.Where(c => c.Id == pCharacter.Id).ToList().Count < 1) CharactersMeet.Add(pCharacter);
        }
        public int RoomsVisitedCount()
        {
            return RoomsVisited.Count + 1;
        }
        public int CharactersMeetCount()
        {
            return CharactersMeet.Count + 1;
        }
    }
}
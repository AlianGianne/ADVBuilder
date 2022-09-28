using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADVBuilder.Model;

namespace ADVBuilder.ActionsClass_New
{
    public class Info : aActions, iActions
    {
        public Info(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            switch (Dialog)
            {
                case 0:         //Non Visualizzre dialogo
                case 2:         //Risposta positiva
                    Response.Success = false;
                    Response.Value = 0;
                    break;
                case 1:         //Visualizza dialogo
                case -1:
                    Response.Message = string.Format("Titolo:\t\t{0}{3}Sotto Titolo:\t{1}{3}Versione:\t\t{4}{3} Autore:\t\t{2}{3}",
                        ADD.Title, ADD.SubTitle, ADD.Author, Environment.NewLine, ADD.Version);
                    Response.Success = false;
                    Response.Value = "SHOW";
                    break;
                case 3:         //Risposta negativa
                    Response.Message = "Operazione annullata dall'utente";
                    Response.Success = false;
                    Response.Value = 0;
                    break;
            }
            return Response;
        }
    }
}

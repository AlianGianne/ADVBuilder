using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADVBuilder.Model;

namespace ADVBuilder.ActionsClass_New
{
    class End : aActions, iActions
    {
        public End(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            switch (Dialog)
            {
                case 0:         //Non Visualizzre dialogo
                case 2:         //Risposta positiva
                    Response.Value = "END";
                    break;
                case 1:         //Visualizza dialogo
                    Response.Message = string.Format(
                        "Se chiudi la partita, perderai gli avanzamenti fatti fin'ora.{0}Continuare?"
                        , Environment.NewLine);
                    Response.Success = false;
                    Response.Value = "SHOW";
                    break;
                case 3:         //Risposta negativa
                    Response.Message = "Operazione annullata dall'utente!";
                    Response.Success = false;
                    Response.Value = 0;
                    break;
            }
            
            return Response;
        }
    }
}

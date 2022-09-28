using ADVBuilder.Model;

using System.Collections.Generic;

namespace ADVBuilder.ActionsClass_New
{
    public class Unable : aActions, iActions
    {
        public Unable(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
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
                    Response.Message = "Non ancora implementato!";
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
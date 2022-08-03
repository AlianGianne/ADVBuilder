using ADVBuilder.Model;

using System.Collections.Generic;

namespace ADVBuilder.ActionsClass_New
{
    internal class Examinate : aActions, iActions
    {
        public Examinate(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Object = pObj;
            Room = pRoom;
            Response.Message = SetMessage();
            return Response;
        }

        private string SetMessage()
        {
            Response.Success = Object != null;
            return Response.Success ? Object.Description : "Seleziona qualcosa da guardare...";
        }
    }
}
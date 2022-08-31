using ADVBuilder.Model;
using System;
using System.Collections.Generic;

namespace ADVBuilder.ActionsClass_New
{
    internal class Examinate : aActions, iActions
    {
        public Examinate(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Object = pObj;
            Room = pRoom;
            Character = pCharacter;
            Response.Message = SetMessage();
            return Response;
        }

        private string SetMessage()
        {
            Response.Success = Object != null;
            if(Response.Success) return Response.Success ? Object.Description : "Seleziona qualcosa da esaminare...";
            Response.Success = Character != null;
            return Response.Success ? string.Format("{0}{3}Stato:\t{1}{3}Vita:\t{2}{3}", Character.Description, Character.Status, Character.LifePoint, Environment.NewLine) : "Seleziona qualcosa da esaminare...";
        }
    }
}
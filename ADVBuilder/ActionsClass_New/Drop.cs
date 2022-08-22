﻿using ADVBuilder.Model;

using System.Collections.Generic;

namespace ADVBuilder.ActionsClass_New
{
    internal class Drop : aActions, iActions
    {
        public Drop(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Object = pObj;
            Complement = pCmp;
            Room = pRoom;
            if (Object == null)
            {
                Response.Success = false;
                Response.Message = "Seleziona l'oggetto da lasciare!";
                Response.Value = 0;
            }
            else
            {
                Exec();
            }
            return Response;
        }

        private void Exec()
        {
            Object.IdRoom = Room.Id;
            Room.Objects.Add(Object);
            Response.Success = Inventario.Remove(Object);
            Response.Message = SetMessage();
            Response.Value = 0;
            Object = null;
            Room = null;
        }

        private string SetMessage()
        {
            return Response.Success ? string.Format("Oggetto {0} lasciato.", Object.Title) : "Errore";
        }
    }
}
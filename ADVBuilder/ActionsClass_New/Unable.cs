﻿using ADVBuilder.Model;

using System.Collections.Generic;

namespace ADVBuilder.ActionsClass_New
{
    public class Unable : aActions, iActions
    {
        public Unable(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Response.Message = "Non ancora implementato";
            Response.Value = 0;
            Response.Success = true;
            return Response;
        }
    }
}
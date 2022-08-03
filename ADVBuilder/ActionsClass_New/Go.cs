using ADVBuilder.Common;
using ADVBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ADVBuilder.ActionsClass_New
{
    internal class Go : aActions, iActions
    {
        public Go(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Type myType = typeof(RoomData);
            PropertyInfo myPropInfo = myType.GetProperty(ADD.Direction);

            ObjectsData door = pRoom.Objects.Where(o => o.Position == ADD.Direction).FirstOrDefault();
            if (door == null || door.Status == cCommon.STATUS_OPEN)
            {
                ADD.CurrentRoom = int.Parse(myPropInfo.GetValue(pRoom, null).ToString());
                Response.Value = ADD.CurrentRoom;
                Response.Message = SetMessage(ADD.Direction);
            }
            else
            {
                Response.Success = false;
                Response.Message = "La porta è chiusa!";
            }
            return Response;
        }

        private string SetMessage(string pDirection)
        {
            Response.Success = true;
            return string.Format("Prosegui verso {0}", cCommon.GetDirectionText(pDirection));
        }
    }
}
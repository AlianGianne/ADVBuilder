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
            if (door == null || door.Status == cCommon.STATUS_OPEN || door.Status == cCommon.STATUS_STATIC)
            {
                //Nel caso servano scale
                if (ADD.Direction == "AA" || ADD.Direction == "BB")
                {
                    ObjectsData chair = pRoom.Objects.Where(o => o.Position == ADD.Direction && o.Action == cCommon.ACTION_RISE).FirstOrDefault();
                    if (chair == null) chair = Inventario.Where(o => o.Action == cCommon.ACTION_RISE).FirstOrDefault();

                    if (chair != null)
                    {
                        ADD.CurrentRoom = int.Parse(myPropInfo.GetValue(pRoom, null).ToString());
                        Response.Value = ADD.CurrentRoom;
                        Response.Message = SetMessage(ADD.Direction);
                    }
                    else
                    {
                        Response.Success = false;
                        Response.Message = "Non puoi usare il passaggio per salire o scendere. Hai bisogno di una scala, è troppo alto!";
                    }
                }
                else
                {
                    ADD.CurrentRoom = int.Parse(myPropInfo.GetValue(pRoom, null).ToString());
                    Response.Value = ADD.CurrentRoom;
                    Response.Message = SetMessage(ADD.Direction);
                }
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
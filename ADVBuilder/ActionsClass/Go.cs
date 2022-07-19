using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ADVBuilder.Common;
using ADVBuilder_1.Model;

namespace ADVBuilder.ActionsClass
{
    public class Go : aActions, iActions
    {
        public Response Execute(ObjectsData pObj, ObjectsData pCmp, RoomData pRoom, List<ObjectsData> pInventario)
        {
            return Response;
        }

        public Response Execute(AdventureData ADD, RoomData pRoom, string pDirection, ref int pRoomIdSelected)
        {
            
            Type myType = typeof(RoomData);
            PropertyInfo myPropInfo = myType.GetProperty(pDirection);

            ObjectsData obj = pRoom.Objects.Where(o => o.Position == pDirection).FirstOrDefault();
            if (obj == null || (obj!=null && obj.Status == cCommon.STATUS_OPEN))
            {
                ADD.CurrentRoom = int.Parse(myPropInfo.GetValue(pRoom, null).ToString());
                pRoomIdSelected = ADD.CurrentRoom;
                Response.Message = SetMessage(pDirection);
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
            return string.Format("Prosegui verso {0}", pDirection);
        }
    }
}

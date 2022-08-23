using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADVBuilder.Model;
using Newtonsoft.Json;

namespace ADVBuilder.ActionsClass_New
{
    public class Load : aActions, iActions
    {
        public Load(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            using (StreamReader r = new StreamReader(string.Format("{0}_Save.jsn", ADD.Title)))
            {
                string json = r.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<AdventureData>(json);
                ADD.CurrentRoom = obj.CurrentRoom;
                ADD.Direction = obj.Direction;
                ADD.Rooms = obj.Rooms;
            }
            using (StreamReader r = new StreamReader(string.Format("{0}_Inve.jsn", ADD.Title)))
            {
                string json = r.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<List<ObjectsData>>(json);
                Inventario.RemoveRange(0, Inventario.Count());
                foreach (var o in obj) Inventario.Add(o);
            }
            return Response;
        }
    }
}

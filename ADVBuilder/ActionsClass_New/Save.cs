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
    public class Save : aActions, iActions
    {
        public Save(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }
        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            using (StreamWriter file = File.CreateText(string.Format("{0}_Save.jsn", ADD.Title)))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, ADD);
            }
            using (StreamWriter file = File.CreateText(string.Format("{0}_Inve.jsn", ADD.Title)))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Inventario);
            }
            return Response;
        }
    }
}

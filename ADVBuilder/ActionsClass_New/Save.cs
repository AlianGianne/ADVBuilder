using System.Collections.Generic;
using System.IO;
using ADVBuilder.Model;
using Newtonsoft.Json;

namespace ADVBuilder.ActionsClass_New
{
    public class Save : aActions, iActions
    {
        public Save(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
        {
        }
        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            using (StreamWriter file = File.CreateText(string.Format("{0}_Save.jsn", ADD.Title)))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, User);
            }
            
            return Response;
        }
    }
}

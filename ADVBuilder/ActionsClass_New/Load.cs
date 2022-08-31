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
        public Load(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            using (StreamReader r = new StreamReader(string.Format("{0}_Save.jsn", ADD.Title)))
            {
                string json = r.ReadToEnd();

                Response.Value = JsonConvert.DeserializeObject<User>(json);
                
            }
            
            return Response;
        }
    }
}

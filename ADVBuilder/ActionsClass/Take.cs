using ADVBuilder_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass
{
    /// <summary>
    /// 
    /// </summary>
    public class Take : iActions
    {
        public Response Response { get; set; } = new Response();
        public Response Execute(ObjectsData pObj, RoomData pRoom)
        {
            
            return Response;
        }

        
    }
}

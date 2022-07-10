using ADVBuilder_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass
{
    public interface iActions
    {
        //string Name;
        Response Execute(ObjectsData pObj);
    }
}

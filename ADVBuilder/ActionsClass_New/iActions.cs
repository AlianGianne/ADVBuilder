using ADVBuilder.Model;
using ADVBuilder_1.Model;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass_New
{
    /// <summary>
    /// 
    /// </summary>
    public interface iActions
    {
        /// <summary>
        /// Esegue l'azione preposta
        /// </summary>
        /// <param name="pObj">Oggetto che esegue l'azione</param>
        /// <param name="pCmp">Oggetto che subisce l'azione</param>
        /// <param name="pRoom">Stanza di riferimento</param>
        /// <returns></returns>
        Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom);
    }
}

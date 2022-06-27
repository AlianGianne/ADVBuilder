using System.Collections.Generic;
using System.Reflection;

namespace Gema2022.CommonClass
{
    [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Struct)]
    internal class cAttributes : System.Attribute
    {
        public string Name;
    }

    /// <summary>
    /// Legge gli attributi della classe e/o proprietà
    /// </summary>
    public static class cGetAttributes
    {
        /// <summary>
        /// Restituisce il nome dell'attributo associato alla proprietà
        /// </summary>
        /// <param name="t">Tipo dell'attributo richiesto</param>
        /// <returns>Nome Dell'attributo</returns>
        public static string GetName(System.Type t)
        {
            string ret = "";
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);
            foreach (System.Attribute attr in attrs)
            {
                if (attr is cAttributes)
                {
                    cAttributes a = (cAttributes)attr;
                    ret = a.Name;
                }
            }
            return ret;
        }

        /// <summary>
        /// Restituisce la proprietà in base all'attributo
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static IList<PropertyInfo> GetAttributes(System.Type t)
        {
            return new List<PropertyInfo>(t.GetProperties());
        }
    }
}
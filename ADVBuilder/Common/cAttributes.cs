using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gema2022.CommonClass
{
    [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Struct)]
    class cAttributes : System.Attribute
    {
        public string Name;
    }
    public static class cGetAttributes
    {
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
        public static IList<PropertyInfo> GetAttributes(System.Type t)
        {
            return new List<PropertyInfo>(t.GetProperties());
        }
    }
}

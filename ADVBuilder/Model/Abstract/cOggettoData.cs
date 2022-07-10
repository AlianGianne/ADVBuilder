using Gema2022.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gema2022.Class
{
    public abstract class cOggettoData : cData
    {
        public string PercorsoFileXml = "";
        public string SELECT = "Select";
        public string INSERT = "Insert";
        public string UPDATE = "Update";
        public string DELETE = "Delete";

        public DataTable Table { get; set; }

        public cOggettoData()
        {

        }
        public void ReadData()
        {
            readData();
        }
        public void Settings(string queryName)
        {
            PercorsoFileXml = string.Format("Data/Query/{0}.xml", queryName);
        }
        public List<T> ReadList<T>(List<T> list)
        {
            if (Table != null)
            {
                if (Table.Rows.Count > 0)
                {
                    if (list != null)
                    {
                        list.Clear();
                        foreach (DataRow r in Table.Rows)
                        {
                            Type type = typeof(T);
                            T obj = (T)Activator.CreateInstance(type);
                            var a = cGetAttributes.GetAttributes(type);
                            foreach (PropertyInfo prop in a)
                            {
                                if (prop.CustomAttributes.Count() > 0)
                                    prop.SetValue(obj, Convert.ChangeType(r[prop.Name], prop.PropertyType));
                            }
                            list.Add(obj);
                        }
                    }
                }
            }
            return list;
        }
        private void readData()
        {
            if (Open())
            {
                Table = ExecuteQuery(SELECT, new Dictionary<string, object>(), PercorsoFileXml);
                Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="data"></param>
        public void StoreData(object data)
        {
            string qry;
            Dictionary<string, object> values = new Dictionary<string, object>();

            if (Open())
            {
                Type type = data.GetType();
                var a = cGetAttributes.GetAttributes(type);
                foreach (PropertyInfo prop in a)
                {
                    values.Add(prop.Name, prop.GetValue(data));
                }
            }
            qry = int.Parse(values["Id"].ToString()) > 0 ? UPDATE : INSERT;
            ExecuteNonQuery(qry, values, PercorsoFileXml);
        }
        public void InsertData(object data)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            if (Open())
            {
                Type type = data.GetType();
                var a = cGetAttributes.GetAttributes(type);
                foreach (PropertyInfo prop in a)
                {
                    values.Add(prop.Name, prop.GetValue(data));
                }

                ExecuteNonQuery(INSERT, values, PercorsoFileXml);
            }
        }
        public void UpdateData(object data)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            if (Open())
            {
                Type type = data.GetType();
                var a = cGetAttributes.GetAttributes(type);
                foreach (PropertyInfo prop in a)
                {
                    values.Add(prop.Name, prop.GetValue(data));
                }

                ExecuteNonQuery(UPDATE, values, PercorsoFileXml);
            }
        }
        public void DeleteData(int Id)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            if (Open())
            {
                values.Add("Id", Id);

                ExecuteNonQuery(DELETE, values, PercorsoFileXml);
            }
        }
        public List<T> ReadParamForObj<T>(List<T> list, Panel pPanel)
        {
            if (list != null)
            {
                Type type = typeof(T);
                T obj = (T)Activator.CreateInstance(type);
                list.Clear();
                foreach (var c in pPanel.Controls.OfType<TextBox>())
                {
                    var a = cGetAttributes.GetAttributes(type);
                    foreach (PropertyInfo prop in a)
                    {
                        if (prop.CustomAttributes.Count() > 0)
                            if (prop.CustomAttributes.First().NamedArguments[0].TypedValue.Value.ToString() == c.Name.Substring(3))
                                prop.SetValue(obj, Convert.ChangeType(c.Text, prop.PropertyType));
                    }

                }
                foreach (var c in pPanel.Controls.OfType<ComboBox>())
                {
                    var a = cGetAttributes.GetAttributes(type);
                    foreach (PropertyInfo prop in a)
                    {
                        if (prop.CustomAttributes.Count() > 0)
                            if (prop.CustomAttributes.First().NamedArguments[0].TypedValue.Value.ToString() == c.Name.Substring(3))
                                prop.SetValue(obj, Convert.ChangeType(c.SelectedValue ?? "0", prop.PropertyType));
                    }

                }
                list.Add(obj);
            }
            return list;
        }
        public void ReadParamForForm<T>(T pObj, Panel pPanel, int pId)
        {
            Type type = typeof(T);
            T obj = (T)Activator.CreateInstance(type);
            obj = pObj;
            foreach (var c in pPanel.Controls.OfType<TextBox>())
            {
                var a = cGetAttributes.GetAttributes(type);
                foreach (PropertyInfo prop in a)
                {
                    if (prop.CustomAttributes.Count() > 0)
                        if (prop.CustomAttributes.First().NamedArguments[0].TypedValue.Value.ToString() == c.Name.Substring(3))
                            c.Text = prop.GetValue(obj).ToString();
                }
            }
            foreach (var c in pPanel.Controls.OfType<ComboBox>())
            {
                var a = cGetAttributes.GetAttributes(type);
                foreach (PropertyInfo prop in a)
                {
                    if (prop.CustomAttributes.Count() > 0)
                        if (prop.CustomAttributes.First().NamedArguments[0].TypedValue.Value.ToString() == c.Name.Substring(3))
                        {
                            c.SelectedValue = int.Parse(prop.GetValue(obj).ToString());
                        }
                }
            }

        }
    }
}

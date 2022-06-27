using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Gema2022.Class
{
    public abstract class cData
    {
        public string ConnectionString { get; set; } = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Data\\ADVBuilder.mdf;Integrated Security=True";
        //public string ConnectionString { get; set; } = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Lavoro\\Gianne\\CalcCorr\\Gema2022\\Gema2022\\StockMan.mdf;Integrated Security=True"; 
        private SqlConnection connection = new SqlConnection();
        public cData()
        {

        }
        public cData(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public bool Open()
        {
            bool ret = true;
            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
            }
            catch(Exception ex)
            {
                connection.Dispose();
                ret = false;
            }
            return ret;
        }
        public bool Close()
        {
            bool ret = true;
            try
            {
                connection.Close();
            }
            catch
            {
                connection.Dispose();
                ret = false;
            }
            return ret;
        }
        /// <summary>
        /// Restituisce i dati richiesti in query in formato DataTable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string queryName, Dictionary<string, object> values, string percorsoFileXml)
        {
            DataTable dataTable;
            SqlDataAdapter dataAdapter;
            SqlCommand command;

            dataTable = new DataTable();
            dataAdapter = new SqlDataAdapter();

            

            command = new SqlCommand();
            command.CommandText = GetCommandQuery(queryName, percorsoFileXml);
            command.Connection = connection;

            ParametersAdd(command, values);

            try
            {
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            return dataTable;
        }
        public void ExecuteNonQuery(string queryName, Dictionary<string, object> values, string percorsoFileXml)
        {
            SqlCommand command;

            try
            {
                command = new SqlCommand();
                command.Connection = connection;

                ParametersAdd(command, values);

                command.CommandText = GetCommandQuery(queryName, percorsoFileXml);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        #region "Helpers"
        private void ParametersAdd(SqlCommand command, Dictionary<string, object> values)
        {
            foreach (KeyValuePair<string, object> entry in values)
            {
                ParameterAdd(command, entry.Key, entry.Value);
            }
        }
        private void ParameterAdd(SqlCommand command, string name, object value)
        {
            if (value != null)
            {
                command.Parameters.AddWithValue(name, value);
            }
            else
            {
                command.Parameters.AddWithValue(name, DBNull.Value);
            }
        }
        public string GetCommandQuery(string queryName, string percorsoFileXml)
        {
            try
            {
                //Creo il comando
                string command = string.Empty;
                //Carico il file .xml
                XmlDocument document = new XmlDocument();
                document.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, percorsoFileXml));

                XmlNode queryNode = null;

                queryNode = document.SelectSingleNode("ROOT/" + queryName);

                //Recupero il testo della query e lo imposto nel comando
                //document.SelectSingleNode("ROOT/" + queryName)).InnerText.
                command = (queryNode).InnerText.Replace("\n", "").Replace("\r", "").Trim();
                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

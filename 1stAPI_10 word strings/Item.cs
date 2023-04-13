using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.Serialization.Formatters;
using System.Xml.Linq;

namespace _1stAPI_10_word_strings
{
    public class Item
    {

        string word = "";
        string type = "";
        
        public string Ejson = new WebClient().DownloadString("https://wordapidata.000webhostapp.com/?getnamesenglish");



        public string Xjson = new WebClient().DownloadString("https://wordapidata.000webhostapp.com/?getnamesxhosa");



        public string Ajson = new WebClient().DownloadString("https://wordapidata.000webhostapp.com/?getnamesafrikaans");

        //public class Words
        //    {
        //        string word { get; set; }
               
        //    }

        public string PostNames()
        {
            string[] Enames = Ejson.Split(',');
            string[] Xnames = Xjson.Split(',');
            string[] Anames = Ajson.Split(',');

            for (int i = 0; i < Enames.Length; i++)
            {
                word = Enames[i].Trim(new Char[] { '"', '[', ']' });
                type = "English";
                SendData();
            }

            for (int i = 0; i < Anames.Length; i++)
            {
                word = Anames[i].Trim(new Char[] { '"', '[', ']' });
                type = "Afrikaans";
                SendData();
            }

            for (int i = 0; i < Xnames.Length; i++)
            {
                word = Xnames[i].Trim(new Char[] { '"', '[', ']' });
                type = "Xhosa";
                SendData();
            }

            
            return "Data Sent";
        }
        public string connStr = "Data Source = st10085138server.database.windows.net; Initial Catalog = WordStringAPI; user = cka00; password = Password01"; //connect string for database
      
        public SqlCommand dbComm;
        public SqlDataAdapter dbAdapter;
        public SqlDataReader dataReader;
        public DataTable dt;

        public void SendData()
        {

            SqlConnection dbConn = new SqlConnection(connStr);


            dbConn.Open();

            //sql code to insert into table
            string sql = "spInsert";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

         

                dbComm.Parameters.AddWithValue("@Name",word);
                dbComm.Parameters.AddWithValue("@Type", type);
               
            

           

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

        }

        
       //public string[] GetWords() get all words, need to get languages seperately
       // {
       //     int len = Ejson.Split(',').Length + Ajson.Split(',').Length + Xjson.Split(',').Length;
       //     string[] word = new string[len];
       //     SqlConnection dbConn = new SqlConnection(connStr);


       //     dbConn.Open();

           
       //     string sql = "spGetWords";
       //     dbComm = new SqlCommand(sql, dbConn);
       //     dbComm.CommandType = CommandType.StoredProcedure;

            

       //     dataReader = dbComm.ExecuteReader();
       //     int i = 0;
          
       //     while (dataReader.Read())
       //     {
       //         word[i]  = dataReader.GetValue(0).ToString();
       //         i++;
       //     }

          
       //     dataReader.Close();
       //     int x = dbComm.ExecuteNonQuery();

           
       //     dbConn.Close();
       //     return word;
       // }
    }
}

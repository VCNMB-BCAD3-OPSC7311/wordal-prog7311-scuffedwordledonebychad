using System;
using System.Data;
using System.Data.SqlClient;

namespace _1stAPI_10_word_strings
{
    public class EngWords : IWords
    {
        
       
        public string[] GetWords()
        {
            Item db = new Item();

            SqlConnection dbConn = new SqlConnection(db.connStr);


            dbConn.Open();


            string sql = "spGetEngWords";
            db.dbComm = new SqlCommand(sql, dbConn);
            db.dbComm.CommandType = CommandType.StoredProcedure;



            db.dataReader = db.dbComm.ExecuteReader();
            int i = 0;
            List<string> words = new List<string>();
            while (db.dataReader.Read())
            {
               words.Add(db.dataReader.GetValue(0).ToString());
               
            }

            string[] word = words.ToArray();

            db.dataReader.Close();
            int x = db.dbComm.ExecuteNonQuery();


            dbConn.Close();
            return word;
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestDeveloper
{
    public class DB
    {
       public static string sqlDataSource = "Data Source=.;Initial Catalog=TestDev ; User ID=sa1;Password=Thank$123; Integrated Security=True;";
  
        public DataTable GetData(string str)
        {
            DataTable objresutl = new DataTable();
            try
            {
                SqlDataReader myReader;

                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(str, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        objresutl.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }

            return objresutl;

        }
        public int ExecuteData(string str, params IDataParameter[] sqlParams)
        {
            int rows = -1;
            try
            {

                using (SqlConnection conn = new SqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(str, conn))
                    {
                        if (sqlParams != null)
                        {
                            foreach (IDataParameter para in sqlParams)
                            {
                                cmd.Parameters.Add(para);
                            }
                            rows = cmd.ExecuteNonQuery();
                        }





                    }
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }


            return rows;



        }
    }
}

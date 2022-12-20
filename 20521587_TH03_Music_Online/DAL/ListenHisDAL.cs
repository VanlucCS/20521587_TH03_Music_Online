using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20521587_TH03_Music_Online.DAL
{
    class ListenHisDAL
    {
        #region Select method
        public DataTable Select()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString))
                {
                    if (cnn.State == ConnectionState.Closed)
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM LISTENHIS", cnn))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");
                throw;
            }

            return dt;
        }
        #endregion
        #region insert listensong
        public bool Insert(string mabh)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            //Sql Connection for DAtabase
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString);

            try
            {
                //SQL Query to insert product into database
                //String sql = @"INSERT INTO PLAYLIST (MAPL,TENPL,MABH,THOIGIANTAO) " +
                //                "VALUES (@MAPL,@TENPL,@MABH,@THOIGIANTAO)";
                String sql = @"INSERT INTO LISTENHIS (MABH,SOLAN,THOIGIAN) " +
                                "VALUES (@MABH,@SOLAN,@THOIGIAN)";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@MABH", mabh);
                cmd.Parameters.AddWithValue("@SOLAN", 1);
                cmd.Parameters.AddWithValue("@THOIGIAN", DateTime.Now);

                //Opening the Database connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then the value of rows will be greater than 0 else it will be less than 0
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                    //MessageBox.Show("a");
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
        #region update listen song
        public bool Update(string mabh,int soLan)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            //Sql Connection for DAtabase
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString);

            try
            {
                String sql = @"UPDATE LISTENHIS SET SOLAN = @SOLAN,THOIGIAN = @THOIGIAN WHERE MABH = @MABH; ";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@SOLAN", soLan);
                cmd.Parameters.AddWithValue("@MABH", mabh);
                cmd.Parameters.AddWithValue("@THOIGIAN", DateTime.Now);

                //Opening the Database connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then the value of rows will be greater than 0 else it will be less than 0
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //FAiled to Execute Query
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
    }
}

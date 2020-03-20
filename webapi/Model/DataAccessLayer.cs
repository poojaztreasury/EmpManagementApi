using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using webapi.Utility;


namespace webapi.Model
{
    public class DataAccessLayer
    {
        String connectionString = ConnectionString.CName;
        public IEnumerable<EmpModel> GetAllEmp()
        {
            List<EmpModel> lstemp = new List<EmpModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("showemp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    EmpModel em = new EmpModel();
                    em.empid = Convert.ToInt32(rdr[0]);
                    em.empname = rdr[1].ToString();
                    em.empemail = rdr[2].ToString();
                    em.emphomeadd = rdr[3].ToString();
                    em.empdep = rdr[4].ToString();
                    em.empphone = string.IsNullOrEmpty(rdr[5].ToString()) ? (int?)null : Convert.ToInt32(rdr[5]);
                    em.emprepmanager = rdr[6].ToString();
                    em.empofficeadd = rdr[7].ToString();
                    em.IsDeleted = (rdr[8]).ToString();
                    em.IsActive = (rdr[9]).ToString();
                    em.addedby = rdr[10].ToString();
                    em.addedon = Convert.ToDateTime(rdr[11]);
                    em.modifiedby = rdr[12].ToString();
                    em.modifiedon = Convert.ToDateTime(rdr[13]);


                    lstemp.Add(em);
                }
                con.Close();
            }
            return lstemp;
        }

        public Int32 AddEmp(EmpModel emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_emp_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", emp.empid);
                cmd.Parameters.AddWithValue("@en", emp.empname);
                cmd.Parameters.AddWithValue("@email", emp.empemail);
                cmd.Parameters.AddWithValue("@ehadd", emp.emphomeadd);
                cmd.Parameters.AddWithValue("@eoadd", emp.empofficeadd);
                cmd.Parameters.AddWithValue("@edep", emp.empdep);
                cmd.Parameters.AddWithValue("@ephone", emp.empphone);
                cmd.Parameters.AddWithValue("@emanager", emp.emprepmanager);
                cmd.Parameters.AddWithValue("@isdel", emp.IsDeleted);
                cmd.Parameters.AddWithValue("@isactive", emp.IsActive);
                // cmd.Parameters.AddWithValue("@addedby", emp.addedby);
                //  cmd.Parameters.AddWithValue("@addedon", emp.addedon);
                cmd.Parameters.AddWithValue("@modifiedby", emp.modifiedby);

                cmd.Parameters.AddWithValue("@modifiedon", emp.modifiedon);
                cmd.Parameters.Add("@ret", SqlDbType.Int);
                cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
                con.Open();
                // cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Int32 k = Convert.ToInt32(cmd.Parameters["@ret"].Value);
                con.Close();
                cmd.Dispose();
                return k;

            }


        }
        public Int32 UpdateEmp(EmpModel emp,int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("update_emp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", id);
                cmd.Parameters.AddWithValue("@en", emp.empname);

                cmd.Parameters.AddWithValue("@email", emp.empemail);
                cmd.Parameters.AddWithValue("@ehadd", emp.emphomeadd);
                cmd.Parameters.AddWithValue("@eoadd", emp.empofficeadd);
                cmd.Parameters.AddWithValue("@edep", emp.empdep);
                cmd.Parameters.AddWithValue("@ephone", emp.empphone);
                cmd.Parameters.AddWithValue("@emanager", emp.emprepmanager);
                cmd.Parameters.AddWithValue("@isdel", emp.IsDeleted);
                cmd.Parameters.AddWithValue("@isactive", emp.IsActive);
                
               
                cmd.Parameters.AddWithValue("@modifiedby", emp.modifiedby);

                cmd.Parameters.AddWithValue("@modifiedon", emp.modifiedon);
                cmd.Parameters.Add("@ret", SqlDbType.Int);
                cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
                con.Open();
                // cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Int32 k = Convert.ToInt32(cmd.Parameters["@ret"].Value);
                con.Close();
                cmd.Dispose();
                return k;

            }
        }
        public EmpModel FindEmp(int id)
        {
            EmpModel em = new EmpModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("findemp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@eid", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    em.empid = Convert.ToInt32(rdr[0]);
                    em.empname = rdr[1].ToString();
                    em.empemail = rdr[2].ToString();
                    em.emphomeadd = rdr[3].ToString();
                    em.empdep = rdr[4].ToString();
                    em.empphone = string.IsNullOrEmpty(rdr[5].ToString()) ? (int?)null : Convert.ToInt32(rdr[5]);
                    em.emprepmanager = rdr[6].ToString();
                    em.empofficeadd = rdr[7].ToString();
                    em.IsDeleted = (rdr[8]).ToString();
                    em.IsActive = (rdr[9]).ToString();
                    em.addedby = rdr[10].ToString();
                    em.addedon = Convert.ToDateTime(rdr[11]);
                    em.modifiedby = rdr[12].ToString();
                    em.modifiedon = Convert.ToDateTime(rdr[13]);



                }
                con.Close();
            }
            
            return em;
        }
        public Int32 DelEmp(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("delete_emp",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", id);
                cmd.Parameters.Add("@ret", SqlDbType.Int);
                cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
                con.Open();
                cmd.ExecuteNonQuery();
                Int32 k = Convert.ToInt32(cmd.Parameters["@ret"].Value);
                con.Close();
                cmd.Dispose();
                return k;

            }

        }

        public Int32 logincheck(UserModel um)
        {
            Int32 k;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                SqlCommand cmd = new SqlCommand("login_tbuser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@un", um.username);
                cmd.Parameters.AddWithValue("@up", um.Password);
                cmd.Parameters.Add("@ap", SqlDbType.Int);
                cmd.Parameters["@ap"].Direction = ParameterDirection.ReturnValue;
                con.Open();
                cmd.ExecuteNonQuery();
                 k = Convert.ToInt32(cmd.Parameters["@ap"].Value);
                cmd.Dispose();

                con.Close(); 

            }
            return k;
            
        }  

        public Int32 AddUser(UserModel um)
        {
            Int32 k;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("insert_tbuser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@un", um.username);
                cmd.Parameters.AddWithValue("@up", um.Password);
                cmd.Parameters.Add("@ret", SqlDbType.Int);
                cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
                con.Open();
                cmd.ExecuteNonQuery();
                k = Convert.ToInt32(cmd.Parameters["@ret"].Value);
                cmd.Dispose();

                con.Close();

            }
            return k;


        }   

        
        
            public IEnumerable<TempCardModel> GetTempCardDetails()
            {
                List<TempCardModel> lstcard = new List<TempCardModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("tempcard_display", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                    TempCardModel tm = new TempCardModel();
                    tm.tempno = Convert.ToInt32(rdr[0]);
                    tm.empid = Convert.ToInt32(rdr[1]);
                    tm.tempcardno = Convert.ToInt32(rdr[2]);
                    tm.IsDeleted = Convert.ToBoolean(rdr[3]);
                    tm.IsActive = Convert.ToBoolean(rdr[4]);
                    tm.addedby = rdr[5].ToString();
                    tm.addedon = Convert.ToDateTime(rdr[6]);
                    tm.modifiedby = rdr[7].ToString();
                    tm.modifiedon = Convert.ToDateTime(rdr[8]);

                    lstcard.Add(tm);
                    }
                    con.Close();
                }
                return lstcard;
            }
        public Int32 AddCardEntry(TempCardModel tm)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("tempcard_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", tm.empid);
                cmd.Parameters.AddWithValue("@cardid", tm.tempcardno);
                cmd.Parameters.AddWithValue("@isdel", tm.IsDeleted);
                cmd.Parameters.AddWithValue("@isactive", tm.IsActive);
                cmd.Parameters.AddWithValue("@addedby", tm.addedby);
                cmd.Parameters.AddWithValue("@addedon", tm.addedon);
                cmd.Parameters.AddWithValue("@modifiedby", tm.modifiedby);

                cmd.Parameters.AddWithValue("@modifiedon", tm.modifiedon);
                cmd.Parameters.Add("@ret", SqlDbType.Int);
                cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
                con.Open();
                // cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Int32 k = Convert.ToInt32(cmd.Parameters["@ret"].Value);
                con.Close();
                cmd.Dispose();
                return k;
            }

        }

        public Int32 UpdateTempCard(TempCardModel tm, int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("tempcard_update", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@tmpno", id);
                cmd.Parameters.AddWithValue("@empid", tm.empid);
                cmd.Parameters.AddWithValue("@cardid", tm.tempcardno);
                

                cmd.Parameters.AddWithValue("@isdel", tm.IsDeleted);
                cmd.Parameters.AddWithValue("@isactive", tm.IsActive);


                cmd.Parameters.AddWithValue("@modifiedby", tm.modifiedby);

                cmd.Parameters.AddWithValue("@modifiedon", tm.modifiedon);
                cmd.Parameters.Add("@ret", SqlDbType.Int);
                cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
                con.Open();
                // cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Int32 k = Convert.ToInt32(cmd.Parameters["@ret"].Value);
                con.Close();
                cmd.Dispose();
                return k;

            }
        }

        public Int32 DelTempCard(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("tempcar_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tempno", id);
                cmd.Parameters.Add("@ret", SqlDbType.Int);
                cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
                con.Open();
                cmd.ExecuteNonQuery();
                Int32 k = Convert.ToInt32(cmd.Parameters["@ret"].Value);
                con.Close();
                cmd.Dispose();
                return k;

            }
        }

    }
}
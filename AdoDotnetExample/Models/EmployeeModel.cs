using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdoDotnetExample.Models
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
    }

    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection(@"Data Source=AZAM-PC\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");//User Id=;Password
        public List<EmployeeModel> GetEmployee()
        {

            List<EmployeeModel> listObj = new List<EmployeeModel>();

            SqlCommand cmd = new SqlCommand("sp_getRituEmployees", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.EmpId = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);
                listObj.Add(emp);
            }
            return listObj;
        }

        public int SaveEmployee(EmployeeModel Emp)
        {
            SqlCommand cmd = new SqlCommand("sp_insertRituEmployees", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpName", Emp.EmpName);
            cmd.Parameters.AddWithValue("@EmpSalary", Emp.EmpSalary);

            int result = cmd.ExecuteNonQuery();


            con.Close();
            return result;


        }

        public EmployeeModel GetEmployeeById(int? id)
        {

            EmployeeModel emp = new EmployeeModel();

            SqlCommand cmd = new SqlCommand("sp_getNeerjaEmployeeDetailsById", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", id);


            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                emp.EmpId = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);

            }
            return emp;

        }

        public int UpdateEmployee(EmployeeModel Emp)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateNeerjaEmployees", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpId", Emp.EmpId);
            cmd.Parameters.AddWithValue("@EmpName", Emp.EmpName);
            cmd.Parameters.AddWithValue("@EmpSalary", Emp.EmpSalary);

            int result = cmd.ExecuteNonQuery();


            con.Close();
            return result;


        }


        public int DeleteEmployee(int? id)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteNeerjaEmployees", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpId", id);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
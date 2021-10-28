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
        public List<EmployeeModel> GetEmployee() {

            List<EmployeeModel> listObj = new List<EmployeeModel>();
            SqlCommand cmd = new SqlCommand("sp_getRituEmployees", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.EmpId =Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);
                listObj.Add(emp);
            }
            return listObj;
        }
    }
}
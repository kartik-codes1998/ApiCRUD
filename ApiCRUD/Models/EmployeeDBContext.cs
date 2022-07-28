using System.Data.SqlClient;
using System.Data;

namespace ApiCRUD.Models
{
    public class EmployeeDBContext
    {
        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-5NPAFL8\\SQLEXPRESS;Initial Catalog=ado_db;Integrated Security=True");
        public List<Employee> GetEmployees()
        {
            List<Employee> EmployeeList = new List<Employee>();


            SqlCommand cmd = new SqlCommand("spGetEmployees", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            Con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee emp = new Employee();

                emp.Id = Convert.ToInt32(dr.GetValue(0).ToString());
                emp.name = dr.GetValue(1).ToString();
                emp.gender = dr.GetValue(2).ToString();
                emp.age = Convert.ToInt32(dr.GetValue(3).ToString());
                emp.salary = Convert.ToInt32(dr.GetValue(4).ToString());
                emp.city = dr.GetValue(5).ToString();

                EmployeeList.Add(emp);
            }
            Con.Close();

            return EmployeeList;
        }
        public bool AddEmployee(Employee emp)
        {
            SqlCommand cmd = new SqlCommand("spAddEmployees", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@gender", emp.gender);
            cmd.Parameters.AddWithValue("@age", emp.age);
            cmd.Parameters.AddWithValue("@salary", emp.salary);
            cmd.Parameters.AddWithValue("@city", emp.city);
            Con.Open();
            int i = cmd.ExecuteNonQuery();
            Con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateEmployee(Employee emp)
        {
            SqlCommand cmd = new SqlCommand("spUpdateEmployees", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@gender", emp.gender);
            cmd.Parameters.AddWithValue("@age", emp.age);
            cmd.Parameters.AddWithValue("@salary", emp.salary);
            cmd.Parameters.AddWithValue("@city", emp.city);
            Con.Open();
            int i = cmd.ExecuteNonQuery();
            Con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteEmployee(int id)
        {
            SqlCommand cmd = new SqlCommand("spDeleteEmployees", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            Con.Open();
            int i = cmd.ExecuteNonQuery();
            Con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RazorPagesUsingADO.Models
{
    public class EmployeeDataAccessLayer
    {
        readonly string connectionString = "PUT YOUR DATABASE HERE";

        //To View all employees details    
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> lastemployee = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand commend = new SqlCommand("spGetAllEmployees", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                SqlDataReader readData = commend.ExecuteReader();

                while (readData.Read())
                {
                    Employee employee = new Employee
                    {
                        Id = Convert.ToInt32(readData["EmployeeID"]),
                        Name = readData["Name"].ToString(),
                        Gender = readData["Gender"].ToString(),
                        Department = readData["Department"].ToString(),
                        City = readData["City"].ToString()
                    };

                    lastemployee.Add(employee);
                }
                connection.Close();
            }
            return lastemployee;
        }
        //To Add new employee record    
        public void AddEmployee(Employee employee)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand commend = new SqlCommand("spAddEmployee", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            commend.Parameters.AddWithValue("Name", employee.Name);
            commend.Parameters.AddWithValue("@Gender", employee.Gender);
            commend.Parameters.AddWithValue("@Department", employee.Department);
            commend.Parameters.AddWithValue("@City", employee.City);

            connection.Open();
            commend.ExecuteNonQuery();
            connection.Close();
        }
        //To Update the records of a particluar employee  
        public void UpdateEmployee(Employee employee)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand commend = new SqlCommand("spUpdateEmployee", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            commend.Parameters.AddWithValue("EmpId", employee.Id);
            commend.Parameters.AddWithValue("Name", employee.Name);
            commend.Parameters.AddWithValue("Gender", employee.Gender);
            commend.Parameters.AddWithValue("Department", employee.Department);
            commend.Parameters.AddWithValue("City", employee.City);

            connection.Open();
            commend.ExecuteNonQuery();
            connection.Close();
        }
        //Get the details of a particular employee  
        public Employee GetEmployeeData(int? id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
            SqlCommand commend = new SqlCommand(sqlQuery, connection);

            connection.Open();
            SqlDataReader readData = commend.ExecuteReader();

            if (!readData.HasRows) return null;

            Employee employee = new Employee();

            while (readData.Read())
            {
                employee.Id = Convert.ToInt32(readData["EmployeeID"]);
                employee.Name = readData["Name"].ToString();
                employee.Gender = readData["Gender"].ToString();
                employee.Department = readData["Department"].ToString();
                employee.City = readData["City"].ToString();
            }
            return employee;
        }
        //To Delete the record on a particular employee  
        public void DeleteEmployee(int? id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand commend = new SqlCommand("spDeleteEmployee", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            commend.Parameters.AddWithValue("@EmpId", id);

            connection.Open();
            commend.ExecuteNonQuery();
            connection.Close();
        }
    }
}
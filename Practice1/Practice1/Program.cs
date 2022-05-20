using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AdoDemo
{
    class Program
    {
        SqlConnection connection = new SqlConnection();

        public void GetAllEmployees()
        {
            connection.ConnectionString = @"server=(localdb)\MSSQLLocalDB;Database=DotnetF1;Integrated Security=true;";
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "select * from Employee";
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0].ToString()}\t {reader["Name"].ToString()}\t {reader[2].ToString()} \t {reader[3].ToString()}");
            }
            reader.Close();
            connection.Close();
        }
        public void AddNewEmployee()
        {
            connection.ConnectionString = @"server=(localdb)\MSSQLLocalDB;Database=DotnetF1;Integrated Security=true;";
            int salary;
            string name, gender;
            Console.WriteLine(" Enter the Name,Gender and Salary");
            name = Console.ReadLine();
            gender = Console.ReadLine();
            salary = Convert.ToInt32(Console.ReadLine());
            SqlCommand insertcmd = new SqlCommand();
            insertcmd.Connection = connection;
            insertcmd.CommandText = $"insert into Employee values ('{name}','{gender}',{salary})";
            connection.Open();
            int rowcount = insertcmd.ExecuteNonQuery();
            if (rowcount > 0)
            {
                Console.WriteLine("Record inserted Successfully");
            }
            else
            {
                Console.WriteLine(" OOPs Something went wrong");
            }
            connection.Close();
        }
        public void UpdateEmployee()
        {
            connection.ConnectionString = @"server=JKTNOLAP691\SQLEXPRESS;Database=DotnetF1;Integrated Security=true;";
            int id;
            int salary = 0;
            string name = ""; string gender = "";
            Boolean recordAvailable = false;
            Console.WriteLine("Enter the Id to update the record");
            id = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select * from Employee";
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString().Equals(id.ToString()))
                {
                    recordAvailable = true;
                }

            }
            reader.Close();
            connection.Close();
            if (recordAvailable)
            {
                Console.WriteLine(" Enter the Name,Gender and Salary");
                name = Console.ReadLine();
                gender = Console.ReadLine();
                salary = Convert.ToInt32(Console.ReadLine());
                SqlCommand insertcmd = new SqlCommand();
                insertcmd.Connection = connection;
                insertcmd.CommandText = $"update  Employee set name='{name}',Gender='{gender}',salary={salary}  where Empid={id}";
                connection.Open();
                int rowcount = insertcmd.ExecuteNonQuery();
                if (rowcount > 0)
                {
                    Console.WriteLine("Record updated Successfully");
                }
                else
                {
                    Console.WriteLine(" OOPs Something went wrong");
                }
                connection.Close();
            }
            else
            {
                Console.WriteLine(" Given Employee id not found");
            }

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //  program.AddNewEmployee();
            // program.GetAllEmployees();
            program.UpdateEmployee();
            Console.ReadLine();
        }
    }
}

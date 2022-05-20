/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdoDemo
{   
    using System.Data.SqlClient;
    class Program
    {
        SqlConnection Connection = new SqlConnection();
        public void GetAllEmployees()
        {
            Connection.ConnectionString = @"server=(localdb)\MSSQLLocalDB;Database=DotNetF1;Integrated Security=true;";
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = Connection;
            selectCommand.CommandText = "select * from Employee";
            Connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0].ToString()}\t {reader["Name"].ToString()}\t {reader[2].ToString()} \t {reader[3].ToString()}");
            }
            reader.Close();
            Connection.Close();
        }
        public void AddNewEmployee()
        {
            Connection.ConnectionString = @"server=(localdb)\MSSQLLocalDB;Database=DotnetF1;Integrated Security=true;";
            int salary;
            string name, gender;
            Console.WriteLine(" Enter the Name,Gender and Salary");
            name = Console.ReadLine();
            gender = Console.ReadLine();
            salary = Convert.ToInt32(Console.ReadLine());
            SqlCommand insertcmd = new SqlCommand();
            insertcmd.Connection = Connection;
            insertcmd.CommandText = $"insert into Employee values ('{name}','{gender}',{salary})";
            Connection.Open();
            int rowcount = insertcmd.ExecuteNonQuery();
            if (rowcount > 0)
            {
                Console.WriteLine("Record inserted Successfully");
            }
            else
            {
                Console.WriteLine(" OOPs Something went wrong");
            }
            Connection.Close();
        }
        public void UpdateEmployee()
        {
            Connection.ConnectionString = @"server=(localdb)\MSSQLLocalDB;Database=DotnetF1;Integrated Security=true;";
            int id;
            int salary = 0;
            string name = ""; string gender = "";
            Boolean recordAvailable = false;
            Console.WriteLine("Enter the Id to update the record");
            id = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = "select * from Employee";
            Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString().Equals(id.ToString()))
                {
                    recordAvailable = true;
                }

            }
            reader.Close();
            Connection.Close();
            if (recordAvailable)
            {
                Console.WriteLine(" Enter the Name,Gender and Salary");
                name = Console.ReadLine();
                gender = Console.ReadLine();
                salary = Convert.ToInt32(Console.ReadLine());
                SqlCommand insertcmd = new SqlCommand();
                insertcmd.Connection = Connection;
                insertcmd.CommandText = $"update  Employee set name='{name}',Gender='{gender}',salary={salary}  where Empid={id}";
                Connection.Open();
                int rowcount = insertcmd.ExecuteNonQuery();
                if (rowcount > 0)
                {
                    Console.WriteLine("Record updated Successfully");
                }
                else
                {
                    Console.WriteLine(" OOPs Something went wrong");
                }
                Connection.Close();
            }
            else
            {
                Console.WriteLine(" Given Employee id not found");
            }

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.AddNewEmployee();
            program.GetAllEmployees();
            program.UpdateEmployee();
            Console.ReadLine();
        }
    }
}*/


using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Practice01;

namespace Practice01
{
    class Program : GetClassObj
    {
        static void Main(string[] args)
        {
            GetClassObj b = new GetClassObj();
            string path = "C:\\Users\\Shrinivas.banda\\Downloads\\fooddat1.csv";
            FileManger p = b.GetFileManger();
            var abc = p.read(path);
            NaveenOrderProblem nv = new NaveenOrderProblem();
            nv.CountVeg(abc);
            //CSVBaseJson c = b.GetCSVBaseJson();
            //FileManger t = new FileManger();
            //var s = c.ConvertTojson(abc);
            //c.count(abc);
            //CSVBaseXML cSV = b.GetCSVBaseXML();
            //cSV.ConvertToXml(abc);
            //
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Retval you wil need when you call or update a value of sap
            int RetVal = 0;
            ServerConnections connection = new ServerConnections();
            try
            {
                if (connection.Connect() == 0)
                {
                    Console.WriteLine("Connected to: " + connection.GetCompany().CompanyName);
                    if (RetVal == 0)
                    {
                        Console.WriteLine("connected and can update");
                    }
                    else
                    {
                        Console.WriteLine("Error: " + connection.GetCompany().GetLastErrorCode() + "-" + connection.GetCompany().GetLastErrorDescription());
                    }
                    connection.GetCompany().Disconnect();
                }
                else
                {
                    Console.WriteLine("Error: " + connection.GetErrorCode()+ " : " + connection.GetErrorMessage());
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}

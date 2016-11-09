using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace SecondDatabaseAssignment
{
    class Program
    {
        static string cns = ConfigurationManager.ConnectionStrings["CPContext"].ConnectionString;
        static void Main(string[] args)
        {
            int i = 0;
            string selection;

            Console.WriteLine("=======================================");
            Console.WriteLine("Customer Products");
            Console.WriteLine("=======================================");

            while (i == 0)
            {

                MainMenu();

                selection = Console.ReadLine();

                if (selection == "1")
                {
                    InsertCustomer();
                }
                if (selection == "2")
                {
                    InsertProduct();
                }
                if (selection == "3")
                {
                    UpdateProductPrice();
                }
                if (selection == "4")
                {
                    i += 1;
                }
                if (selection != "1" && selection != "2" && selection != "3" && selection != "4")
                {
                    Console.WriteLine("You have entered an incorrect value.");
                    Console.WriteLine("=======================================");

                    Console.WriteLine("Opening main menu.");
                    Console.WriteLine("=======================================");
                }
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("Select a number from the menu:");
            Console.WriteLine("1. Insert Customer.");
            Console.WriteLine("2. Insert Product.");
            Console.WriteLine("3. Update Product Price.");
            Console.WriteLine("4. Exit Application.");
            Console.WriteLine("=======================================");
        }

        public static void InsertCustomer()
        {
            Console.Write("Input an ID: ");
            string customerID = Console.ReadLine();

            Console.Write("Input the company name: ");
            string customerCompany = Console.ReadLine();

            Console.Write("Input the contact name: ");
            string customerName = Console.ReadLine();

            Console.Write("Input the address: ");
            string customerAddress = Console.ReadLine();

            Console.Write("Input the city: ");
            string customerCity = Console.ReadLine();

            
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "CustomerInsert";
            cmd.Parameters.AddWithValue("@CustomerID", customerID);
            cmd.Parameters.AddWithValue("@CompanyName", customerCompany);
            cmd.Parameters.AddWithValue("@ContactName", customerName);
            cmd.Parameters.AddWithValue("@Address", customerAddress);
            cmd.Parameters.AddWithValue("@City", customerCity);
            cmd.ExecuteNonQuery();
            cn.Close();

            Console.WriteLine("=======================================");
            Console.WriteLine("Customer added!");
            Console.WriteLine("=======================================");
        }
        public static void InsertProduct()
        {
            Console.Write("Input the products name: ");
            string productName = Console.ReadLine();

            Console.Write("Input the products unit price: ");
            string unitPrice = Console.ReadLine();

            Console.Write("Is the product discontinued? (0 or 1): ");
            string discontinued = Console.ReadLine();

            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "ProductInsert";
            cmd.Parameters.AddWithValue("@ProductName", productName);
            cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@Discontinued", discontinued);
            cmd.ExecuteNonQuery();
            cn.Close();

            Console.WriteLine("=======================================");
            Console.WriteLine("Product added!");
            Console.WriteLine("=======================================");
        }
        public static void UpdateProductPrice()
        {
            Console.Write("Input the product which you would like to update the price for: ");
            string product = Console.ReadLine();

            Console.Write("Input how much you would like to add to the price: ");
            int priceChange = int.Parse(Console.ReadLine());

            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "UpdateProductPrice";
            cmd.Parameters.AddWithValue("@ProductName", product);
            cmd.Parameters.AddWithValue("@UnitPriceChange", priceChange);
            cmd.ExecuteNonQuery();
            cn.Close();

            Console.WriteLine("=======================================");
            Console.WriteLine("Updated <" + product + "> product price.");
            Console.WriteLine("=======================================");
        }
    }
}
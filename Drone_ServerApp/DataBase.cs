using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace Drone_ServerApp
{
    class DataBase
    {
      
        public string[] GetMaterials(NpgsqlConnection conn)
        {

            List<string> Materials = new List<string>();

            string sql = "SELECT id, name, in_storage, total_price FROM materials";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string Name = reader.GetString(1);
                        int In_stock = Convert.ToInt32(reader.GetValue(2));
                        int Cost = Convert.ToInt32(reader.GetValue(3));
                        
                        Materials.Add(ID.ToString() + " ; " + Name + " ; " +In_stock.ToString()+" ; "+ Cost.ToString());

                    }
                }
                else Materials.Add("No items");
            }
            conn.Close();

            return Materials.ToArray();

        }
        public string[] GetComponents(NpgsqlConnection conn)
        {
            List<string> Components = new List<string>();
            string sql = "SELECT ID, name, price, specialist FROM components";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string name = reader.GetString(1);
                        int price = Convert.ToInt32(reader.GetValue(2));
                        string specialist = reader.GetString(3);

                        Components.Add(ID.ToString() + " ; " + name + " ; " + price.ToString() + " ; " + specialist);
                    }
                }
                else Components.Add("No items");
            }
            conn.Close();
            return Components.ToArray();
        }
        public string[] GetBasicComponents(NpgsqlConnection conn)
        {
            List<string> BasicComponents = new List<string>();
            string sql = "SELECT ID, name, material, amount_of_material, price FROM basic_components";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string name = reader.GetString(1);
                        string material = reader.GetString(2);
                        int amount = Convert.ToInt32(reader.GetValue(3));
                        int price = Convert.ToInt32(reader.GetValue(4));

                        BasicComponents.Add(ID.ToString() + " ; " + name + " ; " + material + " ; " + amount.ToString() + " ; " + price.ToString());
                    }
                }
                else BasicComponents.Add("No items");
            }
            conn.Close();
            return BasicComponents.ToArray();
        }
        public string[] GetBuyers(NpgsqlConnection conn)
        {
            List<string> Buyers = new List<string>();
            string sql = "SELECT ID, name, address FROM buyers";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string name = reader.GetString(1);
                        string address = reader.GetString(2);
                        Buyers.Add(ID.ToString() + " ; " + name + " ; " + address);
                    }
                }
                else Buyers.Add("No items");
            }
            conn.Close();
            return Buyers.ToArray();
        }
        public string[] GetComponentComposition(NpgsqlConnection conn)
        {
            List<string> Component_composition = new List<string>();
            string sql = "SELECT ID, component, basic_component, price FROM component_composition";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string component = reader.GetString(1);
                        string basic_component = reader.GetString(2);
                        int price = Convert.ToInt32(reader.GetValue(3));
                        Component_composition.Add(ID.ToString() + " ; " + component + " ; " + basic_component+ " ; " + price.ToString());
                    }
                }
                else Component_composition.Add("No items");
            }
            conn.Close();
            return Component_composition.ToArray();
        }
        public string[] GetGoodOfSuppliers(NpgsqlConnection conn)
        {
            List<string> Goods = new List<string>();
            string sql = "SELECT ID, supplier, material, price FROM good_of_suppliers";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string supplier = reader.GetString(1);
                        string material = reader.GetString(2);
                        int price = Convert.ToInt32(reader.GetValue(3));
                        Goods.Add(ID.ToString() + " ; " + supplier + " ; " + material + " ; " + price.ToString());
                    }
                }
                else Goods.Add("No items");
            }
            conn.Close();
            return Goods.ToArray();
        }
        public string[] GetDeliveriesMade(NpgsqlConnection conn)
        {
            List<string> Delivieries = new List<string>();
            string sql = "SELECT ID, supplier, material, price, amount FROM deliveries_made";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string supplier = reader.GetString(1);
                        string material = reader.GetString(2);
                        int price = Convert.ToInt32(reader.GetValue(3));
                        int amount = Convert.ToInt32(reader.GetValue(4));
                        Delivieries.Add(ID.ToString() + " ; " + supplier + " ; " + material + " ; " + price.ToString() + " ; " + amount.ToString());
                    }
                }
                else Delivieries.Add("No items");
            }
            conn.Close();
            return Delivieries.ToArray();
        }
        public string[] GetDroneComposition(NpgsqlConnection conn)
        {
            List<string> DroneComposition = new List<string>();
            string sql = "SELECT ID, drone, component, price FROM drone_composition";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string drone = reader.GetString(1);
                        string component = reader.GetString(2);
                        int price = Convert.ToInt32(reader.GetValue(3));
                        DroneComposition.Add(ID.ToString() + " ; " + drone + " ; " + component + " ; " + price.ToString());
                    }
                }
                else DroneComposition.Add("No items");
            }
            conn.Close();
            return DroneComposition.ToArray();
        }
        public string[] GetSales(NpgsqlConnection conn)
        {
            List<string> Sales = new List<string>();
            string sql = "SELECT * FROM sales";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string buyer = reader.GetString(1);
                        string drone = reader.GetString(2);
                        int amount = Convert.ToInt32(reader.GetValue(3));
                        int price = Convert.ToInt32(reader.GetValue(4));
                        string date = reader.GetDateTime(5).ToString();
                        string manager = reader.GetString(6);
                        Sales.Add(ID.ToString() + " ; " + buyer + " ; " + drone + " ; " + amount.ToString() + " ; " + price.ToString() + " ; " + date + " ; " + manager);
                    }
                }
                else Sales.Add("No items");
            }
            conn.Close();
            return Sales.ToArray();
        }
        public string[] GetDrones(NpgsqlConnection conn)
        {
            List<string> Drones = new List<string>();
            string sql = "SELECT * FROM drones";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string name = reader.GetString(1);
                        int price = Convert.ToInt32(reader.GetValue(2));
                        int amount = Convert.ToInt32(reader.GetValue(3));
                        string specialist = reader.GetString(4);

                        Drones.Add(ID.ToString() + " ; " + name + " ; " + price.ToString() + " ; " + amount.ToString() + " ; " + specialist);
                    }
                }
                else Drones.Add("No items");
            }
            conn.Close();
            return Drones.ToArray();
        }
        public string[] GetManagers(NpgsqlConnection conn)
        {
            List<string> Managers = new List<string>();
            string sql = "SELECT * FROM managers";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string login = reader.GetString(1);
                        int sales_amount = Convert.ToInt32(reader.GetValue(2));


                        Managers.Add(ID.ToString() + " ; " + login + " ; " + sales_amount.ToString());
                    }
                }
                else Managers.Add("No items");
            }
            conn.Close();
            return Managers.ToArray();
        }
        public string[] GetSpecialists(NpgsqlConnection conn)
        {
            List<string> Specialists = new List<string>();
            string sql = "SELECT * FROM specialists";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string login = reader.GetString(1);
                        int manufactured_amount = Convert.ToInt32(reader.GetValue(2));


                        Specialists.Add(ID.ToString() + " ; " + login + " ; " + manufactured_amount.ToString());
                    }
                }
                else Specialists.Add("No items");
            }
            conn.Close();
            return Specialists.ToArray();
        }
        public string[] GetSuppliers(NpgsqlConnection conn)
        {
            List<string> Suppliers = new List<string>();
            string sql = "SELECT * FROM suppliers";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)     //Якщо є рядки
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetValue(0));
                        string name = reader.GetString(1);
                        string address = reader.GetString(2);
                        int cost_of_orders = Convert.ToInt32(reader.GetValue(3));


                        Suppliers.Add(ID.ToString() + " ; " + name + " ; " + address + " ; " + cost_of_orders.ToString());
                    }
                }
                else Suppliers.Add("No items");
            }
            conn.Close();
            return Suppliers.ToArray();
        }

        public void UpdateSpecialist(NpgsqlConnection conn, string specialist)
        {
            string sql = "UPDATE specialists SET manufactured_amount = manufactured_amount + 1 WHERE login ='" + specialist + "'";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }

        }
        public void UpdateManager(NpgsqlConnection conn, string manager)
        {
            string sql = "UPDATE managers SET sales_amount = sales_amount + 1 WHERE login ='" + manager + "'";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }

        }
        public void UpdateDrones(NpgsqlConnection conn, string name,int amount)
        {
            string sql = "UPDATE drones SET amount = amount +"+amount+ " WHERE name ='" + name + "'";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }

        }
        public void UpdateMinusDrones(NpgsqlConnection conn, string name, int amount)
        {
            string sql = "UPDATE drones SET amount = amount -" + amount + " WHERE name ='" + name + "'";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }

        }
        public void UpdateMaterials(NpgsqlConnection conn, string name,int amount,int price)
        {
            string sql = "UPDATE materials SET in_storage = in_storage +" + amount+" WHERE name ='" + name + "'";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
           
            sql = "UPDATE materials SET total_price = total_price +" + price + " WHERE name ='" + name + "'";
            cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
        }
        public void UpdateSupplier(NpgsqlConnection conn, string name, int money)
        {
            string sql = "UPDATE suppliers SET cost_of_orders = cost_of_orders +" +money+ " WHERE name ='" + name + "'";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }

        }





        public string[] NewMaterial(NpgsqlConnection conn, string name)
        {
            string sql = "INSERT INTO materials (name,in_storage,total_price) values ('" + name + "'" + "," + 0+","  + 0   + ")";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
            return GetMaterials(conn);
        }
        public string[] NewBasicComponent(NpgsqlConnection conn, string name, string material, int amount_material, int price)
        {
            string sql = "INSERT INTO basic_components (name,material,amount_of_material,price) values ('" + name + "'" + ",'" + material + "'," + amount_material +","+price+ ")";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
            return GetBasicComponents(conn);
        }
        public string[] NewComponent(NpgsqlConnection conn, string name, int price, string specialist)
        {
            string sql = "INSERT INTO components (name,price,specialist) values ('" + name + "'" + "," + price + ",'" + specialist +  "')";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
            UpdateSpecialist(conn, specialist);
            return GetComponents(conn);
        }
        public string[] NewComponentComposition(NpgsqlConnection conn, string component, string basic, int price)
        {
            string sql = "INSERT INTO component_composition (component,basic_component,price) values ('" + component + "'" + ",'" + basic + "'," + price+ ")";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
            return GetComponentComposition(conn);
        }
        public string[] NewSupplier(NpgsqlConnection conn, string name, string address)
        {
            string sql = "INSERT INTO suppliers (name,address,cost_of_orders) values ('" + name + "'" + ",'" + address + "'," + 0 + ")";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
            return GetSuppliers(conn);
        }
        public string[] NewBuyer(NpgsqlConnection conn, string name, string address)
        {
            string sql = "INSERT INTO buyers (name,address) values ('" + name + "'" + ",'" + address + "')";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
            return GetBuyers(conn);
        }
        public string[] NewGoodOfSupplier(NpgsqlConnection conn, string supplier, string material, int price)
        {
            string sql = "INSERT INTO good_of_suppliers (supplier,material,price) values ('" + supplier + "'" + ",'" + material + "'," + price + ")";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
            return GetGoodOfSuppliers(conn);
        }
        public string[] NewDelivery(NpgsqlConnection conn, string supplier, string material, int price,int amount)
        {
            string sql = "INSERT INTO deliveries_made (supplier,material,price,amount) values ('" + supplier + "'" + ",'" + material + "'," + price + ",'"+amount+ "')";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
            UpdateSupplier(conn, supplier, price);
            UpdateMaterials(conn, material, amount,price);
            return GetDeliveriesMade(conn);
        }
        public string[] NewDrone(NpgsqlConnection conn, string name, int price, string specialist)
        {
            string sql = "INSERT INTO drones (name,price,amount,specialist) values ('" + name + "'" + "," + price + ","+0+ ",'" + specialist + "')";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
            UpdateSpecialist(conn, specialist);
            return GetDrones(conn);
        }
        public string[] NewDroneComposition(NpgsqlConnection conn, string drone, string component, int price)
        {
            string sql = "INSERT INTO drone_composition (drone,component,price) values ('" + drone + "'" + ",'" + component + "'," + price + ")";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
            
            return GetDroneComposition(conn);
        }
        public string[] NewSale(NpgsqlConnection conn, string buyer, string drone, int amount, int price, string date, string manager)
        {
            string sql = "INSERT INTO sales (buyer,purchased_drone,amount,price,date,manager) values ('" + buyer + "'" + ",'" + drone + "'," + amount + ","+price+ ",'"+date+"','"+ manager + "')";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Close();
            conn.Open();
            using (DbDataReader reader = cmd.ExecuteReader()) { }
            UpdateManager(conn, manager);
            return GetSales(conn);
        }

        public string GetUser(NpgsqlConnection conn, int id)
        {
            
                string sql = "SELECT ID, login, password, post FROM users WHERE ID=" + id.ToString();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                string tmp = null;
                conn.Close();
                conn.Open();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)     //Якщо є рядки
                    {
                        while (reader.Read())
                        {
                            int ID = Convert.ToInt32(reader.GetValue(0));
                            string Name = reader.GetString(1);
                            string Pass = reader.GetString(2);
                            string Post = reader.GetString(3);
                            tmp = "Name:" + Name + "Post:" + Post;
                        }
                    }

                }
                return tmp;
            
        }
        public int Autor(NpgsqlConnection conn, string name, string pass)
        {
            
                string sql = "SELECT ID, login, password, post FROM users WHERE login='" + name + "'";
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                conn.Close();
                conn.Open();
                string tmp = null;
                int index = 0, ID = 0;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)     //Якщо є рядки
                    {
                        while (reader.Read())
                        {
                            ID = Convert.ToInt32(reader.GetValue(0));
                            string Pass = reader.GetString(2);
                            if (Pass == pass) { index = 1; }
                        }
                    }
                    else { Console.WriteLine("Wrong username"); return 0; }
                }

                if (index == 1) tmp = GetUser(conn, ID);
                else { Console.WriteLine("Wrong Password"); return 0; }
                if (tmp.Contains("Storage") == true) return 1;
                else if (tmp.Contains("specialist") == true) return 2;
                else return 3;

            
        }
        public int UsernameChecker(NpgsqlConnection conn, string name)
        {
            
                string sql = "SELECT ID FROM users WHERE login='" + name + "'";
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                conn.Close();
                conn.Open();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)     //Якщо є рядки
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0)) return 1;
                        }
                    }

                }
            
            return 0;
        }
        public string NewUser(NpgsqlConnection conn, string name, string pass, string post)
        {
            if (UsernameChecker(conn, name) == 1) return "Name already used";
            
                string sql = "INSERT INTO users (login,password,post) values ('" + name + "'" + ","
                + "'" + pass + "'" + "," + "'" + post + "'" + ")";
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                conn.Close();
                conn.Open();
                using (DbDataReader reader = cmd.ExecuteReader()) { }
            if (post.Contains("specialist")) sql = "INSERT INTO specialists (login,manufactured_amount) values ('" + name + "'" + "," + "0" + ")";
            else if (post.Contains("seller")) sql = "INSERT INTO managers (login,sales_amount) values ('" + name + "'" + "," + "0" + ")";
            else sql = "Select * From users";
            cmd = new NpgsqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                conn.Close();
                conn.Open();
                using (DbDataReader reader = cmd.ExecuteReader()) { }
                if (post.Contains("storage") == true) return "1";
                else if (post.Contains("specialist") == true) return "2";
                return "3";
        }
        public static NpgsqlConnection
            GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            return conn;
        }
        public static NpgsqlConnection GetDBConnection()
        {   //DataBase connect information
            string host = "localhost";
            int port = 5432;
            string database = "Drone_production";
            string username = "postgres";
            string password = "admin";

            return GetDBConnection(host, port, database, username, password);
        }
    }
}

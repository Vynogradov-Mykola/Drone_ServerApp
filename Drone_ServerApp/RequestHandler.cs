using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace Drone_ServerApp
{
    class RequestHandler
    {
        public string Request(string dataReceived)
        {
            try
            {
                NpgsqlConnection conn = DataBase.GetDBConnection();
                //redirect request from client to database


                if (dataReceived == "Get_Materials")
                {

                    DataBase DataBase = new DataBase();
                    string[] materials = DataBase.GetMaterials(conn);
                    string mat_for_ret = "";
                    for (int i = 0; i < materials.Length; i++) mat_for_ret += materials[i] + " | ";
                    return (mat_for_ret);
                }
                if (dataReceived == "GetComponents")
                {

                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.GetComponents(conn);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived == "GetBasicComponents")
                {

                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.GetBasicComponents(conn);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived == "GetComponentComposition")
                {

                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.GetComponentComposition(conn);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived == "GetDroneComposition")
                {

                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.GetDroneComposition(conn);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived == "GetDrones")
                {

                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.GetDrones(conn);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived == "GetBuyers")
                {

                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.GetBuyers(conn);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived == "GetSales")
                {

                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.GetSales(conn);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived == "GetGoodOfSuppliers")
                {

                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.GetGoodOfSuppliers(conn);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived == "GetDeliveriesMade")
                {

                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.GetDeliveriesMade(conn);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived == "GetSuppliers")
                {

                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.GetSuppliers(conn);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }

                if (dataReceived.Contains("NewMaterial:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string name = words[1];
                  
                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.NewMaterial(conn, name);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived.Contains("NewBasicComponent:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string name = words[1];
                    string material = words[2];
                    int amount = Convert.ToInt32(words[3]);
                    int price = Convert.ToInt32(words[4]);
                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.NewBasicComponent(conn, name, material, amount, price);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived.Contains("NewComponent:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string name = words[1];
                    int price = Convert.ToInt32(words[2]);
                    string specialist = words[3];
                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.NewComponent(conn, name, price, specialist);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived.Contains("NewComponentComposition:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string component = words[1];
                    string basic_component = words[2];
                    int price = Convert.ToInt32(words[3]);
                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.NewComponentComposition(conn, component, basic_component, price);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived.Contains("NewSupplier:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string name = words[1];
                    string address = words[2];
                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.NewSupplier(conn, name, address);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived.Contains("NewSale:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string buyer = words[1];
                    string drone = words[2];
                    int amount = Convert.ToInt32(words[3]);
                    int price = Convert.ToInt32(words[4]);
                    string date = words[5];
                    string manager= words[6];
                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.NewSale(conn, buyer, drone,amount,price,date,manager);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived.Contains("NewBuyer:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string name = words[1];
                    string address = words[2];
                
                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.NewBuyer(conn, name, address);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived.Contains("NewGoodOfSupplier:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string supplier = words[1];
                    string material = words[2];
                    int price = Convert.ToInt32(words[3]);
                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.NewGoodOfSupplier(conn, supplier, material, price);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived.Contains("NewDelivery:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string supplier = words[1];
                    string material = words[2];
                    int price = Convert.ToInt32(words[3]);
                    int amount = Convert.ToInt32(words[4]);
                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.NewDelivery(conn, supplier, material, price, amount);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived.Contains("NewDrone:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string name = words[1];
                    int price = Convert.ToInt32(words[2]);
                    string specialist = words[3];
                    
                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.NewDrone(conn, name, price, specialist);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived.Contains("NewDroneComposition:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string drone = words[1];
                    string component = words[2];
                    int price = Convert.ToInt32(words[3]);
                    DataBase DataBase = new DataBase();
                    string[] data_array = DataBase.NewDroneComposition(conn, drone, component, price);
                    string return_array = "";
                    for (int i = 0; i < data_array.Length; i++) return_array += data_array[i] + " | ";
                    return (return_array);
                }
                if (dataReceived.Contains("AddDrone:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string drone = words[1];
                    int amount = Convert.ToInt32(words[2]);
                    DataBase DataBase = new DataBase();
                    DataBase.UpdateDrones(conn, drone,amount);
                    return "One drone added";
                }
                if (dataReceived.Contains("MinusDrone:"))
                {

                    string[] words = dataReceived.Split(' ');
                    string drone = words[1];
                    int amount = Convert.ToInt32(words[2]);
                    DataBase DataBase = new DataBase();
                    DataBase.UpdateMinusDrones(conn, drone, amount);
                    return "One drone added";
                }


                if (dataReceived.Contains("Authorization:"))
                {
                   
                    string[] words = dataReceived.Split(' ');
                    string name = words[1];
                    string password = words[2];

                    DataBase DataBase = new DataBase();
                    return (DataBase.Autor(conn, name, password).ToString());
                }
                if (dataReceived.Contains("Registration:"))
                {
                   
                    string[] words = dataReceived.Split(' ');
                    string name = words[1];
                    string password = words[2];
                    string post = words[3];



                    DataBase DataBase = new DataBase();
                    return(DataBase.NewUser(conn, name, password, post));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "Error!";
        }
    }
}

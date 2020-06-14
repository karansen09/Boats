using Newtonsoft.Json;
using RentBoats.Interface.User;
using RentBoats.Model.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RentBoats.DAL.user
{
    public class RegisterDAL : IRegisterNewUser
    {
        public string AddNewBoat(AddBoat.AddBoatDetails boatDetails)
        {
            string result = string.Empty;
            try
            {
                SqlCommand cmd = DataAccess.GetCommand();
                cmd.CommandText = "Boats.BoatInfo";
                cmd.Parameters.AddWithValue("@Command", "AddBoat");
                cmd.Parameters.AddWithValue("@UserId", boatDetails.UserId);
                cmd.Parameters.AddWithValue("@BoatName", boatDetails.BoatName);
                cmd.Parameters.AddWithValue("@Basecharges", boatDetails.BaseCharges);
                cmd.Parameters.AddWithValue("@HourlyRentedRate", boatDetails.HourlyRate);
                cmd.Parameters.AddWithValue("@BoatImage", boatDetails.BoatImagePath);
                cmd.Parameters.AddWithValue("@IsAvailableForRent", boatDetails.IsAvailableForRent);
                result = DataAccess.ExecureScaler(cmd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<AddBoat.AddBoatDetails> boatDetails(int UserId)
        {
            List<AddBoat.AddBoatDetails> mylist = new List<AddBoat.AddBoatDetails>();
            try
            {
                SqlCommand cmd = DataAccess.GetCommand();
                cmd.CommandText = "Boats.BoatInfo";
                cmd.Parameters.AddWithValue("@Command", "GetBoatDetails");
                cmd.Parameters.AddWithValue("@UserId", UserId);
                DataTable dt = DataAccess.ExecuteTable(cmd);
                string result = JsonConvert.SerializeObject(dt);
                mylist = JsonConvert.DeserializeObject<List<AddBoat.AddBoatDetails>>(result);
            }
            catch(Exception ex)
            {

            }
            return mylist;
        }

        public List<AddBoat.AddBoatDetails> boatDetailsSingle(int Id)
        {
            List<AddBoat.AddBoatDetails> mylist = new List<AddBoat.AddBoatDetails>();
            try
            {
                SqlCommand cmd = DataAccess.GetCommand();
                cmd.CommandText = "Boats.BoatInfo";
                cmd.Parameters.AddWithValue("@Command", "GetSelectedBoat");
                cmd.Parameters.AddWithValue("@Id", Id);
                DataTable dt = DataAccess.ExecuteTable(cmd);
                string result = JsonConvert.SerializeObject(dt);
                mylist = JsonConvert.DeserializeObject<List<AddBoat.AddBoatDetails>>(result);
            }
            catch (Exception ex)
            {

            }
            return mylist;
        }

        public List<Login> Login(Login login)
        {
            List<Login> mylist = new List<Login>();
            try
            {
                SqlCommand cmd = DataAccess.GetCommand();
                cmd.CommandText = "Users.RegisterNewUser";
                cmd.Parameters.AddWithValue("@Username", login.Username);
                cmd.Parameters.AddWithValue("@UserPassword", login.Password);
                cmd.Parameters.AddWithValue("@Command", "LoginUser");
                DataTable dt = DataAccess.ExecuteTable(cmd);
                string result = JsonConvert.SerializeObject(dt);
                mylist = JsonConvert.DeserializeObject<List<Login>>(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return mylist;
        }

        public int NewRent(ModelRentBoat rentBoat)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = DataAccess.GetCommand();
                cmd.CommandText = "Boats.BoatInfo";
                cmd.Parameters.AddWithValue("@Command","RentBoat");
                cmd.Parameters.AddWithValue("@Id", rentBoat.Id);
                cmd.Parameters.AddWithValue("@HourlyRentedRate", rentBoat.HourlyRate);
                cmd.Parameters.AddWithValue("@Basecharges", rentBoat.BaseCharges);
                cmd.Parameters.AddWithValue("@CustomerName", rentBoat.CustomerName);
                result = Convert.ToInt32(DataAccess.ExecureScaler(cmd));
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int RegisterNewUser(ModelRegisterNewUser newUser)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = DataAccess.GetCommand();
                cmd.CommandText = "Users.RegisterNewUser";
                cmd.Parameters.AddWithValue("@Command", "AddNewUser");
                cmd.Parameters.AddWithValue("@FirstName", newUser.FirstName);
                cmd.Parameters.AddWithValue("@LastName", newUser.LastName);
                cmd.Parameters.AddWithValue("@Username", newUser.Username);
                cmd.Parameters.AddWithValue("@UserPassword", newUser.Password);
                cmd.Parameters.AddWithValue("@Email", newUser.Email);
                result = Convert.ToInt32(DataAccess.ExecureScaler(cmd));
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public void RemoveBoat(int Id)
        {
            try
            {
                SqlCommand cmd = DataAccess.GetCommand();
                cmd.CommandText = "Boats.BoatInfo";
                cmd.Parameters.AddWithValue("@Command", "RemoveBoat");
                cmd.Parameters.AddWithValue("@Id", Id);
                Convert.ToInt32(DataAccess.ExecuteNonQuery(cmd));
            }
            catch(Exception ex)
            {

            }
        }

        public int StopRent(ModelRentBoat rentBoat)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = DataAccess.GetCommand();
                cmd.CommandText = "Boats.BoatInfo";
                cmd.Parameters.AddWithValue("@Command", "StopRent");
                cmd.Parameters.AddWithValue("@Id", rentBoat.RentId);
                result = Convert.ToInt32(DataAccess.ExecureScaler(cmd));
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}

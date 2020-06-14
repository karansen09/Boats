using RentBoats.Interface.User;
using RentBoats.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentBoats.BAL.User
{
    public class BusinessUser
    {
        private static IRegisterNewUser registerNewUser= new DAL.user.RegisterDAL();

        #region Register
        /// <summary>
        /// This will register New Users to system and if unable to 
        /// register then 3 response -1 for ALready username, -2 for some sql error and default is 3rd
        /// response which is success
        /// </summary>
        /// <param name="modelRegister"></param>
        /// <returns></returns>
        public static string RegisterNewUser(ModelRegisterNewUser modelRegister)
        {
            string result = string.Empty;
            int response = registerNewUser.RegisterNewUser(modelRegister);
            switch(response)
            {
                case -1:
                    result = "Username already taken";
                    break;
                case -2:
                    result = "Unable to add, please contact support";
                    break;
                default:
                    result = "Successfully user created";
                    break;
            }
            return result;
        }
        #endregion

        #region Login
        /// <summary>
        /// This will return list if successfull login otherwise
        /// list will return 0
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static List<Login> GetLogins(Login login)
        {
            return registerNewUser.Login(login);
        }
        #endregion

        #region AddNewBoat
        /// <summary>
        /// This will add a new boat into system if result comes as -1 then sql error
        /// otherwise boat number will get return
        /// </summary>
        /// <param name="boatDetails"></param>
        /// <returns></returns>
        public static string AddNewBoat(AddBoat.AddBoatDetails boatDetails)
        {
            string result = string.Empty;
            return result = registerNewUser.AddNewBoat(boatDetails);
        }
        #endregion

        #region Boat Rent
        /// <summary>
        /// This will allow user to rent a new boat to customer if
        /// -1 then db error else success
        /// </summary>
        /// <param name="modelRent"></param>
        /// <returns></returns>
        public static string NewRent(ModelRentBoat modelRent)
        {
            string result = string.Empty;
            int response = 0;
            response = registerNewUser.NewRent(modelRent);
            switch(response)
            {
                case -1:
                    result = "-1";
                    break;
                default:
                    result = "success";
                    break;
            }
            return result;
        }
        #endregion

        #region Generate Payment
        /// <summary>
        /// This will generate final payment of Rented boat
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int StopRent(ModelRentBoat model)
        {
            int result = 0;
            return result = registerNewUser.StopRent(model);
        }
        #endregion

        #region List Boats
        /// <summary>
        /// This will list out all the boats on basis of userid
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static List<AddBoat.AddBoatDetails> boatList(int UserId)
        {
            return registerNewUser.boatDetails(UserId);
        }
        #endregion

        #region Get Select Boat details
        /// <summary>
        /// This will get only select boat
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<AddBoat.AddBoatDetails> GetSelectedBoat(int id)
        {
            return registerNewUser.boatDetailsSingle(id);
        }
        #endregion

        #region Remove Boat
        /// <summary>
        /// This is remove boat
        /// </summary>
        /// <param name="id"></param>
        public static void Remove(int id)
        {
            registerNewUser.RemoveBoat(id);
        }
        #endregion
    }
}

using RentBoats.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentBoats.Interface.User
{
    public interface IRegisterNewUser
    {
        int RegisterNewUser(ModelRegisterNewUser newUser);

        List<Login> Login(Login login);

        string AddNewBoat(AddBoat.AddBoatDetails boatDetails);

        int NewRent(ModelRentBoat rentBoat);

        int StopRent(ModelRentBoat rentBoat);

        List<AddBoat.AddBoatDetails> boatDetails(int UserId);

        List<AddBoat.AddBoatDetails> boatDetailsSingle(int Id);

        void RemoveBoat(int Id);
    }
}

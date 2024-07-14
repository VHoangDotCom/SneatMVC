﻿
namespace Sneat.MVC.Models.DTO.User
{
    public class UserInputModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public int? DistrictID { get; set; }
    }

    public class UpdateUserInputModel : UserInputModel
    {
        public int ID { get; set; }
    }
}
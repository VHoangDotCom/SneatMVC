﻿using Sneat.MVC.Models.Enum;
using System;
using System.Collections.Generic;

namespace Sneat.MVC.Models.DTO.User
{
    public class UserInputModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }

        public string Identity { get; set; }
        public DateTime? IdentityReceivedDate { get; set; }
        public string IdentityReceivedPlace { get; set; }
        public List<string> IdentityImages { get; set; }

        public string BankBin { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNo { get; set; }
        public string BankQRImage { get; set; }

        public int? DistrictHomeID { get; set; }
        public string HomeAddress { get; set; }

        public int? DistrictOfficeID { get; set; }
        public string OfficeAddress { get; set; }
    }

    public class UpdateUserInputModel : UserInputModel
    {
        public int ID { get; set; }
    }
}
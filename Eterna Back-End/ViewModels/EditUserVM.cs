﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eterna_Back_End.ViewModels
{
    public class EditUserVM
    {
        [Required, StringLength(maximumLength: 15)]
        public string FirstName { get; set; }
        [Required, StringLength(maximumLength: 20)]
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(maximumLength: 15)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public bool Term { get; set; }
    }
}

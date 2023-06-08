﻿using InternUserManagement.Interfaces;
using InternUserManagement.Models;

namespace InternUserManagement.Services
{
    public class GeneratePasswordService : IGeneratePassword
    {
        public string? GeneratePassword(Intern intern)
        {
            string password = String.Empty;
            password = intern.Name.Substring(0, 4);
            password += intern.DateOfBirth.Day;
            password += intern.DateOfBirth.Month;
            return password;
        }
    }
}

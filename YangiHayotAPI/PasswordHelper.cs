﻿using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace YangiHayotAPI
{
    public static class PasswordHelper
    {
        public static void HashPassword(string password, out byte[] passwordSalt, out byte[] passwordHash) 
        {

            //object hmacsha
            using (HMACSHA3_512 hmac = new HMACSHA3_512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }


        } 
    }
}
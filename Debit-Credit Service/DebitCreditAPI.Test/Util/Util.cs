using DebitCreditAPI.Application.DTO.DTO;
using DebitCreditAPI.Test.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Test.Util
{
    public class Util
    {
        private static readonly Random _random = new Random();

        // Generates a random number within a range.      
        public static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        public static string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        public static void LoadAccounts(TestAccountConfig _testAccount)
        {
            AccDTO account1 = new AccDTO
            {
                AccountNumber = 100,
                Balance = 100
            };
            _testAccount.accountsController.CreateAccount(account1);
            AccDTO account2 = new AccDTO
            {
                AccountNumber = 200,
                Balance = 100
            };
            _testAccount.accountsController.CreateAccount(account2);
            AccDTO account3 = new AccDTO
            {
                AccountNumber = 300,
                Balance = 100
            };
            _testAccount.accountsController.CreateAccount(account3);
        }
    }
}

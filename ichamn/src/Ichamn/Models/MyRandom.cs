using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Ichamn.Models
{
    public static class MyRandom
    {
        public static Random Random = new Random();
        public static String  GenerateRandomString(int p_length)
        {
            //Initiate objects & vars    Random random = new Random();
            String randomString = "";
            
            //Loop ‘length’ times to generate a random number or character
            for (int i = 0; i < p_length; i++)
            {
                int randNumber = Random.Next(1, 3) == 1 ? Random.Next(97, 123) : Random.Next(48, 58);

                //append random char or digit to random string
                randomString = randomString + (char)randNumber;
            }
            //return the random string
            return randomString;
        }
    }
}
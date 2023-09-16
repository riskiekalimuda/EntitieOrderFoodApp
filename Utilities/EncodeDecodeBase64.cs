using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderEntitie.Utilities
{
    public class EncodeDecodeBase64
    {
        public static string EncodeBase64(string input)
        {
            try
            {
                var inputByte = System.Text.Encoding.UTF8.GetBytes(input);
                return System.Convert.ToBase64String(inputByte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string DecodeBase64(string input)
        {
            try
            {
                var inputByte = System.Convert.FromBase64String(input);
                return System.Text.Encoding.UTF8.GetString(inputByte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

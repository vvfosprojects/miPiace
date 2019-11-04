using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPiace.Helper
{
    public class GenerateToken
    {
        public static string Generate(int length)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 1; i < length; i++)
            {
                if (Math.Floor(26 * random.NextDouble() + DateTime.UtcNow.Millisecond) % 2 == 0)
                {
                    Random ran = new Random();
                    var num = ran.Next(0, 9);
                    builder.Append(num);
                }
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString().ToLower();
        }
    }
}
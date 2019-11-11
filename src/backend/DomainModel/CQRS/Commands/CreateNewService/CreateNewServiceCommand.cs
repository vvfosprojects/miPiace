using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.CreateNewService
{
    public class CreateNewServiceCommand
    {
        public Service Service { get; set; }

        //public string WelcomeMessage { get; set; }
        public string GenerateToken(int length)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 1; i <= length; i++)
            {
                if (Math.Floor(26 * random.NextDouble() + DateTime.UtcNow.Millisecond) % 2 == 0)
                {
                    Random ran = new Random();
                    var num = ran.Next(0, 9);
                    builder.Append(num);
                }
                else
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }
            }
            return builder.ToString().ToLower();
        }
    }
}

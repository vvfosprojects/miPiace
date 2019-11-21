using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Classes
{
    public class CriteriDiRicerca
    {
        public string PrivateToken { get; set; }

        public string Rating { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int FirstIndex { get; set; }

        public int LastIndex { get; set; }

        public int TotalItems { get; set; }
    }
}

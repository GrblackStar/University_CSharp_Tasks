using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upr_4
{
    public class Contact
    {
        private string? _name;
        public string Name
        {
            get => _name!;
            set => _name = value ?? $"user{new Random().Next(10000, 99999)}";
        }
    }
}

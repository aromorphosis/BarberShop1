using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberShop1.EF;

namespace BarberShop1.ClassHelper
{
    internal class Class1
    {
        public static BarberShop context { get; set; } = new BarberShop();
    }
}

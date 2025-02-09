using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Heplers
{
    public class GenerateTakipKodu
    {
        public static string KodUret()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G", "H", "V", "Q", "W", "Z" };
            return $"{rnd.Next(100, 1000)}{karakterler[rnd.Next(karakterler.Length)]}{rnd.Next(10, 99)}{karakterler[rnd.Next(karakterler.Length)]}{rnd.Next(10, 99)}{karakterler[rnd.Next(karakterler.Length)]}";
        }
    }
}
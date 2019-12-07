// Autor: Jan Doležel
// login: xdolez81
// projekt ITU - kniha jízd
// 2019
// data aplikace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ItuKnihaJizd
{
    class UserDataClass
    {
        public static string DruhJizdy { get; set; }
        public static string PolohaStart { get; set; }

        public static string PolohaCil { get; set; }

        public UserDataClass(string start, string finish, string druh_jizdy)
        {
            DruhJizdy = druh_jizdy;
            PolohaStart = start;
            PolohaCil = finish;
        }

        public override string ToString()
        {
            return DruhJizdy + "  " + PolohaStart + "  " + PolohaCil;
        }
    }
}
// Autor: Jan Doležel
// login: xdolez81
// projekt ITU - kniha jízd
// 2019
// hlavní obrazovka

using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace ItuKnihaJizd
{
    [Activity(Label = "@string/app_name", Theme = "@android:style/Theme.Material.NoActionBar", MainLauncher = true)]
    public class MainScreenActivity : Activity
    {
        string[] poloha_start = {"Olomouc", "Brno", "Praha", "Ostrava", "Opava", "Nový Jičín", "Opava", "Prostějov" };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // nastavení frontendu aktivity
            SetContentView(Resource.Layout.main_screen);

            // reakce na stisknutí tlačítka "Jízda" (nic se zde dít nebude)
            Button jizda = FindViewById<Button>(Resource.Id.jizda);
            jizda.Click += delegate
            {

            };
            // reakce na stisknutí tlačítka "Historie"
            Button historie = FindViewById<Button>(Resource.Id.historie);
            historie.Click += delegate
            {
                StartActivity(typeof(HistoryScreenActivity));
            };

            // vyhledání hodnoty radio buttonu
            RadioButton soukroma_jizda = FindViewById<RadioButton>(Resource.Id.soukroma_jizda);
            RadioButton sluzebni_jizda = FindViewById<RadioButton>(Resource.Id.sluzebni_jizda);

            // tlačítko Zahájení jízdy
            Button zahajit_jizdu = FindViewById<Button>(Resource.Id.zahajit_jizdu);
            zahajit_jizdu.Click += delegate
            {
                // zjištění typu jízdy
                if (sluzebni_jizda.Checked == true)
                {
                    Android.Widget.Toast.MakeText(this, "Zahájena služební jízda", ToastLength.Short).Show();
                    UserDataClass.DruhJizdy = "Služební jízda";
                }
                else
                {
                    Android.Widget.Toast.MakeText(this, "Zahájena soukromá jízda", ToastLength.Short).Show();
                    UserDataClass.DruhJizdy = "Soukromá jízda";
                }
                // TODO zjištění polohy na startu jízdy (statická data?)
                Random poloha_random = new Random();
                UserDataClass.PolohaStart = poloha_start[poloha_random.Next(0, poloha_start.Length -1)];


                // zahájení aktivity jízdy
                StartActivity(typeof(DriveScreenActivity));
            };

        }
	}
}


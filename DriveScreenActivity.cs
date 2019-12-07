// Autor: Jan Doležel
// login: xdolez81
// projekt ITU - kniha jízd
// 2019
// obrazovka probíhající jízdy

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
    [Activity(Label = "DriveScreenActivity", Theme = "@android:style/Theme.Material.NoActionBar")]
    public class DriveScreenActivity : Activity
    {
        string[] poloha_cil = { "Olomouc", "Brno", "Praha", "Ostrava", "Opava", "Nový Jičín", "Opava", "Prostějov" };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // nastavení frontendu aktivity
            SetContentView(Resource.Layout.drive_screen);

            // nastavení druhu jízdy
            TextView jizda_v_prubehu = FindViewById<TextView>(Resource.Id.druh_jizdy);
            jizda_v_prubehu.Text = UserDataClass.DruhJizdy + " v průběhu";

            // reakce na tlačítko Ukončit jízdu
            Button ukoncit = FindViewById<Button>(Resource.Id.ukoncit);
            ukoncit.Click += delegate
            {
                Random poloha_random = new Random();
                //TODO zapsat informace o jízdě do souboru
                var localContacts = Application.Context.GetSharedPreferences("HistorieJizd", FileCreationMode.Private);
                var contactEdit = localContacts.Edit();
                contactEdit.PutString("Start", UserDataClass.PolohaStart);
                contactEdit.PutString("Cil", poloha_cil[poloha_random.Next(0, poloha_cil.Length - 1)]);
                contactEdit.PutString("Druh_jizdy", UserDataClass.DruhJizdy);
                contactEdit.Commit();

                // testuju
                string druh_jizdy = localContacts.GetString("Druh_jizdy", null);
                string start = localContacts.GetString("Start", null);
                string cil = localContacts.GetString("Cil", null);
                Android.Widget.Toast.MakeText(this, druh_jizdy + " " + start + " " + cil, ToastLength.Short).Show();

                // zpět na hlavní aktivitu
                StartActivity(typeof(MainScreenActivity));
            };
        }
    }
}
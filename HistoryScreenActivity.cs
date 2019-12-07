// Autor: Jan Doležel
// login: xdolez81
// projekt ITU - kniha jízd
// 2019
// obrazovka historie jízd
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.RecyclerView.Extensions;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace ItuKnihaJizd
{
    [Activity(Label = "HistoryScreenActivity", Theme = "@android:style/Theme.Material.NoActionBar")]
    public class HistoryScreenActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // nastavení frontendu aktivity
            //SetContentView(Resource.Layout.history_screen);

            // retrieve the information from the shared preferences
            var localContacts = Application.Context.GetSharedPreferences("HistorieJizd", FileCreationMode.Private);
            string druh_jizdy = localContacts.GetString("Druh_jizdy", null);
            string start = localContacts.GetString("Start", null);
            string cil = localContacts.GetString("Cil", null);
            Log.Debug(GetType().FullName, "Druh_jizdy" + "=" + druh_jizdy + " " + " Start=" + start + " Cil=" + cil);

            UserDataClass mojeJizda = new UserDataClass(start, cil, druh_jizdy);

            // create an array of items that will go in my list
            UserDataClass[] seznamCest = { mojeJizda };

            //add the list to the list adapter
            ListAdapter = new ArrayAdapter<UserDataClass>(this, Android.Resource.Layout.SimpleListItem1, seznamCest);
        }
    }
}
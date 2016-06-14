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

namespace xamarin_lim_kopi
{
    [Activity(Label = "Order History", Icon = "@drawable/icon")]
    public class OrderHistoryActivity : Activity
    {
        ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "history" layout resource
            SetContentView(Resource.Layout.History);

            // Create your application here
            listView = FindViewById<ListView>(Resource.Id.listViewHistory);
            IList<string> orderList = Intent.Extras.GetStringArrayList("order_list") ?? new string[0];

            listView.Adapter = new ArrayAdapter<string>(
                this, Android.Resource.Layout.SimpleListItem1, orderList);

            listView.ItemLongClick += new EventHandler<AdapterView.ItemLongClickEventArgs>(f);
        }

        private void f (object sender, AdapterView.ItemLongClickEventArgs target)
        {
            ListView lv = (ListView)sender;
            IList<string> ol = Intent.Extras.GetStringArrayList("order_list") ?? new string[0];
            ol.RemoveAt(target.Position);
            // Refresh
        }
    }
}
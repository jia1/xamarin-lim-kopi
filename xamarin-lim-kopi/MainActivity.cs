using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;

namespace xamarin_lim_kopi
{
    [Activity(Label = "xamarin_lim_kopi", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        string servingsText = string.Empty;
        string simiDrink = string.Empty;
        string simiMilk = string.Empty;
        string simiRandom = string.Empty;
        string simiSugar = string.Empty;
        string thickOrThin = string.Empty;
        string pengOrNot = string.Empty;

        string[] orderDrink;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ToggleButton kopiOrTeh = FindViewById<ToggleButton>(Resource.Id.toggleKopiTeh);
            ToggleButton pengBo = FindViewById<ToggleButton>(Resource.Id.togglePeng);
            EditText servingsEdit = FindViewById<EditText>(Resource.Id.editServings);
            Button orderButton = FindViewById<Button>(Resource.Id.buttonOrder);

            servingsText = servingsEdit.Text;

            orderDrink = new string[] {
                GetString(Resource.String.Order),
                servingsText,
                simiDrink,
                simiMilk,
                simiRandom,
                simiSugar,
                thickOrThin,
                pengOrNot
            };

            orderButton.Text = Core.OrderUpdater.generateOrder(0, servingsText, ref orderDrink);

            kopiOrTeh.Click += (object sender, EventArgs e) =>
            {
                simiDrink = (kopiOrTeh.Checked) ? 
                    GetString(Resource.String.Teh) 
                    : GetString(Resource.String.Kopi);
                orderButton.Text = Core.OrderUpdater.generateOrder(1, simiDrink, ref orderDrink);
            };

            pengBo.Click += (object sender, EventArgs e) =>
            {
                pengOrNot = (pengBo.Checked) ?
                    GetString(Resource.String.Peng)
                    : "(" + GetString(Resource.String.MaiPeng) + ")";
                orderButton.Text = Core.OrderUpdater.generateOrder(6, pengOrNot, ref orderDrink);
            };

            RadioButton noMilkBtn = FindViewById<RadioButton>(Resource.Id.radioMilkDefault);
            RadioButton oBtn = FindViewById<RadioButton>(Resource.Id.radioMilkO);
            RadioButton seeBtn = FindViewById<RadioButton>(Resource.Id.radioMilkSee);

            RadioButton noRandomBtn = FindViewById<RadioButton>(Resource.Id.radioRandomDefault);
            RadioButton aliaBtn = FindViewById<RadioButton>(Resource.Id.radioRandomAlia);
            RadioButton lemonBtn = FindViewById<RadioButton>(Resource.Id.radioRandomLemon);
            RadioButton masalaBtn = FindViewById<RadioButton>(Resource.Id.radioRandomMasala);

            RadioButton defaultSugarBtn = FindViewById<RadioButton>(Resource.Id.radioSugarDefault);
            RadioButton kosongBtn = FindViewById<RadioButton>(Resource.Id.radioSugarKosong);
            RadioButton moreBtn = FindViewById<RadioButton>(Resource.Id.radioSugarMore);
            RadioButton lessBtn = FindViewById<RadioButton>(Resource.Id.radioSugarLess);

            RadioButton defaultDensityBtn = FindViewById<RadioButton>(Resource.Id.radioDensityDefault);
            RadioButton gauBtn = FindViewById<RadioButton>(Resource.Id.radioDensityThick);
            RadioButton poBtn = FindViewById<RadioButton>(Resource.Id.radioDensityThin);

            noMilkBtn.CheckedChange += MilkBtn_CheckedChange;
            oBtn.CheckedChange += MilkBtn_CheckedChange;
            seeBtn.CheckedChange += MilkBtn_CheckedChange;

            // orderButton.Click += 
        }

        private void MilkBtn_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            RadioButton checkedRadio = (RadioButton) sender;
            simiMilk = checkedRadio.Text;
            Core.OrderUpdater.generateOrder(2, simiMilk, ref orderDrink);
        }
    }
}


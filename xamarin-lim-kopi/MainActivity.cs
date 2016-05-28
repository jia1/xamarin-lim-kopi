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

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ToggleButton kopiOrTeh = FindViewById<ToggleButton>(Resource.Id.toggleKopiTeh);
            RadioGroup milkRadioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroupMilk);
            RadioGroup randomRadioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroupRandom);
            RadioGroup sugarRadioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroupSugar);
            RadioGroup densityRadioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroupDensity);
            ToggleButton pengBo = FindViewById<ToggleButton>(Resource.Id.togglePeng);
            EditText servingsEditText = FindViewById<EditText>(Resource.Id.editServings);
            Button orderButton = FindViewById<Button>(Resource.Id.buttonOrder);

            int milkId = milkRadioGroup.CheckedRadioButtonId;
            int randomId = randomRadioGroup.CheckedRadioButtonId;
            int sugarId = sugarRadioGroup.CheckedRadioButtonId;
            int densityId = densityRadioGroup.CheckedRadioButtonId;
            int servings = 0;

            string simiDrink = " " + GetString(Resource.String.Kopi);
            string simiMilk = " " + FindViewById<RadioButton>(milkId).Text;
            string simiRandom = " " + FindViewById<RadioButton>(randomId).Text;
            string simiSugar = " " + FindViewById<RadioButton>(sugarId).Text;
            string thickOrThin = " " + FindViewById<RadioButton>(densityId).Text; ;
            string pengOrNot = " " + GetString(Resource.String.MaiPeng);

            string[] orderDrink = new string[] {
                " ",
                servings.ToString(),
                simiDrink,
                simiMilk,
                simiRandom,
                simiSugar,
                pengOrNot
            };

            orderButton.Text = Core.OrderUpdater.generateOrder(-1, string.Empty, ref orderDrink);

            Int32.TryParse(servingsEditText.Text, out servings);

            // servingsEditText

            kopiOrTeh.Click += (object sender, EventArgs e) =>
            {
                simiDrink = " " + ((kopiOrTeh.Checked) ? 
                    GetString(Resource.String.Teh) 
                    : GetString(Resource.String.Kopi));
                orderButton.Text = Core.OrderUpdater.generateOrder(2, simiDrink, ref orderDrink);
            };

            milkRadioGroup.CheckedChange += delegate
            {
                simiMilk = " " + FindViewById<RadioButton>(milkId).Text;
                orderButton.Text = Core.OrderUpdater.generateOrder(3, simiMilk, ref orderDrink);
            };

            randomRadioGroup.CheckedChange += delegate
            {
                simiRandom = " " + FindViewById<RadioButton>(randomId).Text;
                orderButton.Text = Core.OrderUpdater.generateOrder(4, simiRandom, ref orderDrink);
            };

            sugarRadioGroup.CheckedChange += delegate
            {
                simiSugar = " " + FindViewById<RadioButton>(sugarId).Text;
                orderButton.Text = Core.OrderUpdater.generateOrder(5, simiSugar, ref orderDrink);
            };

            densityRadioGroup.CheckedChange += delegate
            {
                thickOrThin = " " + FindViewById<RadioButton>(densityId).Text;
                orderButton.Text = Core.OrderUpdater.generateOrder(6, thickOrThin, ref orderDrink);
            };

            pengBo.Click += (object sender, EventArgs e) =>
            {
                pengOrNot = (pengBo.Checked) ?
                    GetString(Resource.String.Peng)
                    : " (" + GetString(Resource.String.MaiPeng) + ")";
                orderButton.Text = Core.OrderUpdater.generateOrder(7, pengOrNot, ref orderDrink);
            };

            // orderButton.Click += 
        }
    }
}


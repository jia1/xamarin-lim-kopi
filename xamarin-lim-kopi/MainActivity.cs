using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

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

            kopiOrTeh.Click += (object sender, EventArgs e) =>
            {
                string simiDrink = (kopiOrTeh.Checked) ? 
                    GetString(Resource.String.Teh) 
                    : GetString(Resource.String.Kopi);
            };

            pengBo.Click += (object sender, EventArgs e) =>
            {
                string pengOrNot = (pengBo.Checked) ?
                    GetString(Resource.String.Peng)
                    : '(' + GetString(Resource.String.MaiPeng) + ')';
            };

            int servings = 0;
            if (Int32.TryParse(servingsEditText.Text, out servings))
            {

            }
            else {
                // servingsEditText.Hint = 
            }

            // orderButton.Click += 
        }
    }
}


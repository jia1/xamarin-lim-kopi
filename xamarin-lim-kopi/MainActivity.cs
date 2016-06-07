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
        string simiServings = string.Empty;
        string simiDrink = string.Empty;
        string simiMilk = string.Empty;
        string simiRandom = string.Empty;
        string simiSugar = string.Empty;
        string simiGauPo = string.Empty;
        string simiPeng = string.Empty;
        string[] orderDrink;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // EditText servingsEdit = FindViewById<EditText>(Resource.Id.editServings);

            ToggleButton kopiOrTeh = FindViewById<ToggleButton>(Resource.Id.toggleKopiTeh);

            Button milkBtn = FindViewById<Button>(Resource.Id.btnMilkDefault);
            Button oBtn = FindViewById<Button>(Resource.Id.btnMilkO);
            Button seeBtn = FindViewById<Button>(Resource.Id.btnMilkSee);

            Button noRandomBtn = FindViewById<Button>(Resource.Id.btnRandomDefault);
            Button aliaBtn = FindViewById<Button>(Resource.Id.btnAlia);
            Button lemonBtn = FindViewById<Button>(Resource.Id.btnLemon);
            Button masalaBtn = FindViewById<Button>(Resource.Id.btnMasala);

            Button sugarBtn = FindViewById<Button>(Resource.Id.btnSugarDefault);
            Button kosongBtn = FindViewById<Button>(Resource.Id.btnSugarZero);
            Button garDaiBtn = FindViewById<Button>(Resource.Id.btnSugarMore);
            Button siuDaiBtn = FindViewById<Button>(Resource.Id.btnSugarLess);

            Button gauPoBtn = FindViewById<Button>(Resource.Id.btnGauPoDefault);
            Button gauBtn = FindViewById<Button>(Resource.Id.btnGau);
            Button poBtn = FindViewById<Button>(Resource.Id.btnPo);

            ToggleButton pengBo = FindViewById<ToggleButton>(Resource.Id.togglePeng);

            Spinner numberSpinner = FindViewById<Spinner>(Resource.Id.spinnerServings);

            Button orderButton = FindViewById<Button>(Resource.Id.buttonOrder);

            // simiServings = servingsEdit.Text;
            orderDrink = new string[] {
                GetString(Resource.String.Order),
                simiServings,
                GetString(Resource.String.Kopi),
                simiMilk,
                simiRandom,
                simiSugar,
                simiGauPo,
                simiPeng
            };

            orderButton.Text = Core.OrderUpdater.generateOrder(1, "0", ref orderDrink);

            /*
            servingsEdit.EditorAction += delegate
            {
                simiServings = servingsEdit.Text;
                orderButton.Text = Core.OrderUpdater.generateOrder(1, simiServings, ref orderDrink);
            };
            */

            numberSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(numberSpinnerItemSelected);
            var arrayAdapter = ArrayAdapter.CreateFromResource(
                this, Resource.Array.ServingsArray, Android.Resource.Layout.SimpleSpinnerItem);
            arrayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            numberSpinner.Adapter = arrayAdapter;

            kopiOrTeh.Click += (object sender, EventArgs e) =>
            {
                simiDrink = (kopiOrTeh.Checked) ?
                    GetString(Resource.String.Teh)
                    : GetString(Resource.String.Kopi);
                orderButton.Text = Core.OrderUpdater.generateOrder(2, simiDrink, ref orderDrink);
            };

            milkBtn.Touch += MilkBtnTouch;
            oBtn.Touch += MilkBtnTouch;
            seeBtn.Touch += MilkBtnTouch;

            noRandomBtn.Touch += RandomBtnTouch;
            aliaBtn.Touch += RandomBtnTouch;
            lemonBtn.Touch += RandomBtnTouch;
            masalaBtn.Touch += RandomBtnTouch;

            sugarBtn.Touch += SugarBtnTouch;
            kosongBtn.Touch += SugarBtnTouch;
            garDaiBtn.Touch += SugarBtnTouch;
            siuDaiBtn.Touch += SugarBtnTouch;

            gauPoBtn.Touch += GauPoBtnTouch;
            gauBtn.Touch += GauPoBtnTouch;
            poBtn.Touch += GauPoBtnTouch;

            pengBo.Click += (object sender, EventArgs e) =>
            {
                simiPeng = (pengBo.Checked) ?
                    GetString(Resource.String.Peng) : string.Empty;
                orderButton.Text = Core.OrderUpdater.generateOrder(7, simiPeng, ref orderDrink);
            };

            // orderButton.Click += 
        }

        private void numberSpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner numberSpinner = (Spinner)sender;
            simiServings = (string)numberSpinner.GetItemAtPosition(e.Position);

            FindViewById<Button>(Resource.Id.buttonOrder).Text =
                Core.OrderUpdater.generateOrder(1, simiServings, ref orderDrink);
        }

        private void MilkBtnTouch(object sender, EventArgs e)
        {
            Button checkedBtn = (Button) sender;
            simiMilk = checkedBtn.Text;
            FindViewById<Button>(Resource.Id.buttonOrder).Text = 
                Core.OrderUpdater.generateOrder(3, simiMilk, ref orderDrink);
        }

        private void RandomBtnTouch(object sender, EventArgs e)
        {
            Button checkedBtn = (Button)sender;
            simiRandom = checkedBtn.Text;
            FindViewById<Button>(Resource.Id.buttonOrder).Text =
                Core.OrderUpdater.generateOrder(4, simiRandom, ref orderDrink);
        }

        private void SugarBtnTouch(object sender, EventArgs e)
        {
            Button checkedBtn = (Button)sender;
            simiSugar = checkedBtn.Text;
            FindViewById<Button>(Resource.Id.buttonOrder).Text =
                Core.OrderUpdater.generateOrder(5, simiSugar, ref orderDrink);
        }

        private void GauPoBtnTouch(object sender, EventArgs e)
        {
            Button checkedBtn = (Button)sender;
            simiGauPo = checkedBtn.Text;
            FindViewById<Button>(Resource.Id.buttonOrder).Text =
                Core.OrderUpdater.generateOrder(6, simiGauPo, ref orderDrink);
        }
    }
}


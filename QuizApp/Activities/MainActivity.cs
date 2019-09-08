using System;
using System.Drawing;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace QuizApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        private CardView historyCardView;
        private CardView geographyCardView;
        private CardView spaceCardView;
        private CardView businessCardView;
        private CardView engineeringCardView;
        private CardView programmingCardView;

        private Toolbar toolbar;
        private DrawerLayout drawerLayout;
        private NavigationView navigationView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            InitCategoryCardViews();
            InitToolbar();
            InitNavigationDrawer();
        }

        private void InitCategoryCardViews()
        {
            historyCardView = FindViewById<CardView>(Resource.Id.historyCardView);
            geographyCardView = FindViewById<CardView>(Resource.Id.geographyCardView);
            businessCardView = FindViewById<CardView>(Resource.Id.businessCardView);
            engineeringCardView = FindViewById<CardView>(Resource.Id.engineeringCardView);
            spaceCardView = FindViewById<CardView>(Resource.Id.spaceCardView);
            programmingCardView = FindViewById<CardView>(Resource.Id.programmingCardView);

            historyCardView.Click += OnCategoryCardView_Clicked;
            geographyCardView.Click += OnCategoryCardView_Clicked;
            businessCardView.Click += OnCategoryCardView_Clicked;
            engineeringCardView.Click += OnCategoryCardView_Clicked;
            spaceCardView.Click += OnCategoryCardView_Clicked;
            programmingCardView.Click += OnCategoryCardView_Clicked;
        }

        private void OnCategoryCardView_Clicked(object sender, EventArgs args)
        {
            var clickedCardView = (CardView) sender;
            switch (clickedCardView.Id)
            {
                case Resource.Id.historyCardView:
                    InitActivityForCategory("History");
                    break;
                case Resource.Id.geographyCardView:
                    InitActivityForCategory("Geography");
                    break;
                case Resource.Id.businessCardView:
                    InitActivityForCategory("Business");
                    break;
                case Resource.Id.engineeringCardView:
                    InitActivityForCategory("Engineering");
                    break;
                case Resource.Id.spaceCardView:
                    InitActivityForCategory("Space");
                    break;
                case Resource.Id.programmingCardView:
                    InitActivityForCategory("Programming");
                    break;
            }
        }

        private void InitActivityForCategory(string category)
        {
            var intent = new Intent(this, typeof(DescriptionActivity));
            intent.PutExtra("Category", category);
            StartActivity(intent);

            drawerLayout.CloseDrawers();
        }

        private void InitToolbar()
        {
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "Quiz App";
            toolbar.SetTitleTextColor(Color.White.ToArgb());
            SetSupportActionBar(toolbar);

            var hamburgerDrawable = GetDrawable(Resource.Drawable.hamburger);
            hamburgerDrawable.SetTint(Color.White.ToArgb());

            var supportActionBar = SupportActionBar;
            supportActionBar.SetHomeAsUpIndicator(hamburgerDrawable);
            supportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        private void InitNavigationDrawer()
        {
            navigationView = FindViewById<NavigationView>(Resource.Id.navigationView);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
        }

        private void NavigationView_NavigationItemSelected(object sender,
            NavigationView.NavigationItemSelectedEventArgs e)
        {
            var selectedItemResourceId = e.MenuItem.ItemId;
            switch (selectedItemResourceId)
            {
                case Resource.Id.navGeography:
                    InitActivityForCategory("Geography");
                    break;
                case Resource.Id.navHistory:
                    InitActivityForCategory("History");
                    break;
                case Resource.Id.navEngineering:
                    InitActivityForCategory("Engineering");
                    break;
                case Resource.Id.navBusiness:
                    InitActivityForCategory("Business");
                    break;
                case Resource.Id.navProgramming:
                    InitActivityForCategory("Programming");
                    break;
                case Resource.Id.navSpace:
                    InitActivityForCategory("Space");
                    break;
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer((int) GravityFlags.Left);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
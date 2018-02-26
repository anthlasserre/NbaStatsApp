using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Android.Views;

namespace NbaStats
{
    [Activity(Label = "Nba Stats")]
    public class SearchPlayer : Activity
    {
        private EditText inputPlayerSearch;
        private Button searchButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Search);

            inputPlayerSearch = FindViewById<EditText>(Resource.Id.inputPlayerSearch);
            searchButton = FindViewById<Button>(Resource.Id.searchButton);

            searchButton.Click += delegate
            {
                string inputPlayer = inputPlayerSearch.Text;
                int firstSpaceIndex = inputPlayer.IndexOf(" ");

                string firstName = inputPlayer.Substring(0, firstSpaceIndex);
                string lastName = inputPlayer.Substring(firstSpaceIndex).Trim();

                var uri = new Uri("https://nba-players.herokuapp.com/players-stats/" + lastName + "/" + firstName).ToString();

                Console.WriteLine("----------Début----------");

                Console.WriteLine(firstName);
                Console.WriteLine(lastName);
                Console.WriteLine(uri);

                Console.WriteLine("-----------Fin-----------");

                Intent intent = new Intent(this, typeof(PlayerActivity));
                Bundle extras = new Bundle();
                extras.PutString("uri", uri);
                extras.PutString("firstname", firstName);
                extras.PutString("lastname", lastName);
                intent.PutExtras(extras);
                StartActivity(intent);
            };

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.main_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Intent intent = new Intent(this, typeof(SearchPlayer));
            Bundle extras = new Bundle();
            StartActivity(intent);
            return base.OnOptionsItemSelected(item);
        }

    }


}


using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace NBAStats
{
    [Activity(Label = "NBA Stats", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private EditText inputPlayerSearch;
        private Button searchButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            inputPlayerSearch = FindViewById<EditText>(Resource.Id.inputPlayerSearch);
            searchButton = FindViewById<Button>(Resource.Id.searchButton);

            searchButton.Click += delegate
            {
                string inputPlayer = inputPlayerSearch.Text;
                int firstSpaceIndex = inputPlayer.IndexOf(" ");

                string firstName = inputPlayer.Substring(0, firstSpaceIndex);
                string lastName = inputPlayer.Substring(firstSpaceIndex).Trim();

                var uri = new Uri("http://api.suredbits.com/nba/v0/players/" + lastName + "/" + firstName).ToString();


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

    }


}


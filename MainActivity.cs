using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using System.Collections.Generic;
using System.Linq;
using Android.Views;

namespace NbaStats
{
    [Activity(Label = "Nba Stats", MainLauncher = true)]
    public class MainActivity : Activity
    {
        string[] items;
        ListView teamsList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            items = new string[]{
            "Golden State Warriors","Los Angeles Clippers","Los Angeles Lakers",
            "Phoenix Suns","Sacramento Kings","Dallas Mavericks","Houston Rockets",
            "Memphis Grizzlies","New Orleans Pelicans","San Antonio Spurs",
            "Denver Nuggets","Minnesota Timberwolves","Oklahoma City Thunder",
            "Portland Trail Blazers","Utah Jazz","Boston Celtics","Brooklyn Nets",
            "New York Knicks","Philadelphia 76ers","Toronto Raptors","Chicago Bulls",
            "Cleveland Cavaliers","Detroit Pistons","Indiana Pacers","Milwaukee Bucks",
            "Atlanta Hawks","Charlotte Hornets","Miami Heat","Orlando Magic",
            "Washington Wizards"
        };

            // Création du dictionnaire
            Dictionary<string, string> teamsAcronym;
            teamsAcronym = new Dictionary<string, string>
            {
                { "Golden State Warriors","gsw" },
                { "Los Angeles Clippers","lac" },
                { "Los Angeles Lakers","lal" },
                { "Phoenix Suns","pho" },
                { "Sacramento Kings","sac" },
                { "Dallas Mavericks","dal" },
                { "Houston Rockets","hou" },
                { "Memphis Grizzlies","mem" },
                { "New Orleans Pelicans","nor" },
                { "San Antonio Spurs","sas" },
                { "Denver Nuggets","den" },
                { "Minnesota Timberwolves","min" },
                { "Oklahoma City Thunder","okc" },
                { "Portland Trail Blazers","por" },
                { "Utah Jazz","uth" },
                { "Boston Celtics","bos" },
                { "Brooklyn Nets","bro" },
                { "New York Knicks","nyk" },
                { "Philadelphia 76ers","phi" },
                { "Toronto Raptors","tor" },
                { "Chicago Bulls","chi" },
                { "Cleveland Cavaliers","cle" },
                { "Detroit Pistons","det" },
                { "Indiana Pacers","ind" },
                { "Milwaukee Bucks","mil" },
                { "Atlanta Hawks","atl" },
                { "Charlotte Hornets","cha" },
                { "Miami Heat","mia" },
                { "Orlando Magic","orl" },
                { "Washington Wizards","was" }
            };

            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Main);
            teamsList = (ListView)FindViewById<ListView>(Resource.Id.teamsList);
            teamsList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, items);

            teamsList.ItemClick += (s, e) =>
            {
                var t = items[e.Position];
                var myKey = teamsAcronym.FirstOrDefault(x => x.Key == t).Value;

                Console.WriteLine(myKey);

                Intent intent = new Intent(this, typeof(TeamPlayersActivity));
                Bundle extras = new Bundle();
                extras.PutString("key", myKey);
                extras.PutString("team", t);
                intent.PutExtras(extras);
                StartActivity(intent);
                // teamsAcronym.ToList().ForEach((KeyValuePair<string, string> obj) => Console.WriteLine(obj.Key));
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


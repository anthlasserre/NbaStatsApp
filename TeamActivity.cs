using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NbaStats
{
    [Activity(Label = "Teams")]

    public class TeamActivity : Activity
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
                { "Golden State Warriors", "gsw" },
                { "Los Angeles Clippers", "lac" },
                { "Los Angeles Lakers", "lal" }
            };

            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Teams);
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
                intent.PutExtras(extras);
                StartActivity(intent);
                // teamsAcronym.ToList().ForEach((KeyValuePair<string, string> obj) => Console.WriteLine(obj.Key));
            };
        }
    }
}

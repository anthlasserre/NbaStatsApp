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
    [Activity(Label = "Players in Team")]

    public class TeamPlayersActivity : Activity
    {
        List<string> players = new List<string>();
        ListView teamPlayersList;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string teamAcronym = Intent.GetStringExtra("key") ?? "Key not available";
            Console.WriteLine(teamAcronym);

            // CALL API
            string urlTeamPlayers = "https://nba-players.herokuapp.com/players-stats-teams/" + teamAcronym;

            NbaApi nba = new NbaApi();
            var Items = await nba.GetPlayersTeam(urlTeamPlayers);

            if (Items != null)
            {
                for (var i = 0; i < Items.Count; i++)
                {
                    string name = Items[i].name;
                    players.Add(name);
                    Console.WriteLine(name);
                }
                Console.WriteLine(players);
            }

            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.TeamPlayers);
            teamPlayersList = (ListView)FindViewById<ListView>(Resource.Id.teamPlayersList);
            teamPlayersList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, players);

            teamPlayersList.ItemClick += (s, e) =>
            {
                var t = players[e.Position];
                int firstSpaceIndex = t.IndexOf(" ");
                string firstName = t.Substring(0, firstSpaceIndex);
                string lastName = t.Substring(firstSpaceIndex).Trim();

                var uri = new Uri("https://nba-players.herokuapp.com/players-stats/" + lastName + "/" + firstName).ToString();
            
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

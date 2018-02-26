using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace NbaStats
{
    
    [Activity(Label = "@string/teamPlayers")]

    public class TeamPlayersActivity : Activity
    {
        List<string> players = new List<string>();
        ListView teamPlayersList;

        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            string team = Intent.GetStringExtra("team") ?? "Team not available";
            Window.SetTitle(team);
        }

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            string team = Intent.GetStringExtra("team") ?? "Team not available";
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

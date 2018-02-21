using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Square.Picasso;
using Android.Content;

namespace NbaStats
{
    [Activity(Label = "Nba Stats", MainLauncher = false)]
    public class PlayerActivity : Activity
    {
        private ImageView playerPicture;
        private TextView playerName;
        private TextView playerTeam;
        private ImageView playerTeamPicture;
        private TextView playerGames;
        private TextView playerPoints;
        private TextView playerAssist;
        private TextView playerRebounds;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Player);

            playerPicture = FindViewById<ImageView>(Resource.Id.playerPicture);
            playerName = FindViewById<TextView>(Resource.Id.playerName);
            playerTeam = FindViewById<TextView>(Resource.Id.playerTeam);
            playerGames = FindViewById<TextView>(Resource.Id.playerGames);
            playerTeamPicture = FindViewById<ImageView>(Resource.Id.playerTeamPicture);
            playerPoints = FindViewById<TextView>(Resource.Id.playerPoints);
            playerAssist = FindViewById<TextView>(Resource.Id.playerAssist);
            playerRebounds = FindViewById<TextView>(Resource.Id.playerRebounds);

            int resource = Resources.GetIdentifier("no_player", "drawable", Application.Context.PackageName);

            string uri = Intent.Extras.GetString("uri");
            string firstname = Intent.Extras.GetString("firstname");
            string lastname = Intent.Extras.GetString("lastname");

            // Console.WriteLine(uri);

            NbaApi nba = new NbaApi();
            var Items = await nba.GetPlayerStats(uri);

            if (Items != null)
            {
                // Init Player Data

                // INFO
                string name = Items.name;
                string team_acronym = Items.team_acronym;
                string team_name = Items.team_name;

                // STATS
                string games_played = Items.games_played;
                string minutes_per_game = Items.minutes_per_game;
                string field_goals_attempted_per_game = Items.field_goals_attempted_per_game;
                string field_goals_made_per_game = Items.field_goals_made_per_game;
                string field_goal_percentage = Items.field_goal_percentage;
                string free_throw_percentage = Items.free_throw_percentage;
                string three_point_attempted_per_game = Items.three_point_attempted_per_game;
                string three_point_made_per_game = Items.three_point_made_per_game;
                string three_point_percentage = Items.three_point_percentage;
                string points_per_game = Items.points_per_game;
                string offensive_rebounds_per_game = Items.offensive_rebounds_per_game;
                string defensive_rebounds_per_game = Items.defensive_rebounds_per_game;
                string rebounds_per_game = Items.rebounds_per_game;
                string assists_per_game = Items.assists_per_game;
                string steals_per_game = Items.steals_per_game;
                string blocks_per_game = Items.blocks_per_game;
                string turnovers_per_game = Items.turnovers_per_game;
                string player_efficiency_rating = Items.player_efficiency_rating;

                // Principal strings in use
                string points = Items.points_per_game;
                string assists = Items.assists_per_game;
                string rebounds = Items.rebounds_per_game;

                // pictures
                string picturePlayer = "https://nba-players.herokuapp.com/players/" + lastname + "/" + firstname;
                int picturePlayerTeam = Resources.GetIdentifier(team_acronym, "drawable", Application.Context.PackageName);


                // Load Pictures
                Picasso.With(this).Load(picturePlayer).Into(playerPicture);
                playerTeamPicture.SetImageResource(picturePlayerTeam);

                // Load Text
                playerName.Text = name;
                playerTeam.Text = team_name;
                /////
                playerGames.Text = games_played;
                playerPoints.Text = points;
                playerAssist.Text = assists;
                playerRebounds.Text = rebounds;


                // Show in console
                Console.WriteLine("---- URI Player ----");
                Console.WriteLine(uri);
                Console.WriteLine("---- Get Data Player ----");
                Console.WriteLine("Fullname: " + name);
                Console.WriteLine("Team ID: " + team_acronym);
                Console.WriteLine("Team Full: " + team_name);
                Console.WriteLine("Player Picture: " + picturePlayerTeam);
                Console.WriteLine("Team Picture: " + picturePlayer);
                Console.WriteLine("---- Get Data Player Details ----");
                Console.WriteLine("Points: " + points);
                Console.WriteLine("Asssits: " + assists);
                Console.WriteLine("Rebounds: " + rebounds);
                Console.WriteLine("---------------------------------");

            }



        }

    }




}


using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Square.Picasso;
using Android.Content;

namespace NBAStats
{
    [Activity(Label = "NBA Stats", MainLauncher = true)]
    public class PlayerActivity : Activity
    {
        private ImageView playerPicture;
        private TextView playerName;
        // private TextView playerNumber;
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
            // playerNumber = FindViewById<TextView>(Resource.Id.playerNumber);
            playerPoints = FindViewById<TextView>(Resource.Id.playerPoints);
            playerAssist = FindViewById<TextView>(Resource.Id.playerAssist);
            playerRebounds = FindViewById<TextView>(Resource.Id.playerRebounds);

            int resource = Resources.GetIdentifier("bryant", "drawable", Application.Context.PackageName);

            string uri = Intent.Extras.GetString("uri");
            string firstname = Intent.Extras.GetString("firstname");
            string lastname = Intent.Extras.GetString("lastname");

            Console.WriteLine(uri);

            NbaApi nba = new NbaApi();
            var Items = await nba.GetPlayerInfo(uri);

            if (Items.Count != 0)
            {

                // Init Player Data
                string name = Items[0].fullName;
                int number = Items[0].uniformNumber;
                int weight = Items[0].weight;
                string height = Items[0].height;
                string birthdate = Items[0].birthDate.Substring(0, 4);
                string status = Items[0].status;
                string team = Items[0].team;
                string position = Items[0].position;

                // Reformat Height in CM
                // string foot = height.Substring(0,1).Trim();
                // string inches = height.Substring(2,3).Trim();
                // int heightFormated = (Convert.ToInt16(foot) * 12) + Convert.ToInt16(inches);

                string picturePlayer = "https://nba-players.herokuapp.com/players/" + lastname + "/" + firstname;
                Picasso.With(this).Load(picturePlayer).Into(playerPicture);
                
                Console.WriteLine("---- Get Data Player ----");
                Console.WriteLine("Fullname: " + Items[0].fullName);
                Console.WriteLine("Number: " + Items[0].uniformNumber);
                // Console.WriteLine("Height: " + heightFormated);
                // Console.WriteLine("Height: " + foot + "--" + inches);
                Console.WriteLine("Birthdate: " + birthdate);
                Console.WriteLine("Status: " + status);
                Console.WriteLine("Team: " + team);
                Console.WriteLine("Position: " + position);
                Console.WriteLine("-------------------------");

                playerName.Text = Items[0].fullName;
                // playerNumber.Text = Items[0].uniformNumber.ToString();


                int playerId = Items[0].playerId;

                string uriPlayer = "https://nba-players.herokuapp.com/players-stats/" + lastname + "/" + firstname;

                Console.WriteLine("---- URI Player ----");
                Console.WriteLine(uri);
                Console.WriteLine(uriPlayer);
                Console.WriteLine("--------------------");

                var Items2 = await nba.GetPlayerStats(uriPlayer);

                if (Items2 == null) {
                    uriPlayer = "https://nba-players.herokuapp.com/players-stats/" + lastname + "/" + firstname;
                }

                if (Items2 != null)
                {
                    // Init Player Data Details

                    string points = Items2.points_per_game;
                    string assists = Items2.assists_per_game;
                    string rebounds = Items2.rebounds_per_game;

                    playerPoints.Text = points;
                    playerAssist.Text = assists;
                    playerRebounds.Text = rebounds;

                    Console.WriteLine("---- Get Data Player Details ----");
                    Console.WriteLine("Points: " + points);
                    Console.WriteLine("Asssits: " + assists);
                    Console.WriteLine("Rebounds: " + rebounds);
                    Console.WriteLine("---------------------------------");

                } else {
                    Console.WriteLine("---- Get Data Player Details ----");
                    Console.WriteLine("We've not found some details data of this player");
                    Console.WriteLine("---------------------------------");
                }

            }






        }

    }




}


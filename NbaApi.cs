using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Android.Content;
using Newtonsoft.Json;

namespace NbaStats
{
    
    public class NbaApi
    {

        public NbaApi()
        {
        }

        public async Task<RootObject> GetPlayerStats(string uri)
        {
            HttpClient myClient = new HttpClient();

            RootObject Items = null;

            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<RootObject>(content);

            }

            return Items;
        }

        public async Task<List<RootObject>> GetPlayersTeam(string uri)
        {
            HttpClient myClient = new HttpClient();

            List<RootObject> Items = null;

            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<List<RootObject>>(content);

            }

            return Items;
        }

    }

    public class RootObject
    {
        public string name { get; set; }
        public string team_acronym { get; set; }
        public string team_name { get; set; }
        public string games_played { get; set; }
        public string minutes_per_game { get; set; }
        public string field_goals_attempted_per_game { get; set; }
        public string field_goals_made_per_game { get; set; }
        public string field_goal_percentage { get; set; }
        public string free_throw_percentage { get; set; }
        public string three_point_attempted_per_game { get; set; }
        public string three_point_made_per_game { get; set; }
        public string three_point_percentage { get; set; }
        public string points_per_game { get; set; }
        public string offensive_rebounds_per_game { get; set; }
        public string defensive_rebounds_per_game { get; set; }
        public string rebounds_per_game { get; set; }
        public string assists_per_game { get; set; }
        public string steals_per_game { get; set; }
        public string blocks_per_game { get; set; }
        public string turnovers_per_game { get; set; }
        public string player_efficiency_rating { get; set; }
    }

}

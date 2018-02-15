using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NBAStats
{
    public class NbaApi
    {

        public NbaApi()
        {
        }

        public async Task<List<RootObject>> GetPlayerInfo(string uri)
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

        public async Task<RootObject2> GetPlayerStats(string uriPlayer)
        {
            HttpClient myClient2 = new HttpClient();

            RootObject2 Items2 = null;

            var response2 = await myClient2.GetAsync(uriPlayer);
            if (response2.IsSuccessStatusCode)
            {
                var content2 = await response2.Content.ReadAsStringAsync();
                Items2 = JsonConvert.DeserializeObject<RootObject2>(content2);

            }

            return Items2;
        }

    }


    public class RootObject
    {
        public int lastYear { get; set; }
        public int weight { get; set; }
        public int rookieYear { get; set; }
        public int uniformNumber { get; set; }
        public string fullName { get; set; }
        public string height { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string birthDate { get; set; }
        public string profileUrl { get; set; }
        public string status { get; set; }
        public string team { get; set; }
        public int playerId { get; set; }
        public string position { get; set; }
    }


    public class RootObject2
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace test0614_ReadNBA_games {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            System.Net.WebClient objWebClient = new System.Net.WebClient();
            objWebClient.DownloadFile(
                "http://data.nba.com/json/cms/noseason/scoreboard/20161105/games.json",
                @"c:\temp\nba.txt"
            );
            button1.Text = "OK";
        }

        private void button2_Click(object sender, EventArgs e) {
            System.IO.StreamReader r =
                new System.IO.StreamReader(@"c:\temp\nba.txt");
            string jsonString = r.ReadToEnd();
            r.Close();

            JObject obj = JObject.Parse(jsonString);

            JToken objToken = obj.SelectToken(
                "sports_content.sports_meta.season_meta.calendar_date");

            textBox1.Text += objToken.ToString()
                + System.Environment.NewLine + System.Environment.NewLine;

            objToken = obj.SelectToken(
                "sports_content.sports_meta.season_meta");

            string s = objToken.Value<string>("calendar_date");

            textBox1.Text += s
                + System.Environment.NewLine + System.Environment.NewLine;


            var gameList = obj.SelectToken("sports_content.games.game");
            foreach (JToken game in gameList) {
                string sMatchup = string.Format("{0}@{1}",
                      game.SelectToken("visitor.team_key")
                    , game.SelectToken("home").Value<string>("team_key")
                    );
                textBox1.Text += sMatchup
                + System.Environment.NewLine + System.Environment.NewLine;
            }


            button2.Text = "OK";
        }
    }
}

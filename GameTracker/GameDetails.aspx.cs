using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required to connect to EF db
using GameTracker.Models;
using System.Web.ModelBinding;
namespace GameTracker
{
    public partial class Game_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if ((!IsPostBack) && (Request.QueryString.Count > 0)) {
                this.GetGame();

            }
        }

        protected void GetGame() {
            //populate form with existing Game record
            int GameID = Convert.ToInt32(Request.QueryString["GameID"]);
            //connect to database with ef
            using (GameTrackerConn db = new GameTrackerConn()) {
                //populate Game instance with Game id with url param
                Game updatedGame = (from game in db.Games
                                    where game.GameID == GameID
                                    select game).FirstOrDefault();

                Player playerList = (from playerRecords in db.Players
                                    select playerRecords).FirstOrDefault();


                if (updatedGame != null) {
                    NameTextBox.Text = updatedGame.Name.ToString();
                    DescriptionTextBox.Text = updatedGame.Description.ToString();
                    SpectatorsTextBox.Text = updatedGame.Spectators.ToString();
                    DatePlayedTextBox.Text = updatedGame.DatePlayed.ToString("yyyy-MM-dd");


                }else {

                    ANameTextBox.DataSource = playerList;
                    ANameTextBox.DataBind();

                    BNameTextBox.DataSource = playerList;
                    BNameTextBox.DataBind();

                }

            }
        }
        protected void CancelButton_Click(object sender, EventArgs e) {
            // Redirect back to Games page
            Response.Redirect("~/Default.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e) {
            // Use EF to connect to the server
            using (GameTrackerConn db = new GameTrackerConn()) {
                // use the Game model to create a new Game object and
                // save a new record
                Game newGame = new Game();

                int GameID = 0;

                if (Request.QueryString.Count > 0) // our URL has a GameID in it
                {
                    // get the id from the URL
                    GameID = Convert.ToInt32(Request.QueryString["GameID"]);

                    // get the current Game from EF DB
                    newGame = (from game in db.Games
                                 where game.GameID == GameID
                                 select game).FirstOrDefault();
                }

                // add form data to the new Game record
                newGame.Name = NameTextBox.Text;
                newGame.Description = DescriptionTextBox.Text;
                newGame.Spectators = Convert.ToInt32(SpectatorsTextBox.Text);
                newGame.DatePlayed = Convert.ToDateTime(DatePlayedTextBox.ToString());

                // use LINQ to ADO.NET to add / insert new Game into the database

                if (GameID == 0) {
                    db.Games.Add(newGame);
                }


                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated Games page
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}
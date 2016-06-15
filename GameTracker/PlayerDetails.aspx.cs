using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements required for EF DB access
using GameTracker.Models;
using System.Web.ModelBinding;

namespace GameTracker
{
    public partial class PlayerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetPlayer();

            }
        }

        protected void GetPlayer()
        {
            //populate form with existing student record
            int PlayerID = Convert.ToInt32(Request.QueryString["PlayerID"]);
            //connect to database with ef
            using (GameTrackerConn db = new GameTrackerConn())
            {
                //populate student instance with student id with url param
                Player updatedPlayer = (from player in db.Players
                                          where player.PlayerID == PlayerID
                                          select player).FirstOrDefault();

                if (updatedPlayer != null)
                {
                    NameTextBox.Text = updatedPlayer.Name.ToString();
                    AgeTextBox.Text = updatedPlayer.Age.ToString();
                    GenderTextBox.Text = updatedPlayer.Gender.ToString(); 
                }

            }
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Students page
            Response.Redirect("~/Players.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (GameTrackerConn db = new GameTrackerConn())
            {
                // use the Student model to create a new student object and
                // save a new record
                Player newPlayer = new Player();

                int PlayerID = 0;

                if (Request.QueryString.Count > 0) // our URL has a PlayerID in it
                {
                    // get the id from the URL
                    PlayerID = Convert.ToInt32(Request.QueryString["PlayerID"]);

                    // get the current student from EF DB
                    newPlayer = (from player in db.Players
                                  where player.PlayerID == PlayerID
                                  select player).FirstOrDefault();
                }

                // add form data to the new student record
                newPlayer.Name = NameTextBox.Text;
                newPlayer.Age = Convert.ToInt32(AgeTextBox.Text);
                newPlayer.Gender = GenderTextBox.Text;

                // use LINQ to ADO.NET to add / insert new student into the database

                if (PlayerID == 0)
                {
                    db.Players.Add(newPlayer);
                }


                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/Players.aspx");
            }
        }
    }
}
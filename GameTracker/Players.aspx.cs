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
    public partial class Players : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate the student grid
            if (!IsPostBack)
            {
                Session["SortColumn"] = "PlayerID"; // default sort column
                Session["SortDirection"] = "ASC";
                // Get the student data
                this.GetPlayers();
            }
        }

        /**
         * <summary>
         * This method gets the student data from the DB
         * </summary>
         * 
         * @method GetPlayers
         * @returns {void}
         */
        protected void GetPlayers()
        {
            // connect to EF
            using (GameTrackerConn db = new GameTrackerConn())
            {
                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                // query the Gridview_template_item_view1 Table using EF and LINQ
                var PlayersList = (from allPlayers in db.Players
                                                    select allPlayers);

                // bind the result to the GridView
                PlayersGridView.DataSource = PlayersList.AsQueryable().OrderBy(SortString).ToList();
                PlayersGridView.DataBind();
            }
        }

        /**
         * <summary>
         * This event handler deletes a student from the db using EF
         * </summary>
         * 
         * @method PlayersGridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs} e
         * @returns {void}
         */
        protected void PlayersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected PlayerID using the Grid's DataKey collection
            int PlayerID = Convert.ToInt32(PlayersGridView.DataKeys[selectedRow].Values["PlayerID"]);

            // use EF to find the selected student in the DB and remove it
            using (GameTrackerConn db = new GameTrackerConn())
            {
                // create object of the Student class and store the query string inside of it
                Player deletedPlayer = (from playerRecords in db.Players
                                          where playerRecords.PlayerID == PlayerID
                                          select playerRecords).FirstOrDefault();

                // remove the selected student from the db
                db.Players.Remove(deletedPlayer);

                // save my changes back to the database
                db.SaveChanges();

                // refresh the grid
                this.GetPlayers();
            }
        }
        


        protected void PlayersGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            // get the column to sorty by
            Session["SortColumn"] = e.SortExpression;

            // Refresh the Grid
            this.GetPlayers();

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        protected void PlayersGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header) // if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();

                    for (int index = 0; index < PlayersGridView.Columns.Count - 1; index++)
                    {
                        if (PlayersGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkbutton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkbutton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkbutton);
                        }
                    }
                }
            }
        }
    }
}
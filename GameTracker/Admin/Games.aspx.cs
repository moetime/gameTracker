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
    public partial class Games : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            // if loading the page for the first time, populate the student grid
            if (!IsPostBack) {
                Session["SortColumn"] = "GameID"; // default sort column
                Session["SortDirection"] = "ASC";
                // Get the student data
                this.GetGames();
            }
        }

        /**
         * <summary>
         * This method gets the student data from the DB
         * </summary>
         * 
         * @method GetGames
         * @returns {void}
         */
        protected void GetGames() {
            // connect to EF
            using (GameTrackerConn db = new GameTrackerConn()) {
                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                // query the Gridview_template_item_view1 Table using EF and LINQ
                var GamesList = (from allGames in db.Games
                                   select allGames);

                // bind the result to the GridView
                GamesGridView.DataSource = GamesList.AsQueryable().OrderBy(SortString).ToList();
                GamesGridView.DataBind();
            }
        }

        

        protected void GamesGridView_Sorting(object sender, GridViewSortEventArgs e) {
            // get the column to sorty by
            Session["SortColumn"] = e.SortExpression;

            // Refresh the Grid
            this.GetGames();

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        protected void GamesGridView_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (IsPostBack) {
                if (e.Row.RowType == DataControlRowType.Header) // if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();

                    for (int index = 0; index < GamesGridView.Columns.Count - 1; index++) {
                        if (GamesGridView.Columns[index].SortExpression == Session["SortColumn"].ToString()) {
                            if (Session["SortDirection"].ToString() == "ASC") {
                                linkbutton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else {
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * @author: Tom Tsiliopoulos
 * @date: May 26, 2016
 * @version: 0.0.1 - added SetActivePage method
 */

namespace GameTracker {
    public partial class Navbar : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            SetActivePage();
        }

        /**
         * This method adds a css class of "active" to list items
         * relating to the current page
         * 
         * @private
         * @method SetActivePage
         * @return {void}
         */
        private void SetActivePage() {
            switch (Page.Title) {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Players":
                    player.Attributes.Add("class", "active");
                    break;
                case "New Players":
                    users.Attributes.Add("class", "active");
                    break;
                case "Game_Details":
                    gamedetails.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}
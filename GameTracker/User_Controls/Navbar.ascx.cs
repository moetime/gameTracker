using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * @author: Irin Avery and Morrice Pfeiffer
 * @date: May 26, 2016
 * @version: 0.0.1 - added SetActivePage method
 */

namespace GameTracker {
    public partial class Navbar : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                // check if a user is logged in
                if (HttpContext.Current.User.Identity.IsAuthenticated) {
                    
                    publicPlaceholder.Visible = false;
                    privatePlaceholder.Visible = true;
                    
                }
                else {
                    // only show login and register
                    publicPlaceholder.Visible = true;
                    privatePlaceholder.Visible = false;
                }
                SetActivePage();
            }

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
                case "Games Menu":
                    games.Attributes.Add("class", "active");
                    break;
                case "Login":
                    login.Attributes.Add("class", "active");
                    break;
                case "Register":
                    register.Attributes.Add("class", "active");
                    break;
                case "Players":
                    players.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}
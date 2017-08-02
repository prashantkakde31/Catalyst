using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Default3 : System.Web.UI.Page
{
    //HelperClass isg = new HelperClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserCode"] = "ADMIN";
        string op;
      //  op = isg.CheckSession("ADMIN", "Add_newScreen.aspx");
    }
}
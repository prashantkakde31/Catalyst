using System;
using System.Web.UI;

public class Tell
{
    public static void text(string str, System.Web.UI.Page currPg)
    {
        ClientScriptManager cs = currPg.ClientScript;
        
        Type csType = currPg.GetType() as Type;
        cs.RegisterStartupScript(csType, "dd", ("<script>swal({title:'',text:'" + str + "'});</script>"));

        
    }
    public static void Alert(string head, string body,System.Web.UI.Page currPg)
    {
        ClientScriptManager cs = currPg.ClientScript;

        Type csType = currPg.GetType() as Type;
        string script = "<script type='text/javascript'>swal({title:'" + head + "',text:'" + body + "',type:'success'});</script>";
        //cs.RegisterStartupScript(csType, "dd", ("<script>swal(\"" + head+"," + "\")</script>"));
        cs.RegisterStartupScript(csType, "dd", (script));

    }
    public static void error(string str, System.Web.UI.Page currPg)
    {
        ClientScriptManager cs = currPg.ClientScript;

        Type csType = currPg.GetType() as Type;
        cs.RegisterStartupScript(csType, "dd", ("<script>swal({title:'',text:'" + str + "',type:'error'});</script>"));
    }
}

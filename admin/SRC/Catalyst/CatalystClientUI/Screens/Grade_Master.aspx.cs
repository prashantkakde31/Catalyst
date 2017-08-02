using Catalyst.Business.Model.ModGradeMaster;
using Catalyst.DataAccess.DataManagers.ModGradeMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalystClientUI
{
    public partial class Grade_Master : System.Web.UI.Page
    {
        GradeMaster obj;
        GradeMasterDataManager obj1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bind();
        }

        protected void grdGradeMaster_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow grid = grdGradeMaster.Rows[e.NewSelectedIndex];
            lblGradeID.Text = ((Label)grid.FindControl("lblID")).Text;
            txtName.Text = ((Label)grid.FindControl("lblName")).Text;
            txtDescription.Text = ((Label)grid.FindControl("lblDescription")).Text;
            // chkVisible.Checked = ((CheckBox)grid.FindControl("chkVisible1")).Checked;
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {

            obj = new GradeMaster();
            obj.Grade = txtName.Text;
            obj.Description = txtDescription.Text;
            //obj.IsVisible = chkVisible.Checked;
            obj.CreatedBy = 1;
            obj.UpdatedBy = 1;
            obj.GradeID = Convert.ToInt16(lblGradeID.Text);
            if (lblGradeID.Text.Equals("-1"))
            {
                obj1 = new GradeMasterDataManager();
                obj1.AddGradeDetail(obj);
                msgbox("Grade Added successfully!!!");
            }
            else
            {
                obj1 = new GradeMasterDataManager();
                obj1.UpdateGradeDetail(obj);
                msgbox("Grade updated successfully!!!");
            }
            Clear();
            bind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            lblGradeID.Text = "-1";
            txtName.Text = "";
            txtDescription.Text = "";
        }
        private void bind()
        {
            obj1 = new GradeMasterDataManager();
            grdGradeMaster.DataSource = obj1.GetGradeList();
            grdGradeMaster.DataBind();
        }

        protected void grdGradeMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete_Grade")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdGradeMaster.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);

                obj1 = new GradeMasterDataManager();
                obj1.DeleteGradeDetail(id);
                Clear();
                bind();
                msgbox("Grade Deleted successfully!!!");
            }
        }
        public void msgbox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'" + message + "'});", true);
        }

        protected void grdGradeMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGradeMaster.PageIndex = e.NewPageIndex;
            bind();
        }

    }
}
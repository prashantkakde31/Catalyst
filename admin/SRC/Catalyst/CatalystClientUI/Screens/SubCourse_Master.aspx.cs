using Catalyst.Business.Model.ModSubCourseMaster;
using Catalyst.DataAccess.DataManagers.ModCourseMaster;
using Catalyst.DataAccess.DataManagers.ModSubCourseMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalystClientUI
{
    public partial class SubCourse_Master : System.Web.UI.Page
    {
        SubCourseMaster obj;
        SubCourseMasterDataManager obj1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdown();
                bind(ddlCourse.SelectedValue);
            }
        }

        protected void grdSubCourseMaster_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            BindDropdown();
            GridViewRow grid = grdSubCourseMaster.Rows[e.NewSelectedIndex];
            lblSubCourseID.Text = ((Label)grid.FindControl("lblID")).Text;
            txtName.Text = ((Label)grid.FindControl("lblName")).Text;
            ddlCourse.SelectedValue = ((Label)grid.FindControl("lblCourseID")).Text;
            // chkVisible.Checked = ((CheckBox)grid.FindControl("chkVisible1")).Checked;
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            lblSubCourseID.Text = "-1";
            txtName.Text = "";
        }
        private void bind(string id)
        {
            if (id.Equals("0"))
            {
                grdSubCourseMaster.DataSource = null;
            }
            else
            {
                obj1 = new SubCourseMasterDataManager();
                grdSubCourseMaster.DataSource = obj1.GetSubCourseListWithCourseID(Convert.ToInt16(id));
            }
            grdSubCourseMaster.DataBind();
        }

        protected void grdSubCourseMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete_SubCourse")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdSubCourseMaster.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);

                obj1 = new SubCourseMasterDataManager();
                obj1.DeleteSubCourseDetail(id);
                Clear();                
                BindDropdown();
                bind(ddlCourse.SelectedValue);
                msgbox("Sub Course Deleted successfully!!!");
            }
        }
        public void msgbox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'" + message + "'});", true);
        }

        protected void grdSubCourseMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSubCourseMaster.PageIndex = e.NewPageIndex;            
            BindDropdown();
            bind(ddlCourse.SelectedValue);
        }
        private void BindDropdown()
        {
            ddlCourse.Items.Clear();
            ddlCourse.DataSource = new CourseMasterDataManager().GetCourseList();
            ddlCourse.DataTextField = "Name";
            ddlCourse.DataValueField = "CourseID";
            ddlCourse.DataBind();
        }

        protected void btnAddSubCourse_Click(object sender, EventArgs e)
        {
            obj = new SubCourseMaster();
            obj.Name = txtName.Text;
            obj.CourseID = Convert.ToInt16(ddlCourse.SelectedValue);
            //obj.IsVisible = chkVisible.Checked;
            obj.CreatedBy = 1;
            obj.UpdatedBy = 1;
            obj.SubCourseID = Convert.ToInt16(lblSubCourseID.Text);
            if (lblSubCourseID.Text.Equals("-1"))
            {
                obj1 = new SubCourseMasterDataManager();
                obj1.AddSubCourseDetail(obj);
                msgbox("Sub Course Added successfully!!!");
            }
            else
            {
                obj1 = new SubCourseMasterDataManager();
                obj1.UpdateSubCourseDetail(obj);
                msgbox("Sub Course updated successfully!!!");
            }
            Clear();            
            BindDropdown();
            bind(ddlCourse.SelectedValue);
        }

        protected void grdSubCourseMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl1 = (Label)e.Row.FindControl("lblCourseID");
                Label lbl2 = (Label)e.Row.FindControl("lblCourseName");

                DataTable dt = new CourseMasterDataManager().GetCourseListWithID(Convert.ToInt16(lbl1.Text));
                if (dt.Rows.Count > 0)
                {
                    lbl2.Text = Convert.ToString(dt.Rows[0]["Name"]);
                }
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind(ddlCourse.SelectedValue);
        }

    }
}
using Catalyst.Business.Model.ModSubjectMaster;
using Catalyst.DataAccess.DataManagers.ModCourseMaster;
using Catalyst.DataAccess.DataManagers.ModSubCourseMaster;
using Catalyst.DataAccess.DataManagers.ModSubjectMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalystClientUI
{
    public partial class Subject_Master : System.Web.UI.Page
    {
        SubjectMaster obj;
        SubjectMasterDataManager obj1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdown();
                bind(ddlSubCourse.SelectedValue);
            }
        }

        protected void grdSubjectMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSubjectMaster.PageIndex = e.NewPageIndex;
            bind(ddlSubCourse.SelectedValue);
        }

        protected void grdSubjectMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete_Subject")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdSubjectMaster.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);

                obj1 = new SubjectMasterDataManager();
                obj1.DeleteSubjectDetail(id);
                Clear();
                bind(ddlSubCourse.SelectedValue);
                msgbox("Subject Deleted successfully!!!");
            }
        }

        protected void grdSubjectMaster_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            BindDropdown();
            GridViewRow grid = grdSubjectMaster.Rows[e.NewSelectedIndex];
            ddlCourse.SelectedValue = ((Label)grid.FindControl("lblCourse")).Text;
            BindDropdown(Convert.ToInt32(ddlCourse.SelectedValue), ddlCourse.SelectedItem.Text);
            ddlSubCourse.SelectedValue = ((Label)grid.FindControl("lblSubCourse")).Text;
            lblSubjectID.Text = ((Label)grid.FindControl("lblID")).Text;
            txtName.Text = ((Label)grid.FindControl("lblName")).Text;
            txtDescription.Text = ((Label)grid.FindControl("lblDescription")).Text;
            ddlSubCourse.SelectedValue = ((Label)grid.FindControl("lblSubCourse")).Text;

        }
        private void Clear()
        {
            lblSubjectID.Text = "-1";
            txtName.Text = "";
            txtDescription.Text = "";
        }
        private void bind(string id)
        {

            if (id.Equals("0") || string.IsNullOrEmpty(id))
            {
                grdSubjectMaster.DataSource = null;
            }
            else
            {
                obj1 = new SubjectMasterDataManager();
                grdSubjectMaster.DataSource = obj1.GetSubjectListWithSubCourseID(Convert.ToInt16(id));
            }
            grdSubjectMaster.DataBind();

        }

        private void BindDropdown(Int32 id, string course)
        {
            ddlSubCourse.Items.Clear();
            if (new SubCourseMasterDataManager().GetSubCourseListWithCourseID(id).Rows.Count > 0)
            {
                ddlSubCourse.DataSource = new SubCourseMasterDataManager().GetSubCourseListWithCourseID(id);
                ddlSubCourse.DataTextField = "Name";
                ddlSubCourse.DataValueField = "SubCourseID";
                ddlSubCourse.DataBind();
            }
            else
            {
                msgbox("No SubCourse Found for Course :" + course);
            }
            ddlSubCourse.Items.Insert(0, new ListItem("Select", "0"));
        }

        private void BindDropdown()
        {
            ddlCourse.Items.Clear();
            ddlCourse.DataSource = new CourseMasterDataManager().GetCourseList();
            ddlCourse.DataTextField = "Name";
            ddlCourse.DataValueField = "CourseID";
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, new ListItem("Select", "0"));
        }
        public void msgbox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'" + message + "'});", true);
        }

        protected void btnAddSubject_Click(object sender, EventArgs e)
        {
            obj = new SubjectMaster();
            obj.Name = txtName.Text;
            obj.Description = txtDescription.Text;
            obj.SubCourseID = Convert.ToInt16(ddlSubCourse.SelectedValue);
            //obj.IsVisible = chkVisible.Checked;
            obj.CreatedBy = 1;
            obj.UpdatedBy = 1;
            obj.SubjectID = Convert.ToInt16(lblSubjectID.Text);
            if (lblSubjectID.Text.Equals("-1"))
            {
                obj1 = new SubjectMasterDataManager();
                obj1.AddSubjectDetail(obj);
                msgbox("Subject Added successfully!!!");
            }
            else
            {
                obj1 = new SubjectMasterDataManager();
                obj1.UpdateSubjectDetail(obj);
                msgbox("Subject updated successfully!!!");
            }
            Clear();
            BindDropdown();
            bind(ddlSubCourse.SelectedValue);

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            BindDropdown();
        }

        protected void grdSubjectMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl1 = (Label)e.Row.FindControl("lblSubCourse");
                Label lbl2 = (Label)e.Row.FindControl("lblSubCourseName");

                Label lbl3 = (Label)e.Row.FindControl("lblCourse");
                Label lbl4 = (Label)e.Row.FindControl("lblCourseName");

                DataTable dt = new SubCourseMasterDataManager().GetSubCourseListWithID(Convert.ToInt16(lbl1.Text));
                if (dt.Rows.Count > 0)
                {
                    lbl2.Text = Convert.ToString(dt.Rows[0]["Name"]);
                }

                dt = new SubCourseMasterDataManager().GetCourseListWithSubCourseID(Convert.ToInt32(lbl1.Text));
                if (dt.Rows.Count > 0)
                {
                    lbl3.Text = Convert.ToString(dt.Rows[0]["CourseID"]);
                    lbl4.Text = Convert.ToString(dt.Rows[0]["Name"]);
                }
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown(Convert.ToInt32(ddlCourse.SelectedValue), ddlCourse.SelectedItem.Text);
        }

        protected void ddlSubCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind(ddlSubCourse.SelectedValue);

        }
    }
}
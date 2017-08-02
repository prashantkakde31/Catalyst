using Catalyst.Business.Model.ModCourseMaster;
using Catalyst.DataAccess.DataManagers.ModCourseMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalystClientUI
{
    public partial class Course_Master : System.Web.UI.Page
    {
        CourseMaster obj;
        CourseMasterDataManager obj1;
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
                bind();
        }

        protected void grdCourseMaster_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow grid = grdCourseMaster.Rows[e.NewSelectedIndex];
            lblCourseID.Text = ((Label)grid.FindControl("lblID")).Text;
            txtName.Text = ((Label)grid.FindControl("lblName")).Text;
            txtDescription.Text = ((Label)grid.FindControl("lblDescription")).Text;
            // chkVisible.Checked = ((CheckBox)grid.FindControl("chkVisible1")).Checked;
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            obj = new CourseMaster();
            obj.Name = txtName.Text;
            obj.Description = txtDescription.Text;
            //obj.IsVisible = chkVisible.Checked;
            obj.CreatedBy = 1;
            obj.UpdatedBy = 1;
            obj.CourseID = Convert.ToInt16(lblCourseID.Text);
            if (lblCourseID.Text.Equals("-1"))
            {
                obj1 = new CourseMasterDataManager();
                obj1.AddCourseDetail(obj);
                msgbox("Course Added successfully!!!");
            }
            else
            {
                obj1 = new CourseMasterDataManager();
                obj1.UpdateCourseDetail(obj);
                msgbox("Course updated successfully!!!");
            }
            Clear();
            bind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            Clear();
        }

        private void Clear()
        {
            lblCourseID.Text = "-1";
            txtName.Text = "";
            txtDescription.Text = "";
        }
        private void bind()
        {
            obj1 = new CourseMasterDataManager();
            grdCourseMaster.DataSource = obj1.GetCourseList();
            grdCourseMaster.DataBind();
        }

        protected void grdCourseMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete_Course")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdCourseMaster.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);

                obj1 = new CourseMasterDataManager();
                obj1.DeleteCourseDetail(id);
                Clear();
                bind();
                msgbox("Course Deleted successfully!!!");
            }
        }
        public void msgbox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'" + message + "'});", true);
        }

        protected void grdCourseMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCourseMaster.PageIndex = e.NewPageIndex;
            bind();
        }

    }
}
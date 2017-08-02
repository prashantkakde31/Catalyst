using Catalyst.Business.Model.ModTestimonial;
using Catalyst.DataAccess.DataManagers.ModTestimonial;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalystClientUI
{
    public partial class Testimonial_Master : System.Web.UI.Page
    {

        TestimonialMaster obj;
        TestimonialMasterDataManager obj1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string filename, filepath, extension;
            if (!fileUpload.HasFile)
            {
                msgbox("select photo to upload");
                return;
            }
            else
            {
                /*Upload Files to folder*/
                filename = Path.GetFileNameWithoutExtension(fileUpload.PostedFile.FileName);
                extension = Path.GetExtension(fileUpload.PostedFile.FileName);
                filepath = Server.MapPath("~/Upload/Testimonial") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                else
                    fileUpload.PostedFile.SaveAs(filepath);
                lblUrl.Text = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            }

            obj = new TestimonialMaster();
            obj.AuthorName = txtAuthor.Text;
            obj.Contents = txtContents.Text;
            obj.Photo = lblUrl.Text;
            //obj.IsVisible = chkVisible.Checked;
            obj.CreatedBy = 1;
            obj.UpdatedBy = 1;
            obj.TestimonialID = Convert.ToInt16(lblTestimonialID.Text);
            if (lblTestimonialID.Text.Equals("-1"))
            {
                obj1 = new TestimonialMasterDataManager();
                obj1.AddTestimonialDetail(obj);
                msgbox("Testimonial Added successfully!!!");
            }
            else
            {
                obj1 = new TestimonialMasterDataManager();
                obj1.UpdateTestimonialDetail(obj);
                msgbox("Testimonial updated successfully!!!");
            }
            Clear();
            bind();
        }

        protected void grdTestimonial_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow grid = grdTestimonial.Rows[e.NewSelectedIndex];
            lblTestimonialID.Text = ((Label)grid.FindControl("lblID")).Text;
            txtAuthor.Text = ((Label)grid.FindControl("lblAuthorName")).Text;
            txtContents.Text = ((Label)grid.FindControl("lblContents")).Text;
            lblUrl.Text = ((Image)grid.FindControl("img1")).ImageUrl.Substring(((Image)grid.FindControl("img1")).ImageUrl.LastIndexOf("/") + 1);
        }

        protected void grdTestimonial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete_Testimonial")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdTestimonial.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);

                obj1 = new TestimonialMasterDataManager();
                obj1.DeleteTestimonialDetail(id);
                Clear();
                bind();
                msgbox("Testimonial Deleted successfully!!!");
            }
        }

        protected void grdTestimonial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTestimonial.PageIndex = e.NewPageIndex;
            bind();
        }
        private void Clear()
        {
            lblTestimonialID.Text = "-1";
            txtAuthor.Text = "";
            txtContents.Text = "";
        }
        private void bind()
        {
            obj1 = new TestimonialMasterDataManager();
            grdTestimonial.DataSource = obj1.GetTestimonialList();
            grdTestimonial.DataBind();
        }
        public void msgbox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'" + message + "'});", true);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            Clear();
        }
    }
}
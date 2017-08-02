using Catalyst.Business.Model.ModProductMaster;
using Catalyst.DataAccess.DataManagers.ModCourseMaster;
using Catalyst.DataAccess.DataManagers.ModCurrencyMaster;
using Catalyst.DataAccess.DataManagers.ModDiscountMaster;
using Catalyst.DataAccess.DataManagers.ModPaperMaster;
using Catalyst.DataAccess.DataManagers.ModProductMaster;
using Catalyst.DataAccess.DataManagers.ModSubCourseMaster;
using Catalyst.DataAccess.DataManagers.ModSubjectMaster;
using Catalyst.DataAccess.DataManagers.ModTopicMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalystClientUI
{
    public partial class Product_Master : System.Web.UI.Page
    {
        ProductMaster obj;
        ProductMasterDataManager obj1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
                BindDropdown();
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            obj = new ProductMaster();
            obj.Name = txtName.Text;
            obj.Description = txtDescription.Text;
            obj.SubjectID = Convert.ToInt16(ddlSubject.SelectedValue);
            obj.DiscountID = Convert.ToInt16(ddlDiscount.SelectedValue);
            obj.YearwisePaperID = Convert.ToInt16(ddlPaper.SelectedValue);
            obj.TopicID = Convert.ToInt16(ddlTopic.SelectedValue);
            obj.Price = Convert.ToDouble("0" + txtPrice.Text);
            obj.BaseCurrency = ddlCurrency.SelectedValue;
            DateTime dt;
            if (DateTime.TryParseExact(txtValidFrom.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                obj.ValidFrom = dt;
            if (DateTime.TryParseExact(txtValidTo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                obj.ValidUpto = dt;
            //obj.IsVisible = chkVisible.Checked;
            obj.CreatedBy = 1;
            obj.UpdatedBy = 1;
            obj.ProductID = Convert.ToInt16(lblProductID.Text);

            if (lblProductID.Text.Equals("-1"))
            {
                obj1 = new ProductMasterDataManager();
                obj1.AddProductDetail(obj);
                msgbox("Product Added successfully!!!");
            }
            else
            {
                obj1 = new ProductMasterDataManager();
                obj1.UpdateProductDetail(obj);
                msgbox("Product updated successfully!!!");
            }
            Clear();
            bind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void grdProductMaster_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            DateTime dt;
            BindDropdown();
            GridViewRow grid = grdProductMaster.Rows[e.NewSelectedIndex];
            ddlCourse.SelectedValue = ((Label)grid.FindControl("lblCourse")).Text;
            ddlDiscount.SelectedValue = ((Label)grid.FindControl("lblDiscountID")).Text;
            BindDropdown(Convert.ToInt32(ddlCourse.SelectedValue), ddlCourse.SelectedItem.Text);
            ddlSubCourse.SelectedValue = ((Label)grid.FindControl("lblSubCourse")).Text;
            BindDropdown2(Convert.ToInt32(ddlSubCourse.SelectedValue), ddlSubCourse.SelectedItem.Text);
            ddlSubject.SelectedValue = ((Label)grid.FindControl("lblSubjectID")).Text;
            BindDropdown3(Convert.ToInt16(ddlSubject.SelectedValue), ddlSubject.SelectedItem.Text);
            ddlTopic.SelectedValue = ((Label)grid.FindControl("lblTopicID")).Text;
            BindDropdown4(Convert.ToInt16(ddlTopic.SelectedValue), ddlTopic.SelectedItem.Text);
            ddlPaper.SelectedValue = ((Label)grid.FindControl("lblYearwisePaperID")).Text;
            lblProductID.Text = ((Label)grid.FindControl("lblID")).Text;
            txtName.Text = ((Label)grid.FindControl("lblName")).Text;
            txtDescription.Text = ((Label)grid.FindControl("lblDescription")).Text;
            txtPrice.Text = Convert.ToDouble(((Label)grid.FindControl("lblPrice")).Text).ToString();
            ddlCurrency.SelectedValue = ((Label)grid.FindControl("lblCurrencyID")).Text;
            if (DateTime.TryParseExact(((Label)grid.FindControl("lblValidFrom")).Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                txtValidFrom.Text = dt.ToString("dd/MM/yyyy");
            if (DateTime.TryParseExact(((Label)grid.FindControl("lblValidTo")).Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                txtValidTo.Text = dt.ToString("dd/MM/yyyy");
        }

        protected void grdProductMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete_Product")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdProductMaster.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);

                obj1 = new ProductMasterDataManager();
                obj1.DeleteProductDetail(id);
                Clear();
                bind();
                msgbox("Product Deleted successfully!!!");
            }
        }

        protected void grdProductMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductMaster.PageIndex = e.NewPageIndex;
            bind();
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown3(Convert.ToInt16(ddlSubject.SelectedValue), ddlSubject.SelectedItem.Text);
        }

        private void Clear()
        {
            lblProductID.Text = "-1";
            txtName.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            ddlCurrency.SelectedValue = "0";
            ddlSubCourse.Items.Clear();
            ddlSubject.Items.Clear();
            ddlTopic.Items.Clear();
            ddlPaper.Items.Clear();
            ddlCourse.SelectedValue = "0";
            ddlDiscount.SelectedValue = "0";
        }
        private void bind()
        {
            obj1 = new ProductMasterDataManager();
            grdProductMaster.DataSource = obj1.GetProductList();
            grdProductMaster.DataBind();
        }
        private void BindDropdown()
        {
            ddlCourse.Items.Clear();
            ddlCourse.DataSource = new CourseMasterDataManager().GetCourseList();
            ddlCourse.DataTextField = "Name";
            ddlCourse.DataValueField = "CourseID";
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, new ListItem("Select", "0"));

            ddlDiscount.Items.Clear();
            ddlDiscount.DataSource = new DiscountMasterDataManager().GetDiscountList();
            ddlDiscount.DataTextField = "Name";
            ddlDiscount.DataValueField = "DiscountID";
            ddlDiscount.DataBind();
            ddlDiscount.Items.Insert(0, new ListItem("Select", "0"));

            ddlCurrency.Items.Clear();
            ddlCurrency.DataSource = new CurrencyMasterDataManager().GetCurrencyList();
            ddlCurrency.DataTextField = "CurrencyName";
            ddlCurrency.DataValueField = "CurrencyID";
            ddlCurrency.DataBind();
            ddlCurrency.Items.Insert(0, new ListItem("Select", "0"));
        }
        private void BindDropdown3(int id, string subject)
        {
            ddlTopic.Items.Clear();
            if (new TopicMasterDataManager().GetTopicsWithSubjectID(id).Rows.Count > 0)
            {
                ddlTopic.DataSource = new TopicMasterDataManager().GetTopicsWithSubjectID(id);
                ddlTopic.DataTextField = "Name";
                ddlTopic.DataValueField = "TopicID";
                ddlTopic.DataBind();
            }
            else
            {
                msgbox("No Topics Found for subject :" + subject);
            }
            ddlTopic.Items.Insert(0, new ListItem("Select", "0"));
        }

        private void BindDropdown2(Int32 id, string subCourse)
        {
            ddlSubject.Items.Clear();
            if (new SubjectMasterDataManager().GetSubjectListWithSubCourseID(id).Rows.Count > 0)
            {
                ddlSubject.DataSource = new SubjectMasterDataManager().GetSubjectListWithSubCourseID(id);
                ddlSubject.DataTextField = "Name";
                ddlSubject.DataValueField = "SubjectID";
                ddlSubject.DataBind();
            }
            else
            {
                msgbox("No Subject Found for Sub Course :" + subCourse);
            }
            ddlSubject.Items.Insert(0, new ListItem("Select", "0"));
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

        private void BindDropdown4(int id, string subject)
        {
            ddlPaper.Items.Clear();
            if (new PaperMasterDataManager().GetPaperListWithTopicID(id).Rows.Count > 0)
            {
                ddlPaper.DataSource = new PaperMasterDataManager().GetPaperListWithTopicID(id);
                ddlPaper.DataTextField = "Name";
                ddlPaper.DataValueField = "PaperID";
                ddlPaper.DataBind();
            }
            else
            {
                msgbox("No Paper Found for Topic :" + subject);
            }
            ddlPaper.Items.Insert(0, new ListItem("Select", "0"));
        }
        public void msgbox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'" + message + "'});", true);
        }

        protected void grdProductMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl1 = (Label)e.Row.FindControl("lblSubjectID");
                Label lbl2 = (Label)e.Row.FindControl("lblSubjectName");

                DataTable dt = new SubjectMasterDataManager().GetSubjectListWithID(Convert.ToInt16(lbl1.Text));
                if (dt.Rows.Count > 0)
                {
                    lbl2.Text = Convert.ToString(dt.Rows[0]["Name"]);
                }

                lbl1 = (Label)e.Row.FindControl("lblDiscountID");
                lbl2 = (Label)e.Row.FindControl("lblDiscountName");
                dt = new DiscountMasterDataManager().GetDiscountListWithID(Convert.ToInt16(lbl1.Text));
                if (dt.Rows.Count > 0)
                {
                    lbl2.Text = Convert.ToString(dt.Rows[0]["Name"]);
                }

                lbl1 = (Label)e.Row.FindControl("lblCurrencyID");
                lbl2 = (Label)e.Row.FindControl("lblCurrencyName");
                dt = new CurrencyMasterDataManager().GetCurrencyListWithID(Convert.ToInt16(lbl1.Text));
                if (dt.Rows.Count > 0)
                {
                    lbl2.Text = Convert.ToString(dt.Rows[0]["CurrencyName"]);
                }

                lbl1 = (Label)e.Row.FindControl("lblTopicID");
                lbl2 = (Label)e.Row.FindControl("lblTopicName");
                dt = new TopicMasterDataManager().GetTopicListWithID(Convert.ToInt16(lbl1.Text));
                if (dt.Rows.Count > 0)
                {
                    lbl2.Text = Convert.ToString(dt.Rows[0]["Name"]);
                }

                lbl1 = (Label)e.Row.FindControl("lblYearwisePaperID");
                lbl2 = (Label)e.Row.FindControl("lblYearwisePaperName");
                dt = new PaperMasterDataManager().GetPaperListWithID(Convert.ToInt16(lbl1.Text));
                if (dt.Rows.Count > 0)
                {
                    lbl2.Text = Convert.ToString(dt.Rows[0]["Name"]);
                }
                dt = new SubjectMasterDataManager().GetSubCourseListWithSubjectID(Convert.ToInt16(((Label)e.Row.FindControl("lblSubjectID")).Text));
                if (dt.Rows.Count > 0)
                {
                    ((Label)e.Row.FindControl("lblSubCourse")).Text = Convert.ToString(dt.Rows[0]["SubCourseID"]);
                    ((Label)e.Row.FindControl("lblSubCourseName")).Text = Convert.ToString(dt.Rows[0]["Name"]);
                }

                dt = new SubCourseMasterDataManager().GetCourseListWithSubCourseID(Convert.ToInt16(((Label)e.Row.FindControl("lblSubCourse")).Text));
                if (dt.Rows.Count > 0)
                {
                    ((Label)e.Row.FindControl("lblCourse")).Text = Convert.ToString(dt.Rows[0]["CourseID"]);
                    ((Label)e.Row.FindControl("lblCourseName")).Text = Convert.ToString(dt.Rows[0]["Name"]);
                }

            }
        }

        protected void ddlTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown4(Convert.ToInt16(ddlTopic.SelectedValue), ddlTopic.SelectedItem.Text);
        }

        protected void ddlSubCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown2(Convert.ToInt32(ddlSubCourse.SelectedValue), ddlSubCourse.SelectedItem.Text);
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown(Convert.ToInt32(ddlCourse.SelectedValue), ddlCourse.SelectedItem.Text);
        }
    }
}
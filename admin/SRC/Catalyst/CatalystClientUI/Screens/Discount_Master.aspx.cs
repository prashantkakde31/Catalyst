using Catalyst.Business.Model.ModDiscountMaster;
using Catalyst.DataAccess.DataManagers.ModDiscountMaster;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalystClientUI
{
    public partial class Discount_Master : System.Web.UI.Page
    {
        DiscountMaster obj;
        DiscountMasterDataManager obj1;
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
                bind();
        }

        protected void grdDiscountMaster_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            DateTime dt;
            GridViewRow grid = grdDiscountMaster.Rows[e.NewSelectedIndex];
            lblDiscountID.Text = ((Label)grid.FindControl("lblID")).Text;
            txtName.Text = ((Label)grid.FindControl("lblName")).Text;
            txtDescription.Text = ((Label)grid.FindControl("lblDescription")).Text;
            txtPercentage.Text = ((Label)grid.FindControl("lblPercentage")).Text;
            if (DateTime.TryParseExact(((Label)grid.FindControl("lblValidFrom")).Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                txtValidFrom.Text = dt.ToString("dd/MM/yyyy");
            if (DateTime.TryParseExact(((Label)grid.FindControl("lblValidTo")).Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                txtValidTo.Text = dt.ToString("dd/MM/yyyy");
            // chkVisible.Checked = ((CheckBox)grid.FindControl("chkVisible1")).Checked;
        }

        protected void btnAddDiscount_Click(object sender, EventArgs e)
        {
            DateTime dt;
            obj = new DiscountMaster();
            obj.Name = txtName.Text;
            obj.Description = txtDescription.Text;
            obj.Percentage = Convert.ToDouble('0' + txtPercentage.Text);
            if (DateTime.TryParseExact(txtValidFrom.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                obj.ValidFrom = dt;
            if (DateTime.TryParseExact(txtValidTo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                obj.ValidTo = dt;
            //obj.IsVisible = chkVisible.Checked;
            obj.CreatedBy = 1;
            obj.UpdatedBy = 1;
            obj.DiscountID = Convert.ToInt16(lblDiscountID.Text);
            if (lblDiscountID.Text.Equals("-1"))
            {
                obj1 = new DiscountMasterDataManager();
                obj1.AddDiscountDetail(obj);
                msgbox("Discount Added successfully!!!");
            }
            else
            {
                obj1 = new DiscountMasterDataManager();
                obj1.UpdateDiscountDetail(obj);
                msgbox("Discount updated successfully!!!");
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
            lblDiscountID.Text = "-1";
            txtName.Text = "";
            txtDescription.Text = "";
            txtPercentage.Text = "";
            txtValidFrom.Text = "";
            txtValidTo.Text = "";
        }
        private void bind()
        {
            obj1 = new DiscountMasterDataManager();
            grdDiscountMaster.DataSource = obj1.GetDiscountList();
            grdDiscountMaster.DataBind();
        }

        protected void grdDiscountMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete_Discount")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridViewRow grid = grdDiscountMaster.Rows[rowIndex];
                int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);

                obj1 = new DiscountMasterDataManager();
                obj1.DeleteDiscountDetail(id);
                Clear();
                bind();
                msgbox("Discount Deleted successfully!!!");
            }
        }
        public void msgbox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'" + message + "'});", true);
        }

        protected void grdDiscountMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDiscountMaster.PageIndex = e.NewPageIndex;
            bind();
        }

    }
}
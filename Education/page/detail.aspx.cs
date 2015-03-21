using System;

namespace page
{
    public partial class page_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCountChar_Click(object sender, EventArgs e)
        {
            lbResult.Text = txtInput.Text.Length.ToString();
        }
    }
}
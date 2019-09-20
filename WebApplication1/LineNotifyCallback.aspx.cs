using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class LineNotifyCallback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //callback頁面取回code
            string code = Request.QueryString["code"].ToString();
            if (!string.IsNullOrEmpty(code) && string.IsNullOrEmpty(this.TextBox1.Text))
            {
                //用code換Token
                var ret = isRock.LineNotify.Utility.GetToeknFromCode(
                    code, "Ub37d9badcf110b80a809262cdb8cd946", //ClientID一定要100%對
                    "drZu92qiML7woRlX/TBs7fuLtmeEYUhV6Rqj7MJOMdrE6+nBSUCNd6fJj8Sh+QBjSHNj+e8Dn/Dtqw17a33GGTuPrEajqb3SjDB6A+qsqgXJBP6tFUa5+PDQLkRkQJjwBIuSuWUWa6IGm4SHBAUMmQdB04t89/1O/w1cDnyilFU=", //ClientSecret 一定要100%對
                    "http://localhost:43970/LineNotifyCallback.aspx" //Callback url一定要100%對
                    );
                this.TextBox1.Text = ret.access_token;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //發送訊息
            isRock.LineNotify.Utility.SendNotify(this.TextBox1.Text, "test" + DateTime.Now.ToString());
        }
    }
}
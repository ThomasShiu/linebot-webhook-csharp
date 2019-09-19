using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        string ChannelAccessToken = "drZu92qiML7woRlX/TBs7fuLtmeEYUhV6Rqj7MJOMdrE6+nBSUCNd6fJj8Sh+QBjSHNj+e8Dn/Dtqw17a33GGTuPrEajqb3SjDB6A+qsqgXJBP6tFUa5+PDQLkRkQJjwBIuSuWUWa6IGm4SHBAUMmQdB04t89/1O/w1cDnyilFU=";
        string UserID = "Ub37d9badcf110b80a809262cdb8cd946";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

            //bot.PushMessage(UserID, "Hi~你好");
            isRock.LineBot.Utility.PushMessage(UserID, "Hi~你好", ChannelAccessToken);
            isRock.LineBot.Utility.PushStickerMessage(UserID, 1, 1, ChannelAccessToken);
            //push text
            //bot.PushMessage(UserID, "test");

            //push sticker
            //bot.PushMessage(UserID, 1, 2);

            //push image
            //bot.PushMessage(UserID, new Uri("https://arock.blob.core.windows.net/blogdata201612/22-124303-d8b2c4de-9a8c-48da-83f1-7c0d36de3ab6.png"));

            //建立actions，作為ButtonTemplate的用戶回覆行為
            //var actions = new List<isRock.LineBot.TemplateActionBase>();
            //actions.Add(new isRock.LineBot.MessageActon()
            //{ label = "點選這邊等同用戶直接輸入某訊息", text = "/例如這樣" });
            //actions.Add(new isRock.LineBot.UriActon()
            //{ label = "點這邊開啟網頁", uri = new Uri("http://www.google.com") });
            //actions.Add(new isRock.LineBot.PostbackActon()
            //{ label = "點這邊發生postack", data = "abc=aaa&def=111" });

            ////單一Button Template Message
            //var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
            //{
            //    altText = "替代文字(在無法顯示Button Template的時候顯示)",
            //    text = "描述文字",
            //    title = "標題",
            //    //設定圖片
            //    thumbnailImageUrl = new Uri("https://i.imgur.com/utrv8p1.png"),
            //    actions = actions //設定回覆動作
            //};

            //發送
            //bot.PushMessage(UserID, ButtonTemplate);
        }
    }
}
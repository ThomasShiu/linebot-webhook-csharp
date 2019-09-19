using LineMessagingAPISDK;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class LineChatController : ApiController
    {
        public static string ChannelAccessToken = "drZu92qiML7woRlX/TBs7fuLtmeEYUhV6Rqj7MJOMdrE6+nBSUCNd6fJj8Sh+QBjSHNj+e8Dn/Dtqw17a33GGTuPrEajqb3SjDB6A+qsqgXJBP6tFUa5+PDQLkRkQJjwBIuSuWUWa6IGm4SHBAUMmQdB04t89/1O/w1cDnyilFU="; // please input the line bot token
        public static string Adminserid = "Ub37d9badcf110b80a809262cdb8cd946";// please input the user id
        public string image_url = "https://i0.wp.com/blog.patw.me/wp-content/uploads/2017/05/ZcNMMLg.png?fit=800%2C416&ssl=1";
        public string mp4_url = "https://www.legacyvet.com/sites/default/files/videos/Video%20%281%29.mp4";
        // 參考位址 https://yingclin.github.io/2017/asp-net-line-messaging-api-basic.html
        //{
        //  "events": [
        //      {
        //        "replyToken": "nHuyWiB7yP5Zw52FIkcQobQuGDXCTA",
        //        "type": "message",
        //        "timestamp": 1462629479859,
        //        "source": {
        //             "type": "user",
        //             "userId": "U206d25c2ea6bd87c17655609a1c37cb8"
        //         },
        //         "message": {
        //             "id": "325708",
        //             "type": "text",
        //             "text": "Hello, world"
        //          }
        //      }
        //  ]
        //}

        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //取得 http Post RawData(should be JSON)
                string postData = Request.Content.ReadAsStringAsync().Result;
                //剖析JSON
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
                string replyMsg="";
                var msg = ReceivedMessage.events[0].message.text;
                msg = msg.ToUpper();
                if (msg.IndexOf("HELP") != -1 || msg.IndexOf("使用說明") != -1 || msg.IndexOf("使用") != -1 || msg.IndexOf("說明") != -1)
                {
                    replyMsg = "使用說明:\r\n輸入底下關鍵字即可顯示相關資訊\r\n" +
                               "[? , help]: 使用說明，包含可用關鍵字等等資訊\r\n" +
                               "[保養完成]:設定某機台保養完成。\r\n" +
                               "[保養時間、預防保養]:查詢機台保養時間與項目。";
                    //v_packageId = '1';
                    //v_stickerId = '407';
                }
                //回覆訊息
               
                //Message = "你說了:" + ReceivedMessage.events[0].message.text + "\n"+ReceivedMessage.events[0].message.id;

                //LogAdmin("有人回應"+ ReceivedMessage.events[0].message.id);
                //回覆用戶

                isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, replyMsg, ChannelAccessToken);

                //回覆API OK
                return Ok();
            }
            catch (Exception ex)
            {

                return Ok();
            }
        }


        [HttpGet]
        private void LogAdmin(string events)
        {
            var bot = new isRock.LineBot.Bot(ChannelAccessToken);
             

            bot.PushMessage(Adminserid, events);
        }


    }
}

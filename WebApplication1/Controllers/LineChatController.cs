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
                //throw ex;
                //回覆訊息
                //isRock.LineBot.Utility.PushMessage(Adminserid, "Exception : \n" + ex.Message, ChannelAccessToken);
                //bot.PushMessage(userid, "Exception : \n" + ex.Message);
                return Ok();
            }
        }


        [HttpGet]
        private void LogAdmin(string events)
        {
            var bot = new isRock.LineBot.Bot(ChannelAccessToken);
             

            bot.PushMessage(Adminserid, events);
        }

        //private LineClient lineClient = new LineClient(ChannelAccessToken);
        //[HttpPost]
        //public IHttpActionResult POST2(){

        //    var content = async request.Content.ReadAsStringAsync();
        //    Activity activity = JsonConvert.DeserializeObject<Activity>(content);

        //    //回覆API OK
        //    return Ok();
        //}
        //[HttpPost]
        //public IActionResult POST2()
        //{
        //    //get configuration from appsettings.json
        //    var token = ChannelAccessToken;
        //    var AdminUserId = userid;
        //    var body = ""; //for JSON Body
        //                   //create vot instance
        //    var bot = new isRock.LineBot.Bot(token);
        //    isRock.LineBot.TemplateMessageBase responseMsg = null;
        //    //message collection for response multi-message 
        //    List<isRock.LineBot.TemplateMessageBase> responseMsgs =
        //        new List<isRock.LineBot.TemplateMessageBase>();

        //    try
        //    {
        //        //get JSON Body
        //        using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
        //        {
        //            body = reader.ReadToEndAsync().Result;
        //        }
        //        //parsing JSON
        //        var ReceivedMessage = isRock.LineBot.Utility.Parsing(body);
        //        //Get LINE Event
        //        var LineEvent = ReceivedMessage.events.FirstOrDefault();
        //        //prepare reply message
        //        if (LineEvent.type.ToLower() == "message")
        //        {
        //            switch (LineEvent.message.type.ToLower())
        //            {
        //                case "text":
        //                    //add text response
        //                    responseMsg =
        //                        new isRock.LineBot.Utility.TextMessage($"you said : {LineEvent.message.text}");
        //                    responseMsgs.Add(responseMsg);
        //                    //add ButtonsTemplate if user say "/Show ButtonsTemplate"
        //                    if (LineEvent.message.text.ToLower().Contains("/show buttonstemplate"))
        //                    {
        //                        //define actions
        //                        var act1 = new isRock.LineBot.MessageActon()
        //                        { text = "test action1", label = "test action1" };
        //                        var act2 = new isRock.LineBot.MessageActon()
        //                        { text = "test action2", label = "test action2" };

        //                        var tmp = new isRock.LineBot.ButtonsTemplate()
        //                        {
        //                            text = "Button Template text",
        //                            title = "Button Template title",
        //                            thumbnailImageUrl = new Uri("https://i.imgur.com/wVpGCoP.png"),
        //                        };

        //                        tmp.actions.Add(act1);
        //                        tmp.actions.Add(act2);
        //                        //add TemplateMessage into responseMsgs
        //                        responseMsgs.Add(new isRock.LineBot.TemplateMessageBase(tmp));
        //                    }
        //                    break;
        //                case "sticker":
        //                    responseMsg =
        //                    new isRock.LineBot.StickerMessage(1, 2);
        //                    responseMsgs.Add(responseMsg);
        //                    break;
        //                default:
        //                    responseMsg = new isRock.LineBot.TextMessage($"None handled message type : { LineEvent.message.type}");
        //                    responseMsgs.Add(responseMsg);
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            responseMsg = new isRock.LineBot.TextMessage($"None handled event type : { LineEvent.type}");
        //            responseMsgs.Add(responseMsg);
        //        }

        //        //回覆訊息
        //        bot.ReplyMessage(LineEvent.replyToken, responseMsgs);
        //        //response OK
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        //回覆訊息
        //        bot.PushMessage(AdminUserId.Value, "Exception : \n" + ex.Message);
        //        //response OK
        //        return Ok();
        //    }
        //}
    }
}

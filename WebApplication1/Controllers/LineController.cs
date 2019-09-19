using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.App_Start;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("line")]
    public class LineController : ApiController
    {
        [HttpPost]
        [Route]
        [Signature]
        public IHttpActionResult webhook([FromBody] LineWebhookModels data)
        {
            if (data == null) return BadRequest();
            if (data.events == null) return BadRequest();

            foreach (Event e in data.events)
            {
                if (e.type == EventType.message)
                {
                    ReplyBody rb = new ReplyBody()
                    {
                        replyToken = e.replyToken,
                        messages = procMessage(e.message)
                    };
                    Reply reply = new Reply(rb);
                    reply.send();


                }
            }
            return Ok(data);
        }

        private List<SendMessage> procMessage(ReceiveMessage m)
        {
            List<SendMessage> msgs = new List<SendMessage>();
            SendMessage sm = new SendMessage()
            {
                type = Enum.GetName(typeof(MessageType), m.type)
            };
            switch (m.type)
            {
                case MessageType.sticker:
                    sm.packageId = m.packageId;
                    sm.stickerId = m.stickerId;
                    break;
                case MessageType.text:

                    sm.text = procMessageStr(m.text);
                    
                    break;
                default:
                    sm.type = Enum.GetName(typeof(MessageType), MessageType.text);
                    sm.text = "很抱歉，我只是一隻回音機器人，目前只能回覆基本貼圖與文字訊息喔！";
                    break;
            }
            msgs.Add(sm);
            return msgs;
        }

        private string procMessageStr(string m)
        {
            var replymess = m;

            if (m.IndexOf("help") != -1)
            {
                replymess = "使用說明:\r\n輸入底下關鍵字即可顯示相關資訊\r\n" +
                       "[? , help]: 使用說明，包含可用關鍵字等等資訊\r\n" +
                       "[保養完成]:設定某機台保養完成。\r\n" +
                       "[保養時間、預防保養]:查詢機台保養時間與項目。";
            }
            else if (m.IndexOf("設備保養") != -1)
            {
                replymess = "設備保養時間\r\n" +
                       "每日\r\n" +
                       "每周\r\n" +
                       "每月";
            }
            return replymess;
        }
    }
}
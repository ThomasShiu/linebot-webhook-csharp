﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum EventType { message, follow, unfollow, join, leave, postback, beacon }

    public class LineWebhookModels
    {
        public List<Event> events { get; set; }
    }

    public enum SourceType { user, group, room }

    public class Source
    {
        public SourceType type { get; set; }
        public string userId { get; set; }
        public string groupId { get; set; }
        public string roomId { get; set; }
    }
    public class Event
    {
        public EventType type { get; set; }
        public string timestamp { get; set; }
        public Source source { get; set; }
        public string replyToken { get; set; }
        public ReceiveMessage message { get; set; }
    }

    public enum MessageType { text, image, video, audio, location, sticker }
    public abstract class Message<T>
    {
        public string id { get; set; }
        public T type { get; set; }
        public string text { get; set; }
        public string title { get; set; }
        public string address { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string packageId { get; set; }
        public string stickerId { get; set; }
    }
    public class ReceiveMessage : Message<MessageType> { }
    public class SendMessage : Message<string> { }
    public class Message
    {
        public string id { get; set; }
        public MessageType type { get; set; }
        public string text { get; set; }
        public string title { get; set; }
        public string address { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string packageId { get; set; }
        public string stickerId { get; set; }
    }

    public class ReplyBody
    {
        public string replyToken { get; set; }
        public List<SendMessage> messages { get; set; }
    }
}
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RealTimeWebApp.Api
{
    public class AdminController : Controller
    {
        static ConcurrentQueue<PingData> pings = new ConcurrentQueue<PingData>();
        public void Ping(int userID)
        {
            pings.Enqueue(new PingData { UserID = userID });
        }

        public void Message()
        {
            Response.ContentType = "text/event-stream";
            //do
            //{
            //} while (true);
            //PingData nextPing;
            //if (pings.TryDequeue(out nextPing))
            //{

            //    var bytes = Encoding.UTF8.GetBytes("data:" + JsonConvert.SerializeObject(nextPing, Formatting.None) + "\n\n");

            //    Response.Body.Write(bytes);
            //    Response.Body.
            //   Response.Body.Write("data:" + JsonConvert.SerializeObject(nextPing, Formatting.None) + "\n\n");
            //}

            // Response.Body.Flush();
           // Thread.Sleep(500);
            //Response..Flush(); 

                DateTime startDate = DateTime.Now;

            List<PingData> list = new List<PingData>();
            list.Add(new PingData { UserID  = DateTime.UtcNow.Second, Date = DateTime.UtcNow });
            list.Add(new PingData { UserID = DateTime.UtcNow.Second, Date = DateTime.UtcNow });


            /* while (startDate.AddSeconds(10) > DateTime.Now)
             {
             // var bytes = Encoding.UTF8.GetBytes(string.Format("data: {0}\n\n", DateTime.Now.ToString()));



                // System.Threading.Thread.Sleep(1000);
             }*/
           // Response.ContentType = "application/json";
            var bytes = Encoding.UTF8.GetBytes(string.Format("data: {0}\n\n", JsonConvert.SerializeObject(list)));
            Response.Body.Write(bytes);
           
            Response.Body.Close();

        }


        public void Message2()
        {
            //    Response.ContentType = "text/event-stream";

            //    DateTime startDate = DateTime.Now;
            //    while (startDate.AddMinutes(1) > DateTime.Now)
            //    {
            //        Response.Write(string.Format("data: {0}\n\n", DateTime.Now.ToString()));
            //        Response.Flush();

            //        System.Threading.Thread.Sleep(1000);
            //    }

            //    Response.Close();
            //}
        }

    }

    public class PingData
    {
        public int UserID { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }

    //[HttpGet]
    //public IActionResult Message()
    //{
    //    return new PushStreamResult(OnStreamAvailabe, "text/event-stream");
    //}

    //    [HttpGet]
    //    public HttpResponseMessage Message()
    //    {
    //        // TODO: authorize user (out of the post scope)
    //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
    //        response.Content = new PushStreamContent((Action<Stream, HttpContent, TransportContext>)OnStreamAvailabe,
    //        "text/event-stream");
    //        return response;
    //    }
    //    private void OnStreamAvailabe(Stream stream, HttpContent content, TransportContext context)
    //    {
    //        ManualResetEvent wait = new ManualResetEvent(false);
    //        using (var writer = new StreamWriter(stream))
    //        {
    //            writer.NewLine = "\n";
    //            WriteEvent(writer, "helo", "");
    //            Action<XLoggerEvent> handler = (XLoggerEvent ent) =>
    //            {
    //                try
    //                {
    //                    var jarray = new JArray();
    //                    jarray.Add(EventToJson(ent)); // get JSON 
    //                                                  // mark event as our custom event "log"
    //                    writer.WriteLine("event:log");
    //                    // each newline (\n) is a new msg which should start with "data:"
    //                    var text = jarray.ToString();
    //                    text = text.Replace(Environment.NewLine, "\ndata:");
    //                    writer.WriteLine("data:" + text);
    //                    writer.Flush();
    //                    writer.WriteLine();
    //                }
    //                catch (HttpException)
    //                {
    //                    // if client terminate connection then we'll know about it on Flush. 
    //                    // we'll get a HttpException: 'The remote host closed the connection. The error code is 0x800704CD.'
    //                    wait.Set();
    //                }
    //            };
    //            m_logStore.OnEvent += handler;
    //            bool waiting = true;
    //            // wait a Heartbeat timeout, after that send an empty msg to check connection
    //            while (waiting)
    //            {
    //                if (!wait.WaitOne(HeartbeatTimeout))
    //                {
    //                    try
    //                    {
    //                        WriteEvent(writer, "heartbeat", "");
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        wait.Set();
    //                        waiting = false;
    //                    }
    //                }
    //            }
    //            m_logStore.OnEvent -= handler;
    //        }
    //    }
    //    private static void WriteEvent(TextWriter writer, string eventType, string data)
    //    {
    //        if (!string.IsNullOrEmpty(eventType))
    //        {
    //            writer.WriteLine("event:" + eventType);
    //        }
    //        writer.WriteLine("data:" + data ?? "");
    //        writer.WriteLine();
    //        writer.Flush(); // StreamWriter.Flush calls Flush on underlying Stream
    //    }



    //}

    //public class PushStreamResult : IActionResult
    //{
    //    private readonly Action<Stream> _onStreamAvailabe;
    //    private readonly string _contentType;

    //    public PushStreamResult(Action<Stream> onStreamAvailabe, string contentType)
    //    {
    //        _onStreamAvailabe = onStreamAvailabe;
    //        _contentType = contentType;
    //    }

    //    public Task ExecuteResultAsync(ActionContext context)
    //    {
    //        var stream = context.HttpContext.Response.Body;
    //        context.HttpContext.Response.GetTypedHeaders().ContentType = new MediaTypeHeaderValue(_contentType);
    //        _onStreamAvailabe(stream);
    //        return Task.CompletedTask;
    //    }
    //}
}
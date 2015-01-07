using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CCTV.Controllers
{
    public class VideoController : BaseController
    {

        private static MJPEGStream videoMJPEGSource;

        //private static JPEGStream videoJPEGSource;

        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.IsRunning = videoMJPEGSource != null && videoMJPEGSource.IsRunning;
            return View();
        }

        public ActionResult Start(string deviceName)
        {
            videoMJPEGSource = new MJPEGStream();
            videoMJPEGSource.NewFrame += VideoSourceNewFrame;
            videoMJPEGSource.Start();
            return RedirectToAction("Index");
        }

        public ActionResult Stop()
        {
            if (videoMJPEGSource != null && videoMJPEGSource.IsRunning)
            {
                videoMJPEGSource.Stop();
                videoMJPEGSource = null;
            }

            return RedirectToAction("Index");
        }

        private static byte[] _bufImage = new byte[0];

        public ActionResult Video()
        {
            if (videoMJPEGSource == null || !videoMJPEGSource.IsRunning)
            {
                return null;
            }
            Response.Clear();
            //Устанавливает тип рередаваемых данных и разделитель кадров
            Response.ContentType = "multipart/x-mixed-replace; boundary=--myboundary";
            //Отключаем кеширование
            Response.Expires = 0;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            var ae = new ASCIIEncoding();
            //Передаем поток пока клиент не отключится
            while (Response.IsClientConnected)
            {
                try
                {
                    //_bufImage - переменная, в которой хранится новый кадр в формате jpeg
                    var buf = _bufImage;
                    //Формируем заголовок разделителя
                    var boundary = ae.GetBytes("\r\n--myboundary\r\nContent-Type: image/jpeg\r\nContent-Length:"
                                                + buf.Length + "\r\n\r\n");
                    Response.OutputStream.Write(boundary, 0, boundary.Length);
                    Response.OutputStream.Write(buf, 0, buf.Length);
                    Response.Flush();
                    Thread.Sleep(20);

                }
                catch (Exception)
                {

                }

            }
            Response.End();

            return null;
        }

        public void VideoSourceNewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            var img = (Image)eventArgs.Frame;

            // Сохраняем в памяти полученное изображение
            using (var ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Jpeg);
                _bufImage = ms.ToArray();
            }
        }

    }
}
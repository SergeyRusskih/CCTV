using AForge.Video;
using CCTV.Models;
using Domain.Context;
using Domain.Entities;
using Ninject;
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
    public class InvestController : BaseController
    {
        /// <summary>
        /// Контекст базы данных проекта
        /// </summary>
        private CCTVContext context = new CCTVContext();

        /// <summary>
        /// Экземпляр модели формирования параметров ip-камеры
        /// </summary>
        private IpCamOptionnsBuilder ipCamOptions = new IpCamOptionnsBuilder();

        /// <summary>
        /// Поток в формате MJPEG
        /// </summary>
        private static MJPEGStream videoMJPEGSource;

        /// <summary>
        /// Поток в формате JPEG
        /// </summary>
        private static JPEGStream videoJPEGSource;

        /// <summary>
        /// Буфер хранения изображения с ip-камер
        /// в виде массива байтов
        /// </summary>
        private static Dictionary<string, byte[]> _bufImage = new Dictionary<string, byte[]>();

        /// <summary>
        /// Отображение списка проектов
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<Project> projects = context.Projects.ToList();
            return View(projects);
        }

        /// <summary>
        /// Детальная информация о проекте
        /// </summary>
        /// <param name="id">id проекта</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            Project project = context.Projects.Find(id);

            // Формируем MJPEG и JPEG потоки
            foreach (var cam in project.IpCams)
            {
                // Формируем строку запроса
                cam.Address = ipCamOptions.AddresGenerate(cam.Address, cam.Param, cam.TypeCam);
                Boolean isMgpeg = ipCamOptions.IsMJPEG(cam.TypeCam);

                if (isMgpeg)
                {
                    videoMJPEGSource = new MJPEGStream(cam.Address);
                    videoMJPEGSource.NewFrame += VideoSourceNewFrame;
                    videoMJPEGSource.Start();
                }
                else
                {
                    videoJPEGSource = new JPEGStream(cam.Address);
                    videoJPEGSource.NewFrame += VideoSourceNewFrame;
                    videoJPEGSource.Start();
                }

                // Создаем новый буфер хранения данных
                if (!_bufImage.ContainsKey(cam.Address))
                {
                    _bufImage.Add(cam.Address, new byte[0]);
                }
            }

            return View(project);
        }

        /// <summary>
        /// Форма создания проекта
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Запрос на создание нового проекта
        /// </summary>
        /// <param name="project">Параметры запроса</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            try
            {
                context.Projects.Add(project);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View();
            }

            TempData["sucess"] = "Новый проект успешно создан";
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Форма редактирования проекта
        /// </summary>
        /// <param name="id">id проекта</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            Project project;
            try
            {
                project = context.Projects.Find(id);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View();
            }

            return View(project);
        }

        /// <summary>
        /// Запрос на редактирование проекта
        /// </summary>
        /// <param name="id">id проекта</param>
        /// <param name="project">Параметры запроса</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            try
            {
                var item = context.Projects.Find(id);
                context.Projects.Remove(item);

                context.Projects.Add(project);
                context.SaveChanges();

                TempData["sucess"] = "Данные успешно сохранены";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View();
            }
        }

        /// <summary>
        /// Страница удаления проекта
        /// </summary>
        /// <param name="id">id проекта</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            Project project = context.Projects.Find(id);
            return View(project);
        }

        /// <summary>
        /// Запрос на удаление проекта
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            try
            {
                var item = context.Projects.Find(id);
                context.Projects.Remove(item);
                context.SaveChanges();

                TempData["sucess"] = "Проект успешно удален";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Отправка MJPEG потока
        /// </summary>
        /// <param name="address">Ip-адрес камеры</param>
        /// <returns></returns>
        public ActionResult Video(string address)
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
                    var buf = _bufImage[address];
                    //Формируем заголовок разделителя
                    var boundary = ae.GetBytes("\r\n--myboundary\r\nContent-Type: image/jpeg\r\nContent-Length:"
                                                + buf.Length + "\r\n\r\n");
                    Response.OutputStream.Write(boundary, 0, boundary.Length);
                    Response.OutputStream.Write(buf, 0, buf.Length);
                    Response.Flush();
                    Thread.Sleep(10);

                }
                catch (Exception)
                {

                }

            }
            Response.End();

            return null;
        }
        
        /// <summary>
        /// Событие появления нового кадра
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="eventArgs">Параметры события</param>
        public void VideoSourceNewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            var img = (Image)eventArgs.Frame;

            var item = (AForge.Video.MJPEGStream)sender;
            // Сохраняем в памяти полученное изображение
            using (var ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Jpeg);
                _bufImage[item.Source] = ms.ToArray();
            }
        }
    }
}

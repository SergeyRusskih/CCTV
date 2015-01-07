using Domain.Context;
using Domain.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCTV.Controllers
{
    public class InvestController : BaseController
    {

        protected CCTVContext context = new CCTVContext();

        // GET: Invest
        public ActionResult Index()
        {
            List<Project> projects = context.Projects.ToList();
            return View(projects);
        }

        // GET: Invest/Details/5
        public ActionResult Details(int id)
        {
            Project project = context.Projects.Find(id);
            return View(project);
        }

        // GET: Invest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invest/Create
        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            try
            {
                // TODO: Add insert logic here
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

        // GET: Invest/Edit/5
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

        // POST: Invest/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            try
            {
                // TODO: Add update logic here
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

        // GET: Invest/Delete/5
        public ActionResult Delete(int id)
        {
            Project project = context.Projects.Find(id);
            return View(project);
        }

        // POST: Invest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            try
            {
                // TODO: Add delete logic here
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
    }
}

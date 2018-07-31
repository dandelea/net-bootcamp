using NETBootcamp.DataModel;
using NETBootcamp.MVC.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace NETBootcamp.MVC.Controllers
{
    public class TasksController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index(int projectId)
        {
            new ProjectClient();
            new TaskClient();

            var tasks = await TaskClient.GetTasksAsync(projectId);
            var project = await ProjectClient.GetProjectAsync(projectId);

            ViewBag.tasks = tasks;
            ViewBag.projectId = projectId;
            ViewBag.project = project;

            return View(tasks);

        }

        public async System.Threading.Tasks.Task<ActionResult> Details(int id)
        {
            new ProjectClient();
            new TaskClient();

            var task = await TaskClient.GetTaskAsync(id);
            var project = await ProjectClient.GetProjectAsync(task.ProjectID);

            ViewBag.project = project;

            return View(task);
        }

        public async System.Threading.Tasks.Task<ActionResult> Create(int projectId)
        {
            new ProjectClient();
            var project = await ProjectClient.GetProjectAsync(projectId);
            ViewBag.project = project;
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create(Task task)
        {
            if (ModelState.IsValid)
            {
                new TaskClient();
                try
                {
                    await TaskClient.CreateTaskAsync(task);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Error");
                }
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public async System.Threading.Tasks.Task<ActionResult> Edit(int id)
        {
            new ProjectClient();
            new TaskClient();

            var task = await TaskClient.GetTaskAsync(id);
            var project = await ProjectClient.GetProjectAsync(task.ProjectID);

            ViewBag.project = project;

            return View(task);
        }

        [System.Web.Mvc.HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Edit(Task task)
        {
            if (ModelState.IsValid)
            {
                new TaskClient();
                try
                {
                    await TaskClient.UpdateTaskAsync(task);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Error");
                }
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public async System.Threading.Tasks.Task<ActionResult> Delete(int id)
        {
            new ProjectClient();
            new TaskClient();

            var task = await TaskClient.GetTaskAsync(id);
            var project = await ProjectClient.GetProjectAsync(task.ID);

            ViewBag.project = project;

            return View(task);
        }

        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        public async System.Threading.Tasks.Task<ActionResult> DeleteConfirmed(int id)
        {
            new TaskClient();
            try
            {
                await TaskClient.DeleteTaskAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }
    }
}

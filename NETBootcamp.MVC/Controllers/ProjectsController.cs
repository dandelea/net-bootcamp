using NETBootcamp.DataModel;
using NETBootcamp.MVC.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace NETBootcamp.MVC.Controllers
{
    public class ProjectsController : Controller
    {

        public async Task<ActionResult> Index()
        {

            new ProjectClient();
            var projects = await ProjectClient.GetProjectsAsync();
            return View(projects);
            
        }

        public async Task<ActionResult> Details(int id)
        {
            new ProjectClient();
            var project = await ProjectClient.GetProjectAsync(id);
            return View(project);
        }

        public ActionResult Create()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Create(Project project)
        {
            if (ModelState.IsValid)
            {
                new ProjectClient();
                try
                {
                    await ProjectClient.CreateProjectAsync(project);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Error");
                }
            } else
            {
                return RedirectToAction("Error");
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            new ProjectClient();
            var project = await ProjectClient.GetProjectAsync(id);
            return View(project);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                new ProjectClient();
                try
                {
                    await ProjectClient.UpdateProjectAsync(project);
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

        public async Task<ActionResult> Delete(int id)
        {
            new ProjectClient();
            var project = await ProjectClient.GetProjectAsync(id);
            return View(project);
        }

        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            new ProjectClient();
            try
            {
                await ProjectClient.DeleteProjectAsync(id);
                return RedirectToAction("Index");
            } catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }



    }
}

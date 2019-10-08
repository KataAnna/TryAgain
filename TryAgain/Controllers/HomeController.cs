using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TryAgain.Models;
using TryAgain.BLL.Interfaces;
using TryAgain.BLL.DTO;
using TryAgain.BLL.Infrastructure;
using AutoMapper;
using System.ComponentModel.DataAnnotations;


namespace TryAgain.Controllers
{
    public class HomeController : System.Web.Mvc.Controller
    {
        IProjectService projectService;
       
        public HomeController(IProjectService serv)
        {
            projectService = serv;
        }
        public System.Web.Mvc.ActionResult Index()
        {
            IEnumerable<ProgammerDTO> workerDtos = projectService.GetWorker();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProgrammerDTO, ProgrammerViewModel>()).CreateMapper();
            var workers = mapper.Map<IEnumerable<ProgrammerDTO>, List<ProgrammerViewModel>>(workerDtos);
            return View(phones);
        }

        public System.Web.Mvc.ActionResult MakeOrder(int? id)
        {
            try
            {
                ProgrammerDTO worker = projectService.GetProgrammer(id);
                var project = new ProjectViewModel { ProgrammerId = worker.Id };

                return View(project);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [System.Web.Mvc.HttpPost]
        public System.Web.Mvc.ActionResult MakeOrder(ProjectViewModel order)
        {
            try
            {
                var projectDto = new ProjectDTO { ProgrammerId = order.ProgrammerId, Name = order.Name };
                projectService.MakeOrder(projectDto);
                return Content("<h2>Worker find sucsessfully</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }
        protected override void Dispose(bool disposing)
        {
            projectService.Dispose();
            base.Dispose(disposing);
        }

    }
}

using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using Portal.Models.Logic;
using System;
using System.Diagnostics;

namespace Portal.Controllers
{
    public class HangFireController : Controller
    {
        private readonly IBackgroundJobClient backgroundJob;
        private contextDatabase _context;
        private backgroundTasks _task;
        public HangFireController(contextDatabase context)
        {
            _context = context;
            _task = new backgroundTasks(context);
        }

        public HangFireController(IBackgroundJobClient backgroundJob)
        {
            this.backgroundJob = backgroundJob;
        }

        public IActionResult Index()
        {
            BackgroundJob.Schedule(() => _task.updateConnections(), TimeSpan.FromMilliseconds(5000));
            return RedirectToAction("Index", "Home");
        }
    }
}


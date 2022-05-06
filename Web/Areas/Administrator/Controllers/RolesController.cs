using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class RolesController : BaseController
    {
        // GET: RolesController
        private readonly ICommonService commonService;
        ILogger<RolesController> _logger;
        public RolesController(ILogger<RolesController> logger, ICommonService commonService)
        {
            _logger = logger;
            this.commonService = commonService;
        }
        public ActionResult Index()
        {
            IEnumerable<Roles> roles = commonService.GetListRoles();
            return View(roles);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Roles model)
        {
            try
            {
                var add = commonService.InsertOrUpdateRole(model);
                if (add)
                {
                    _logger.LogInformation("Create Role {0}", model.RoleName);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Update role {0} failed", model.RoleName);
                return View();
            }
        }
        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                var del = commonService.DeleteRole(id);
                if (del)
                {
                    _logger.LogInformation("Delete Role {0}", id);
                }
                return del;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Update role {0} failed", id);
                return false;
            }

        }
        public ActionResult Edit(int id)
        {
            return View(commonService.GetRoleById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Roles role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var update = commonService.InsertOrUpdateRole(role);
                    if (update)
                    {
                        _logger.LogInformation("Update Role {0}", role.RoleName);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(role);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Update role {0} failed", role.RoleName);
                    return View();
                }
            }
            return View();
        }
    }
}

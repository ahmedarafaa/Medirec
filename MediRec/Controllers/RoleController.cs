using MediRec.Models;
using MediRec.ViewModel;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MediRec.Controllers
{
    [Authorize(Roles = RoleName.DevGroup)]
    public class RoleController : Controller
    {
        private ApplicationRoleManager _roleManager;

        public RoleController()
        {
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManger = roleManager;
        }

        public ApplicationRoleManager RoleManger
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Role
        public ActionResult Index()
        {
            List<RoleViewModel> list = new List<RoleViewModel>();
            foreach (var role in RoleManger.Roles)
                list.Add(new RoleViewModel(role));
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            var role = new ApplicationRole()
            {
                Name = model.Name
            };
            await RoleManger.CreateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(string id)
        {
            var role = await RoleManger.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            var role = new ApplicationRole() { Id = model.Id, Name = model.Name };
            await RoleManger.UpdateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(string Id)
        {
            var role = await RoleManger.FindByIdAsync(Id);
            return View(new RoleViewModel(role));
        }

        public async Task<ActionResult> Delete(string Id)
        {
            var role = await RoleManger.FindByIdAsync(Id);
            return View(new RoleViewModel(role));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(string Id)
        {
            var role = await RoleManger.FindByIdAsync(Id);
            await RoleManger.DeleteAsync(role);
            return RedirectToAction("Index");
        }

    }
}
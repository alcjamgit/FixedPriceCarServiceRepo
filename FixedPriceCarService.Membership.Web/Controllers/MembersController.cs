using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FixedPriceCarService.Membership.Core.Entities;
using FixedPriceCarService.Membership.Infrastructure.DomainServices;
using FixedPriceCarService.Membership.Web.Models;

namespace FixedPriceCarService.Membership.Web.Controllers
{
    public class MembersController : Controller
    {
        public ActionResult Index()
        {
            var members = from m in MemberContainer.MemberList
                          select new DisplayMembersVM
                          {
                              Id = m.Id,
                              Email = m.Email,
                              FirstName = m.FirstName,
                              LastName = m.LastName,
                              Phone = m.Phone,
                              WebSite = m.WebSite
                          };
            return View(members.ToList());
        }


        public ActionResult Details(int id)
        {
            Member member = (from m in MemberContainer.MemberList
                             where m.Id == id
                             select m).FirstOrDefault();
            
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddMemberVM memberVm)
        {
            if (ModelState.IsValid)
            {
                var member = new Member { 
                    Id = MemberContainer.GenerateMemberId(),
                    CreatedDate = DateTime.Now,
                    Email = memberVm.Email,
                    FirstName = memberVm.FirstName,
                    LastName = memberVm.LastName,
                    Phone = memberVm.Phone,
                    WebSite = memberVm.WebSite
                };
                MemberContainer.MemberList.Add(member);
                return RedirectToAction("Index");
            }

            return View(memberVm);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var member = (from m in MemberContainer.MemberList
                         where m.Id == id
                         select new EditMemberVM 
                         { 
                             Email = m.Email,
                             FirstName = m.FirstName,
                             LastName = m.LastName,
                             Phone = m.Phone,
                             WebSite = m.WebSite,
                             IsAdministrator = m.IsAdministrator,
                         }).FirstOrDefault();

            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //Assumed we don't want email and IsAdmin to be editable
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditMemberVM memberVm)
        {
            if (ModelState.IsValid)
            {
                var member = MemberContainer.MemberList.Where(m => m.Id == memberVm.Id).FirstOrDefault();
                member.FirstName = memberVm.FirstName;
                member.LastName = memberVm.LastName;
                member.Phone = memberVm.Phone;
                member.WebSite = memberVm.WebSite;
                return RedirectToAction("Index");
            }
            return View(memberVm);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var member = MemberContainer.MemberList.Where(m => m.Id == id).FirstOrDefault();
            var member = (from m in MemberContainer.MemberList
                         where m.Id == id
                         select new DeleteMemberVM 
                         {
                             Id = m.Id,
                             Email = m.Email,
                             FirstName = m.FirstName,
                             LastName = m.LastName,
                             Phone = m.Phone,
                             WebSite = m.WebSite,
                             IsAdministrator = m.IsAdministrator,
                             CreatedDate = m.CreatedDate
                         }).FirstOrDefault();
            if (member == null)
            {
                return HttpNotFound();
            }

            return View(member);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var member = MemberContainer.MemberList.Where(m => m.Id == id).FirstOrDefault();
            MemberContainer.MemberList.Remove(member);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

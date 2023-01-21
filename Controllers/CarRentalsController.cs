using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarzRentals;

namespace CarzRentals.Controllers
{
    public class CarRentalsController : Controller
    {
        private DBCarzRentalEntities db = new DBCarzRentalEntities();

        // GET: CarRentals
        public ActionResult Index()
        {
            var carRentals = db.CarRentals.Include(c => c.Car).Include(c => c.Customer).Include(c => c.Employee);
            return View(carRentals.ToList());
        }

        // GET: CarRentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRental carRental = db.CarRentals.Find(id);
            if (carRental == null)
            {
                return HttpNotFound();
            }
            return View(carRental);
        }

        // GET: CarRentals/Create
        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Title");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName");
            ViewBag.EmplyeeId = new SelectList(db.Employees, "EmployeeId", "FullName");
            return View();
        }

        // POST: CarRentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarRentalId,CarId,EmplyeeId,CustomerId,StartDate,EndDate,DailyRate,Odometer,TotalTrip,TotalDays,TotalCost,Notes,IsActive,Dated")] CarRental carRental)
        {
            if (ModelState.IsValid)
            {
                db.CarRentals.Add(carRental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Title", carRental.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName", carRental.CustomerId);
            ViewBag.EmplyeeId = new SelectList(db.Employees, "EmployeeId", "FullName", carRental.EmplyeeId);
            return View(carRental);
        }

        // GET: CarRentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRental carRental = db.CarRentals.Find(id);
            if (carRental == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Title", carRental.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName", carRental.CustomerId);
            ViewBag.EmplyeeId = new SelectList(db.Employees, "EmployeeId", "FullName", carRental.EmplyeeId);
            return View(carRental);
        }

        // POST: CarRentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarRentalId,CarId,EmplyeeId,CustomerId,StartDate,EndDate,DailyRate,Odometer,TotalTrip,TotalDays,TotalCost,Notes,IsActive,Dated")] CarRental carRental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carRental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Title", carRental.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName", carRental.CustomerId);
            ViewBag.EmplyeeId = new SelectList(db.Employees, "EmployeeId", "FullName", carRental.EmplyeeId);
            return View(carRental);
        }

        // GET: CarRentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRental carRental = db.CarRentals.Find(id);
            if (carRental == null)
            {
                return HttpNotFound();
            }
            return View(carRental);
        }

        // POST: CarRentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarRental carRental = db.CarRentals.Find(id);
            db.CarRentals.Remove(carRental);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

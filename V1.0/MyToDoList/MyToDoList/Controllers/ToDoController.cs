using Microsoft.AspNetCore.Mvc;
using MyToDoList.Data;
using MyToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ToDoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ToDo> todoList = _db.ToDo;
            return View(todoList);
        }

        public IActionResult Create()  //get-create
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ToDo obj) //post-create
        {
            if (ModelState.IsValid)
            {
                _db.ToDo.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id) //get-edit
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ToDo.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ToDo obj) // post-edit
        {
            if (ModelState.IsValid)
            {
                _db.ToDo.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        public IActionResult Delete(int? id) //get-delete 
        {
            if(id ==null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ToDo.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

       [HttpPost]
       [ValidateAntiForgeryToken]

       public IActionResult DeletePost(int? id) //post-delete
        {
            var obj = _db.ToDo.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.ToDo.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

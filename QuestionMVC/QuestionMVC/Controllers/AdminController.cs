using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestionMVC.Models;

namespace QuestionMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Question qs)
        {
            try
            {
                using (DBQuestionEntities db = new DBQuestionEntities())
                {
                   
                    db.Questions.Add(qs);
                    
                    db.SaveChanges();

                    
                }
                return RedirectToAction("QuestionList");
            }
            catch
            {
                return View();
            }
        }




        // GET: Admin/Createoption
        public ActionResult Createoption(int id)
        {

            Option mdl = new Option();
            mdl.QID = id;


            return View(mdl);
        }

        // POST: Admin/Createoption
        [HttpPost]
        public ActionResult Createoption(Option op)
        {
            try
            {
                using (DBQuestionEntities db = new DBQuestionEntities())
                {
                    db.Options.Add(op);
                    db.SaveChanges();


                }
                return RedirectToAction("OptionList", new {id=op.QID });
            }
            catch
            {
                return View();
            }
        }



        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult QuestionList()
        {
            using (DBQuestionEntities db = new DBQuestionEntities())
            {

                List<Question> Question = db.Questions.ToList();


                return View(Question);
            }

        }
        public ActionResult List()
        {
            using (DBQuestionEntities db = new DBQuestionEntities())
            {
               
                List<Question> Question = db.Questions.ToList();
                List<Answer> Answers = db.Answers.ToList();

                var tablejn = from an in Answers
                              join qn in Question on an.QID equals qn.QID into table1
                              from qn in table1.DefaultIfEmpty()
                            select new multipleclass
                            {
                                Question=qn,
                                Answer=an
                            };
                              
                return View(tablejn);
            }
                
        }

        public ActionResult OptionList(int id)
        {
            using (DBQuestionEntities db = new DBQuestionEntities())
            {
                ViewBag.QuestionDescription = db.Questions.Where(x => x.QID == id).FirstOrDefault().QuestionD;
                ViewBag.QuestionID = id;

                List<Option> Options = db.Options.Where(x=> x.QID == id).ToList();
                return View(Options);
            }

        }

    }
}

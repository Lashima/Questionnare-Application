using QuestionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionMVC.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index(int id)
        {
            using (DBQuestionEntities db = new DBQuestionEntities())
            {
                Viewmodelquestion viewmodel = new Viewmodelquestion();
                var newmodel= db.Questions.Where(x => x.QID == id).FirstOrDefault();
                viewmodel.QuestionId = id;
                viewmodel.QDescription = newmodel.QuestionD;
                viewmodel.Qstnype = newmodel.QType;
                viewmodel.option = new List<Option>();
                List<Option> Options = db.Options.Where(x => x.QID == id).ToList();
                viewmodel.option = Options;

                return View(viewmodel);
            }



           
        }
        [HttpPost]
        public ActionResult submitanswer(Answermodel answer)
        {
            using (DBQuestionEntities db = new DBQuestionEntities())
            {

                for(int i=0; i<answer.AnswerlIst.Count; i++)
                {
                    var answeres = new Answer();
                    answeres.QID = answer.QID;
                    answeres.AnswerD = answer.AnswerlIst[i];
                    db.Answers.Add(answeres);
                    db.SaveChanges();
                }
                


            }

            return Json("success");
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Question/Edit/5
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

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Question/Delete/5
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
    }
}

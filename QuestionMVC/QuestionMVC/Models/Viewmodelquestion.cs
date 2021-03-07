using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionMVC.Models
{
    public class Viewmodelquestion
    {
       
        public List<Option> option { get; set; }
        public String textvalue { get; set; }
        public string selecteditem { get; set; }
        public string selectedoption { get; set; }

        public string Qstnype { get; set; }

        public int QuestionId { get; set; }

        public string QDescription { get; set; }




    }
}
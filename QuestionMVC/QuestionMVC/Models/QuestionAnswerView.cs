using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionMVC.Models
{
    public class QuestionAnswerView
    {
        public int QID { get; set; }
        public string QuestionD { get; set; }
        public string QType { get; set; }
    }
    public class OptionView
    {
        public int OPID { get; set; }
        public string Options { get; set; }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Models
{
    public class SimpleQuizOptionModel 
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string Text { get; set; }
        public bool IsAnswer { get; set; }
    }
}

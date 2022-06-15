﻿using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    internal class EditActionController : ActionController
{
        public EditActionController(List<YearSet> yearSet) : base(yearSet) { }

        public override void RunModule()
        {
            EditActionView.ShowMenu();
        }
    }
}

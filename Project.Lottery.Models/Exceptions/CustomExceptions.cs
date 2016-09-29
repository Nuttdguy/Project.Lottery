using System;
using System.Collections.Generic;
using Project.Lottery.Models.Validation;

namespace Project.Lottery.Models.Exceptions
{
    public class BLLException : Exception
    {

        //== BROKEN RULES PROPERTY
        public BrokenRuleCollection BrokenRules { get; set; }

        //== SET THE MESSAGE OF BLL-EXCEPTION
        public BLLException(string message) : base(message) { }

        //== SET THE MESSAGE AND SETS THE BROKENRULES PROPERTY
        public BLLException(string message, BrokenRuleCollection brokenRules) : base(message)
        {
            BrokenRules = brokenRules;
        }

        public BLLException(string message, Exception inner) : base(message, inner) { }

        public BLLException(string message, Exception inner, BrokenRuleCollection brokenRules) : base(message, inner)
        {
            BrokenRules = brokenRules;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models.Validation
{
    public class BrokenRule
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }

        public BrokenRule(string propertyName, string message)
        {
            this.PropertyName = propertyName;
            this.Message = message;
        }

    }
}

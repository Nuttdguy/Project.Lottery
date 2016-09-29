using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Project.Lottery.Models.Collections
{
    public abstract class BaseCollection<T> : Collection<T>, IList<T>
    {

        protected BaseCollection() : base(new List<T>()) { }

    }
}

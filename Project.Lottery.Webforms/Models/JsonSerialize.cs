using System;
using Project.Lottery.Models;
using System.Collections.Generic;
using System.Web.Script.Serialization;


namespace Project.Lottery.Webforms.Models
{
    public class JsonSerialize
    {
        #region SECTION 2 ||======= JSON SERIALIZATION  =======||

        public T SerializeItem<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            T item = serializer.Deserialize<T>(json);

            return item;
        }

        public List<T> SerializeCollection<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<T> collection = serializer.Deserialize<List<T>>(json);

            return collection;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndInfoglobo.Model
{
    public class Item
    {
        public string title { get; set; }
        public string link { get; set; }
        public List<Tag> description { get; set; }

        public override string ToString()
        {
            var item = string.Format("{{ 'title': '{0}', 'link': '{1}', 'description' : [ ", title, link);

            for (var i = 0; i < description.Count; i++)
            {
                item = string.Format("{0} {1}", item, description[i].ToString());

                if (i != description.Count - 1)
                    item = string.Format("{0},", item);
            }

            item = string.Format("{0} ] }}", item);

            return item;
        }
    }
}

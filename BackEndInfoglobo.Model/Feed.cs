using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndInfoglobo.Model
{
    public class Feed
    {
        public List<Item> items { get; set; }

        public override string ToString()
        {
            var feed = "{ 'feed': [";

            for (var i = 0; i < items.Count; i++)
            {
                feed = string.Format("{0} {1}", feed, items[i].ToString());

                if (i != items.Count - 1)
                    feed = string.Format("{0},", feed);
            }

            feed = string.Format("{0} ] }}", feed);

            return feed;
        }
    }
}

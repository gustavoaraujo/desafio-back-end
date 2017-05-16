using System.Collections.Generic;

namespace BackEndInfoglobo.Model
{
    public class Tag
    {
        public string type { get; set; }
        public List<string> content { get; set; }

        public Tag()
        {
            content = new List<string>();
        }

        public override string ToString()
        {
            var tag = string.Format("{{ 'type': '{0}', 'content':", type);

            if (content.Count > 1)
            {
                tag = string.Format("{0} [", tag);
                for (var i = 0; i < content.Count; i++)
                {
                    tag = string.Format("{0} '{1}'", tag, content[i]);

                    if (i != content.Count - 1)
                        tag = string.Format("{0}, ", tag);
                }

                tag = string.Format("{0} ] }}", tag);
            }
            else
                tag = string.Format("{0} '{1}' }}", tag, content[0]);

            return tag;
        }
    }
}
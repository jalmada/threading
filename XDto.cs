using System.Collections.Concurrent;
using System.Collections.Generic;

namespace threading
{
    public class XDto
    {
        public string ElementType { get; set; }
        public string TagName { get; set; }
        public string Value { get; set; }

        public List<XDto> Children { get; set; }

        public XDto()
        {
            Children = new List<XDto>();
        }
    }
}
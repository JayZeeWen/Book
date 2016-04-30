using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Model
{
    public class BaseParameter
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderKey { get; set; }

        public int PageBeginIndex
        {
            get
            {
                return (PageIndex - 1) * PageSize + 1 ;
            }
        }

        public int PageEndIndex
        {
            get
            {
                return PageIndex * PageSize;
            }
        }

        public Dictionary<string,string> KeyValues { get; set; }
        

    }
}

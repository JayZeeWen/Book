using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.Member
{
    public partial class PageBar : System.Web.UI.UserControl
    {
        #region Prop
        private int currentPageIndex;

        public int CurrentPageIndex
        {
            get
            {
                return currentPageIndex;
            }
            set
            {
                currentPageIndex = value;
            }
        }


        private int currentPageCount;
        public int CurrentPageCount
        {
            get
            {
                return currentPageCount;
            }
            set
            {
                currentPageCount = value;
            }
        }
        public string html = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(currentPageCount == 1 )
            {
                return;
            }
            int strat = currentPageIndex - 5;
            if(strat < 1 )
            {
                strat = 1;
            }
            int end = strat + 9;
            if(end > currentPageCount)
            {
                end = currentPageCount;
                strat = end - 9 > 0 ? end - 9 : 1;
            }
            StringBuilder sb = new StringBuilder();
            for(int i = strat;i < end;i++)
            {
                if (i == currentPageIndex)
                {
                    sb.Append(i);
                }
                else
                {
                    sb.Append(string.Format("<a href='BookList_{0}.aspx'>{0}</a>", i));
                }
            }
            html = sb.ToString();
        }
    }
}
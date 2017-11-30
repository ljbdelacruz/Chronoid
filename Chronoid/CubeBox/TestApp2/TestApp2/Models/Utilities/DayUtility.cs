using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class DayUtility
    {

        #region Function
        public static bool IsSelected(int day, List<DayVM> list) {
            return list.Where(l => l.id == day).FirstOrDefault().isSelected;
        }

        #endregion


    }
}
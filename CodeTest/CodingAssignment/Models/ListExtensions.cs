using System.Collections.Generic;
using System.Web.Mvc;

namespace CodingAssignment.Models {
    public static class ListExtensions {
        public static List<SelectListItem> ToSelectItemList<T>(this ICollection<T> values) {
            List<SelectListItem> tempList = new List<SelectListItem>();
            if (values != null) {
                tempList = new List<SelectListItem>();
                foreach (var v in values) {
                    tempList.Add(new SelectListItem { Text = v.GetType().GetProperty("Name").GetValue(v).ToString(), Value = v.GetType().GetProperty("Id").GetValue(v).ToString() });
                }
                tempList.TrimExcess();
            }
            return tempList;
        }
        /// <summary>
        /// This extension method converts <list type="T"></list> to a <list type="List<SelectListItem>"></list>
        /// based on provided keys for accesing the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="idProp"></param>
        /// <param name="textProp"></param>
        /// <returns></returns>
        public static List<SelectListItem> ToSelectItemList<T>(this ICollection<T> values, string idProp, string textProp) {
            List<SelectListItem> tempList = new List<SelectListItem>();
            if (values != null) {
                tempList = new List<SelectListItem>();
                foreach (var v in values) {
                    tempList.Add(new SelectListItem { Text = v.GetType().GetProperty(textProp).GetValue(v).ToString(), Value = v.GetType().GetProperty(idProp).GetValue(v).ToString() });
                }
                tempList.TrimExcess();
            }
            return tempList;
        }
    }
}
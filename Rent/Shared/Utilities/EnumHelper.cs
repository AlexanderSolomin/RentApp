using System;
using System.Collections.Generic;
using System.Linq;
using Rent.Shared.Models;

namespace Rent.Shared.Utilities
{
    public class EnumHelper
    {
        public static List<DropDownListItem> EnumToDropDown<T>()
        {
            List<DropDownListItem> result = new();
            var values = Enum.GetValues(typeof(T)).Cast<T>().ToList();

            for (int i = 0; i < Enum.GetNames(typeof(T)).Length; i++)
            {
                DropDownListItem item = new DropDownListItem();
                item.Text = Enum.GetNames(typeof(T))[i];
                item.Value = values[i].ToString();
                result.Add(item);
            }

            return result;
        }
    }
}

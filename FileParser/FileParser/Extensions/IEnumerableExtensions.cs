using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Extensions
{
	public static class IEnumerableExtensions
	{
		public static DataTable ToDataTable<T>(this IEnumerable<T> list)
		{
			Type type = typeof(T);
			var properties = type.GetProperties();

			DataTable dataTable = new DataTable();
			foreach (PropertyInfo info in properties)
			{
				dataTable.Columns.Add(new DataColumn(info.Name));
			}

			foreach (T entity in list)
			{
				object[] values = new object[properties.Length];
				for (int i = 0; i < properties.Length; i++)
				{
					values[i] = properties[i].GetValue(entity).ToString();
				}

				dataTable.Rows.Add(values);
			}

			return dataTable;
		}
	}
}

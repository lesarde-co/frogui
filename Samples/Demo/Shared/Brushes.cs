using Lesarde;
using Lesarde.Frogui;
using Lesarde.Frogui.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
	/***************************************************************************************************
		Brushes class
	***************************************************************************************************/

	public abstract class Brushes : DependencyObject
	{
		/***********************************************************
			All property
		***********************************************************/

		public abstract IList<BrushInfo> All { get; }

		public abstract BrushVariety Variety { get; }

		/*******************************************************************************
			Init()
		*******************************************************************************/

		protected static void Init(Type t, IList<BrushInfo> all)
		{
			var propInfos = t.GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).Where(o => o.PropertyType == typeof(BrushInfo));

			var i = 0;
			foreach (var cur in propInfos)
				all[i++].Name = cur.Name;
		}

		/*******************************************************************************
			Add()
		*******************************************************************************/

		protected static BrushInfo Add(Brush brush, IList<BrushInfo> all)
		{
			var info = new BrushInfo { Brush = brush };

			all.Add(info);

			return info;
		}

		/*******************************************************************************
			IndexOf()
		*******************************************************************************/

		public int IndexOf(Brush brush)
		{
			for (var i = 0; i < All.Count; ++i)
				if (All[i].Brush == brush)
					return i;

			return -1;
		}

		/*******************************************************************************
			Find()
		*******************************************************************************/

		public BrushInfo Find(Brush brush) => All.FirstOrDefault(o => o.Brush == brush);

	}
}

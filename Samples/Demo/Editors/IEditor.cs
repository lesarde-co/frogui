using Lesarde.Frogui;

namespace Demo
{
	/***************************************************************************************************
		
	public interface IEditor class
	***************************************************************************************************/
	/// <summary>
	/// Interface for a property editor. A property editor is a control designed to a <see cref="DependencyProperty"/>
	/// of an <see cref="Element"/>.
	/// </summary>
	public interface IEditor
	{
		void BindIt(Element targetObject, DependencyProperty targetProperty);
	}
}

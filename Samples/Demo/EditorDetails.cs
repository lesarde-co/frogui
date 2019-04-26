//using Lesarde.Frogui;
//using Lesarde.Frogui.Controls;
//using System;

//namespace Demo
//{
//	/***************************************************************************************************
//		EditorMeta class
//	***************************************************************************************************/
//	/// <summary>
//	/// Provides details required to edit a specific <see cref="DependencyProperty"/> of an <see cref="Element"/>.
//	/// <para>
//	/// The demo displays a form <see cref="MainWindow.e_properties"/> which is used by many examples to edit
//	/// an element's properties. The form members are generated via this class.
//	/// editor
//	/// </para>
//	/// </summary>
//	public class EditorMeta
//	{
//		/***********************************************************
//			EditorType property
//		***********************************************************/
//		/// <summary>
//		/// The <see cref="Type"/> of the editor to use to modify the associated property.
//		/// </summary>
//		Type EditorType { get; set; }

//		/***********************************************************
//			Editor property
//		***********************************************************/
//		/// <summary>
//		/// The <see cref="IEditor"/> instance as specified by <see cref="EditorType"/>.
//		/// </summary>
//		public IEditor Editor { get; private set; }

//		/***********************************************************
//			Label property
//		***********************************************************/
//		/// <summary>
//		/// The text displayed for the editor.
//		/// </summary>
//		string Label { get; set; }

//		/***********************************************************
//			TargetProperty property
//		***********************************************************/
//		/// <summary>
//		/// The target <see cref="DependencyProperty"/> to edit.
//		/// </summary>
//		DependencyProperty TargetProperty { get; set; }

//		/*******************************************************************************
//			$
//		*******************************************************************************/
//		/// <summary>
//		/// Constructs a new <see cref="EditorMeta"/>.
//		/// </summary>
//		/// <param name="editorType">See <see cref="EditorType"/>.</param>
//		/// <param name="label">See <see cref="Label"/>.</param>
//		/// <param name="targetProperty">See <see cref="TargetProperty"/>.</param>
//		public EditorMeta(Type editorType, string label, DependencyProperty targetProperty)
//		{
//			this.EditorType = editorType;
//			this.Label = label;
//			this.TargetProperty = targetProperty;
//		}

//		/*******************************************************************************
//			Activate()
//		*******************************************************************************/
//		/// <summary>
//		/// Adds this property editor to the specified <see cref="Form"/> to edit the
//		/// the <see cref="TargetProperty"/> of the specified target <see cref="Element"/>.
//		/// </summary>
//		/// <param name="form">The target <see cref="Form"/>.</param>
//		/// <param name="targetElement">The target object to edit.</param>
//		public virtual void Activate(Form form, Element targetElement)
//		{
//			Editor = (IEditor)Activator.CreateInstance(EditorType);
//			Editor.BindIt(targetElement, TargetProperty);
//			form.Members.Add((Element)Editor, new Placecard(Label));
//		}

//		/*******************************************************************************
//			Deactivate()
//		*******************************************************************************/
//		/// <summary>
//		/// Removes this editor from the specified <see cref="Form"/>.
//		/// </summary>
//		/// <param name="form"></param>
//		public void Deactivate(Form form)
//		{
//			form.Members.Remove((Element)Editor);
//			Editor = null;
//		}
//	}
//}

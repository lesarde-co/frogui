using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media.Effects;

namespace Demo
{
	/***************************************************************************************************
		EffectEditor class
	***************************************************************************************************/

	public class EffectEditor<EDITOR> : CheckedEditorPart<EDITOR> where EDITOR : Element, IPropertyEditor, new()
	{
		/***********************************************************
			properties
		***********************************************************/

		public GraphicsEffectEditor ParentEditor { get; set; }
		public GraphicsEffect Effect { get; set; }
		public DependencyProperty Dproperty { get; set; }

		/*******************************************************************************
			$
		*******************************************************************************/

		public EffectEditor(GraphicsEffectEditor parentEditor, string label, GraphicsEffect effect, DependencyProperty dproperty)
		{
			this.ParentEditor = parentEditor;
			this.Effect = effect;
			this.Dproperty = dproperty;

			parentEditor.Members.Add(this, new Placecard(label));

			//E_editor.SetBinding(Slider.UserValue1Property, new Binding(dproperty, effect) { Mode = BindingMode.TwoWay });
			E_editor.BindToSourceProperty(effect, dproperty);

			E_checkBox.AddPropertyChangedListener(CheckBox.IsCheckedProperty, ValueChanged_IsChecked);
		}

		/*******************************************************************************
			ValueChanged_IsChecked()
		*******************************************************************************/

		internal void ValueChanged_IsChecked(bool v)
		{
			if (v)
				ParentEditor.CombinedEffect.Effects.Add(Effect);
			else
				ParentEditor.CombinedEffect.Effects.Remove(Effect);
		}
	}
}

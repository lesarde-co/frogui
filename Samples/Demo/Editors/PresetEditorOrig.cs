using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo
{
	public class PresetEditorOrig : IntEditor
	{
		Style[] presets;
		IExampleView exampleView;

		public PresetEditorOrig()
		{
			
		}

		public void Init(Style[] presets, IExampleView exampleView)
		{
			var totalPresets = presets.Length;
			this.presets = presets;
			this.exampleView = exampleView;
			this.Maximum = totalPresets;

			//this.Width = (totalPresets > 5) ? Length.Auto : Length.InPixels(30 + 30 * totalPresets);

			Value = 0;

			Sync();
		}

		public override void IntChanged(int value)
		{
			if (null != exampleView)
				Sync();
		}

		void Sync()
		{
			var index = (int)UserValue1;

			//exampleView.MainElement.Style = (0 == index) ? null : presets[index - 1];
			if (index > 0)
				exampleView.MainElement.Style = presets[index - 1];
		}
	}
}

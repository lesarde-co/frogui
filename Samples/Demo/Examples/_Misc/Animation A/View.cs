using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Input;
using Lesarde.Frogui.Media;
using Lesarde.Frogui.Media.Animation;
using Lesarde.Frogui.Shapes;
using System;

namespace Demo.Example_Animation_A
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Paper"/> class.
	/// </summary>
	public partial class View : Paper, IExampleView
    {
		Random random = new Random();

		Element IExampleView.MainElement => this;

		public View()
		{
			InitializeComponent();

			var size = new Lesarde.Frogui.Length(60, Lesarde.Frogui.Unit.Px);

			for (var i = 0; i < 50; ++i)
			{
				var e_ellipse = new Ellipse()
				{
					Width = size,
					Height = size,
					StrokeThickness = new Lesarde.Frogui.Length(i % 3, Lesarde.Frogui.Unit.Px),
					Stroke = Common.BrushesMix[(i + 1) % Common.BrushesMix.Length],
					Opacity = GetRandomDouble(0.4, 1.0),
					Fill = Common.BrushesMix[i % Common.BrushesMix.Length]
				};
				e_ellipse.Animation = new TransitionAnimation() { Duration = ((double)i + 1.0) / 10.0 , TimingFunction = GetFunc(i) };
				this.Children.Add(e_ellipse);
			}

			AnimationFunctionBase GetFunc(int i)
			{
				switch (i % 7)
				{
					case 0: return Linear.Singleton;
					case 1: return Ease.InSingleton;
					case 2: return Ease.OutSingleton;
					case 3: return Ease.InOutSingleton;
					case 4: return QuadraticEase.InSingleton;
					case 5: return QuadraticEase.OutSingleton;
					case 6: return QuadraticEase.InOutSingleton;
				}

				return null;
			}

		}

		void MyPointerDown(object sender, PointerEventArgs e)
		{
			var zero = new Lesarde.Frogui.Length(0, Lesarde.Frogui.Unit.Px);

			var scale = GetRandomDouble(1, 300) / 100.0;
			var scaleTransform = new ScaleTransform(scale, scale);

			foreach (Ellipse cur in this.Children)
			{
				if (GetRandomInt(0, 4) != 0)
				{
					cur.TranslateX = Length.InPixels(e.Position.X);
					cur.TranslateY = Length.InPixels(e.Position.Y);
					cur.RenderTransform = scaleTransform;
				}
			}
		}

		public double GetRandomDouble(double min, double max) => random.NextDouble() * (max - min) + min;
		public int GetRandomInt(int min, int max) => random.Next() % (max - min + 1) + min;

	}
}

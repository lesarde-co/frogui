using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Shapes;

namespace Demo.Example_Home
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// The home screen.
	/// </summary>
	public partial class View : Border, IExampleView
	{
		Element IExampleView.MainElement => e_htmlBlock;

		/*******************************************************************************
			$
		*******************************************************************************/

		public View()
		{
			InitializeComponent();

			e_htmlBlock.Text =
"<div style='overflow-y:scroll;max-height:80vh;'>" +
"<p>Welcome to the<strong> Frog<span style='color: #99cc00;'>ui</span></strong> <strong>demo</strong> app!&nbsp;</p>" +
"<p><strong> Frog<span style='color: #99cc00;'>ui</span></strong> is a C# UI framework designed to bring advanced UI capabilities to the web using the revolutionary <a href='https://webassembly.org/'>WebAssembly</a>. To learn more, check out <a href='https://www.lesarde.com'>lesarde.com</a>.</p>" +
"<p>In this release of <strong>Frog<span style='color: #99cc00;'>ui</span></strong>, one goal was to push the limits of browsers to prove that <em>every rendered pixel</em> can be completely controlled by the framework, including scrollbars, popup windows and every other element. Mission accomplished, though at the cost of&nbsp;performance which you'll soon see.</p>" +
"<p>Fortunately, the architecture makes it easy for us to significantly improve performance in future releases. For instance, in this release you have no control over whether a browser-rendered scrollbar is used -- it's always custom rendering.</p>" +
"<h2><span style='color: #999999;'>Build Overview</span></h2>" +
"<p>Using Microsoft tools such as Visual Studio, a <strong>Frog<span style='color: #99cc00;'>ui</span></strong>&nbsp;project may be created. Building results in a&nbsp;<strong>WebAssembly</strong> and <strong>Windows</strong> application:</p>" +
"<ul>" +
"<li><strong>WebAssembly</strong><br />Browser-based client application running on <a href='https://www.mono-project.com/'>Mono</a> for WebAsssembly completely in the browser. At the moment, it is interpreted IL which means <em>very slow</em> performance. Mono for WebAssembly is actively being developed by the community, is sponsored by Microsoft, is at the experimental stage, and <em>will run significantly faster than JavaScript</em> once the <em>Ahead-of-Time</em> compiler is working.</li>" +
"<li><strong>Windows</strong><br />Browser-based client application compiled to run on .NET Standard. Brings rich WPF/UWP-like development to browser running locally on the desktop. Because Mono for WebAssembly has a ways to go until it has full debugging support, the Windows app is ideal for day-to-day development, complete with debugging, profiling and everything else Visual Studio offers.</li>" +
"</ul>" +
"<p>If you want to see how the current <strong>Frog<span style='color: #99cc00;'>ui</span></strong> will perform once the WebAssembly compiler is ready, <a href='https://github.com/lesarde-co/frogui'>download</a> the demo and run in Visual Studio.</p>" +
"<h2><span style='color: #999999;'>Using the Demo</span></h2>" +
"<p>The demo layout is as follows:</p>" +
"<table style='background-color: light-gray; border-color: gray;' border='2' cellpadding='8'>" +
"<tbody>" +
"<tr>" +
"<td>Build Info</td>" +
"<td>&nbsp;</td>" +
"<td>Presets</td>" +
"</tr>" +
"<tr>" +
"<td>example 1</td>" +
"<td>Demo Area</td>" +
"<td>Properties</td>" +
"</tr>" +
"<tr>" +
"<td>example n</td>" +
"<td>Show Properties</td>" +
"<td>Brush Editor</td>" +
"</tr>" +
"</tbody>" +
"</table>" +
"<ul>" +
"<li><strong>Build Info<br /></strong>Shows this demo's build type: WebAssembly or Windows. And the current framework version.</li>" +
"<li><strong>Examples</strong><br />The examples available in the demo.</li>" +
"<li><strong>Demo Area</strong><br />Where the examples are presented.</li>" +
"<li><strong>Presets</strong><br />Each example has zero or more presets. Presets are not a part of Frogui; they are not to be confused with styling. However, they do use styling underneath to make it simple for you to see variations of the current example.</li>" +
"<li><strong>Properties</strong><br />Properties are available for most examples. This editor allows you to tweak an element's properties in real-time. Not all properties are available via the property editor. For example, it would take a bit of work to add full animation editing!<br />The editors are nice but far from polished. The goal was to give you a glimpse of the possibilities in a timely way.<br />Though not mentioned yet as a feature, Frogui does have some support for property editing to help visual tools such as the demo. This will eventually be the basis for our full WYSIWYG view editor.</li>" +
"<li><strong>Brush Editor</strong><br />Allows properties of type <strong>Brush</strong> to be edited. Also allows the brush used for the demo area background to be changed. To activate, click the brush property and Brush Editor will then bind to that property.</li>" +
"<li><strong>Show Properties</strong><br />Shows or hides Properties and the Brush Editor. Because these areas are very element-dense (hundreds of DOM elements!) they are off by default. You are encouraged to show and use them, but hiding is recommended if the goal is to just preview the examples and presets.</li>" +
"</ul>" +
"<h2><span style='color: #999999;'>Known Issues and Usage Tips</span></h2>" +
"<ul>" +
"<li>As mentioned above, the WebAssembly build runs very slowly. Be patient after selecting an example or preset -- it can take up to 30+ seconds to load if properties are shown.</li>" +
"<li>The Popup element example is unique in that the properties <em>must be shown</em> to see it actually work. Specifically, the IsOpen property shows and hides the popup. Lots of fun! Make sure to show the properties before selecting the example due to an alignment bug in the Popup.</li>" +
"<li>The ScrollBar, Slider and NumericEdit controls can sometimes lose pointer (e.g. mouse) interaction in demo.</li>" +
"<li>No doubt there are other issues! Please bear with our growing pains!</li>" +
"</ul>" +
"</div>";
		}
	}
}


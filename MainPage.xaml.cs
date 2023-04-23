using Plotly.NET.LayoutObjects;
using Plotly.NET;
using Plotly.NET.ImageExport;

namespace MauiApp3;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

    }

	private void OnCounterClicked(object sender, EventArgs e)
	{

        LinearAxis xAxis = new LinearAxis();
        xAxis.SetValue("title", "xAxis");
        xAxis.SetValue("showgrid", false);
        xAxis.SetValue("showline", true);

        LinearAxis yAxis = new LinearAxis();
        yAxis.SetValue("title", "yAxis");
        yAxis.SetValue("showgrid", false);
        yAxis.SetValue("showline", true);

        LinearAxis zAxis = new LinearAxis();
        zAxis.SetValue("title", "zAxis");
        zAxis.SetValue("showgrid", false);
        zAxis.SetValue("showline", true);

        Plotly.NET.Layout layout = new Plotly.NET.Layout();
        layout.SetValue("xaxis", xAxis);
        layout.SetValue("yaxis", yAxis);
        layout.SetValue("zaxis", zAxis);
        layout.SetValue("showlegend", true);

        List<Tuple<double, double, double>> p = new List<Tuple<double, double, double>>() {
            Tuple.Create(3d,1d,1d),
            Tuple.Create(2d,2d,2d),
            Tuple.Create(1d,3d,3d)
        };

        //HTML.CreateChartHTML(GenericChart.toChartHTML(genericchart));
        var g = Plotly.NET.Chart3D.Chart.Point3D<double, double, double, double>(p)
            .WithLayout(layout);

        var k = g.ToSVGString(Width: 1000, Height: 1000);

        SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


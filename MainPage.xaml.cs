
using CommunityToolkit.Maui.Alerts;

namespace MauiTuto_project1;

public partial class MainPage : ContentPage
{
	bool isRandom;
	string hexValue;
	public MainPage()
	{
		InitializeComponent();
	}
	private void Slider_ValueChanged(object sender, EventArgs e)
	{
		if(!isRandom) {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;
            Color color = Color.FromRgb(red, green, blue);
            setColor(color);
        }
		
	}

    private void setColor(Color color)
    {
        btnRandom.BackgroundColor= color;
		Container.BackgroundColor= color;
		hexValue = color.ToHex();
		lblHex.Text= color.ToHex();
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
		isRandom= true;
		var random = new Random();
		var color = Color.FromRgb(
			random.Next(0,265),
            random.Next(0, 265),
            random.Next(0, 265));
        setColor(color);

		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBlue.Value = color.Blue;
		isRandom= false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Clipboard.SetTextAsync(hexValue);
		var toast = Toast.Make("Color copied",
			CommunityToolkit.Maui.Core.ToastDuration.Short,
			12);
		await toast.Show();
    }
}


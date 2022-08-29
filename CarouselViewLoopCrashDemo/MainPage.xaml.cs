using System.Globalization;

namespace CarouselViewLoopCrashDemo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
    }
}

public class RemoveFromParentConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not View view) return value;

        switch (view.Parent)
        {
            case Layout layout:
                layout.Remove(view);
                break;
            case Microsoft.Maui.Controls.Compatibility.Layout<View> layout:
                layout.Children.Remove(view);
                break;
            case ScrollView scrollView:
                scrollView.Content = null;
                break;
            case ContentView contentView:
                contentView.Content = null;
                break;
            case ContentPage contentPage:
                contentPage.Content = null;
                break;
            case ContentPresenter contentPresenter:
                contentPresenter.Content = null;
                break;
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}

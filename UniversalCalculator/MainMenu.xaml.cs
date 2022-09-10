using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Context;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Calculator
{
	public partial class MainMenu
	{
		public static UserControl currentView { get; set; }
		
		public MainMenu()
		{
			InitializeComponent();
			currentView = this;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender">Reference to the object that raised the event</param>
		/// <param name="e">Event data</param>
		private void ShowMathCalculator(object sender, RoutedEventArgs e)
		{
			currentView.Content = new MainPage();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender">Reference to the object that raised the event</param>
		/// <param name="e">Event data</param>
		private void ShowMortgageCalculator(object sender, RoutedEventArgs e)
		{
			currentView.Content = new MortgageCalculator();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender">Reference to the object that raised the event</param>
		/// <param name="e">Event data</param>
		private void ShowCurrencyCalculator(object sender, RoutedEventArgs e)
		{
			currentView.Content = new CurrencyCalculator();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender">Reference to the object that raised the event</param>
		/// <param name="e">Event data</param>
		private void ExitHandler(object sender, RoutedEventArgs e)
		{
			System.Environment.Exit(1);
		}

		private void HandleMessage(object sender, RoutedEventArgs e)
		{
			MessageTextBlock.Text = "Trip calculator C# code will be developed later";
		}

	}
}

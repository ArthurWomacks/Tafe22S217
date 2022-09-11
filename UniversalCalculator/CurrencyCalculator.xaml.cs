using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Calculator
{
	public partial class CurrencyCalculator
	{
		private const double USD_TO_EUR = 0.85189982;
		private const double USD_TO_GBP = 0.72872436;
		private const double USD_TO_INR = 74.257327;
		private const double EUR_TO_USD = 1.1739732;
		private const double EUR_TO_GBP = 0.8556672;
		private const double EUR_TO_INR = 87.00755;
		private const double GBP_TO_USD = 1.371907;
		private const double GBP_TO_EUR = 1.1686692;
		private const double GBP_TO_INR = 101.68635;
		private const double INR_TO_USD = 0.011492628;
		private const double INR_TO_EUR = 0.013492774;
		private const double INR_TO_GBP = 0.0098339397;

		private const char USD_SIGN = '$';
		private const string EUR_SIGN = "\u20AC";
		private const string GBP_SIGN = "\u00A3";
		private const string INR_SIGN = "\u20B9";


		public CurrencyCalculator()
		{
			InitializeComponent();
		}

		/// <summary>
		///		Converts one currency to another.
		/// </summary>
		/// <param name="sender">Reference to the object that raised event</param>
		/// <param name="e">Event data</param>
		private void ConvertButtonHandler(object sender, RoutedEventArgs e)
		{
			double amount;

			double.TryParse(AmountTextBox.Text, out amount);
			if(amount > 0)
			{
				string  selectedConvertFromItem = (ConvertFromComboBox.SelectedItem as ComboBoxItem).Tag.ToString();
				string selectedConvertToItem = (ConvertToComboBox.SelectedItem as ComboBoxItem).Tag.ToString();
				if (!string.IsNullOrEmpty(selectedConvertFromItem) && !string.IsNullOrEmpty(selectedConvertToItem))
				{
					switch (selectedConvertFromItem)
					{
						case "USD":			
							if (selectedConvertFromItem.Equals(selectedConvertToItem))
							{
								this.SetValues(amount, amount, selectedConvertFromItem, selectedConvertToItem, USD_SIGN, 1.0, 1.0);
							}
							else
							{
								bool res = selectedConvertToItem.Equals("EUR") ? this.SetValues(amount, amount * USD_TO_EUR, "US Dollars", "Euros", char.Parse(EUR_SIGN), USD_TO_EUR, EUR_TO_USD) :
									selectedConvertToItem.Equals("GBP") ? this.SetValues(amount, amount * USD_TO_GBP, "US Dollars", "British Pounds", char.Parse(GBP_SIGN), USD_TO_GBP, GBP_TO_USD) :
										selectedConvertToItem.Equals("INR") ? this.SetValues(amount, amount * USD_TO_INR, "US Dollars", "Indian Rupee", char.Parse(INR_SIGN), USD_TO_INR, INR_TO_USD) : false;
							if (!res)
								{
									ResultTextBlock.Text = "No such conversion exists";
									ResultTextBlock.Foreground = new SolidColorBrush(Colors.Red);
								}
							}
							break;
						case "EUR":
							if (selectedConvertFromItem.Equals(selectedConvertToItem))
							{
								this.SetValues(amount, amount, selectedConvertFromItem, selectedConvertToItem, char.Parse(EUR_SIGN), 1.0, 1.0);
							}
							else
							{
								bool res = selectedConvertToItem.Equals("USD") ? this.SetValues(amount, amount * EUR_TO_USD, "Euros", "US Dollars", USD_SIGN, EUR_TO_USD, USD_TO_EUR) :
									selectedConvertToItem.Equals("GBP") ? this.SetValues(amount, amount * EUR_TO_GBP, "Euros", "British Pounds", char.Parse(GBP_SIGN), EUR_TO_GBP, GBP_TO_EUR) :
										selectedConvertToItem.Equals("INR") ? this.SetValues(amount, amount * EUR_TO_INR, "Euros", "Indian Rupee", char.Parse(INR_SIGN), EUR_TO_INR, INR_TO_EUR) : false;
								if (!res)
								{
									ResultTextBlock.Text = "No such conversion exists";
									ResultTextBlock.Foreground = new SolidColorBrush(Colors.Red);
								}
							}
							break;
						case "GBP":
							if (selectedConvertFromItem.Equals(selectedConvertToItem))
							{
								this.SetValues(amount, amount, selectedConvertFromItem, selectedConvertToItem, char.Parse(GBP_SIGN), 1.0, 1.0);
							}
							else
							{
								bool res = selectedConvertToItem.Equals("EUR") ? this.SetValues(amount, amount * GBP_TO_EUR, "British Pound", "Euros", char.Parse(EUR_SIGN), GBP_TO_EUR, EUR_TO_GBP) :
									selectedConvertToItem.Equals("USD") ? this.SetValues(amount, amount * GBP_TO_USD, "British Pound", "US Dollars", USD_SIGN, GBP_TO_USD, EUR_TO_USD) :
										selectedConvertToItem.Equals("INR") ? this.SetValues(amount, amount * GBP_TO_INR, "British Pound", "Indian Rupee", char.Parse(INR_SIGN), GBP_TO_INR, EUR_TO_INR) : false;
								if (!res)
								{
									ResultTextBlock.Text = "No such conversion exists";
									ResultTextBlock.Foreground = new SolidColorBrush(Colors.Red);
								}
							}
							break;
						case "INR":
							if (selectedConvertFromItem.Equals(selectedConvertToItem))
							{
								this.SetValues(amount, amount, selectedConvertFromItem, selectedConvertToItem, char.Parse(INR_SIGN), 1.0, 1.0);
							}
							else
							{
								bool res = selectedConvertToItem.Equals("EUR") ? this.SetValues(amount, amount * INR_TO_EUR, "Indian Rupee", "Euros", char.Parse(EUR_SIGN), INR_TO_EUR, EUR_TO_INR) :
									selectedConvertToItem.Equals("GBP") ? this.SetValues(amount, amount * INR_TO_GBP, "Indian Rupee", "British Pounds", char.Parse(GBP_SIGN), INR_TO_GBP, GBP_TO_INR) :
										selectedConvertToItem.Equals("USD") ? this.SetValues(amount, amount * INR_TO_USD, "Indian Rupee", "US Dollars", USD_SIGN, INR_TO_USD, USD_TO_INR) : false;
								if (!res)
								{
									ResultTextBlock.Text = "No such conversion exists";
									ResultTextBlock.Foreground = new SolidColorBrush(Colors.Red);
								}
							}
							break;
						default:
							break;
					}
				}
				
			}
		}

		/// <summary>
		///		Sets calculated values (results) in approprate form
		/// </summary>
		/// <param name="amount">Initial amount</param>
		/// <param name="convertedAmount">Amount converted to another currency</param>
		/// <param name="from">Currency which have to be converted</param>
		/// <param name="to">Currency in which to convert</param>
		/// <param name="sign">Currency sign</param>
		/// <param name="rate">Current rate</param>
		/// <param name="reverseCurrency">Opposite rate</param>
		/// <returns></returns>
		private bool SetValues(double amount, double convertedAmount, string from, string to, char sign, double rate, double reversedRate)
		{
			AmountTexBlock.Text = $"{amount} {from}";
			ResultTextBlock.Text = $"{sign}{convertedAmount} {to}";
			CurrencyFromTextBlock.Text = $"1 {from} = {rate} {to}";
			CurrencyToTextBlock.Text = $"1 {to} = {reversedRate} {from}";
			return true;
		}

		private void ExitButtonHandler(object sender, RoutedEventArgs e)
		{

		}
	}
}

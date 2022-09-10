using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Calculator
{
	public partial class MortgageCalculator
	{
		public MortgageCalculator()
		{
			InitializeComponent();
		}

		/// <summary>
		///		Calculates Monthly interest rate and monthly repayment according to input data
		/// </summary>
		/// <param name="sender">Reference to the object that raised the event</param>
		/// <param name="e">Event data</param>
		private void CalculateInputData(object sender, RoutedEventArgs e)
		{
			double principalBorrow;
			int years;
			int months;
			double yearlyInterestRate;

			double.TryParse(PrincipalTextBox.Text, out principalBorrow);
			int.TryParse(YearsTextBox.Text, out years);
			int.TryParse(MonthsTextBox.Text, out months);
			double.TryParse(YearlyInterestRateTextBox.Text, out yearlyInterestRate);

			months += years == 0 ? 0 : (years * 12);
			double monthlyInterestRate = Math.Round((yearlyInterestRate / 100) / 12, 4);

			double result = principalBorrow * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, months)) /
				Math.Pow(1 + monthlyInterestRate, months - 1);

			MonthlyInterestRateTextBox.Text = monthlyInterestRate.ToString();
			MonthlyRepaimentTextBox.Text = result.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender">Reference to the object that raised the event</param>
		/// <param name="e">Event data</param>
		private void ExitButtonHandler(object sender, RoutedEventArgs e)
		{
			MainMenu.currentView.Content = new MainMenu();
		}
	}
}

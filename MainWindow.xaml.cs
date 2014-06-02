using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mortgage_Repayment_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double TermMonths = (Convert.ToDouble(TermBox.Text)) * 12;
            double MonthlyDecimalInterestRate = ((Convert.ToDouble(InterestRateBox.Text)) / 1200);
            double Capital = Convert.ToDouble(CapitalBox.Text);
            if (InterestOnlyRadio.IsChecked == true)
            {
                double MonthlyPaymentDouble = InterestOnly(Capital, MonthlyDecimalInterestRate);
                string MonthlyPaymentString = MonthlyPaymentDouble.ToString();
                string message = "Your Monthly Payment is: " + MonthlyPaymentString;
                System.Windows.MessageBox.Show(message);
            }
            else if (CapitalRepaymentRadio.IsChecked == true)
            {
                double MonthlyPaymentDouble = CapitalRepay(Capital, MonthlyDecimalInterestRate, TermMonths);
                string MonthlyPaymentString = MonthlyPaymentDouble.ToString();
                string message = "Your Monthly Repayment is: " + MonthlyPaymentString;
                System.Windows.MessageBox.Show(message);
            }
        }
        public double InterestOnly(double Capital,double MonthlyDecimalIntrestRate)
        {
            double MonthlyCost = Capital * MonthlyDecimalIntrestRate;
            return MonthlyCost;
        }
        private double CapitalRepay(double Capital, double MothlyDecimalInterestRate, double TermMonths)
        {
            double MonthlyCost = (Capital * MothlyDecimalInterestRate) / (1 - Math.Pow((1 + MothlyDecimalInterestRate),(-TermMonths)));
            return MonthlyCost;
        }
    }
}

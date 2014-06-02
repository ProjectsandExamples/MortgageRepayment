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
                string message = "Your Monthly Payment is: £" + MonthlyPaymentString;
                System.Windows.MessageBox.Show(message);
                double TotalInterestPaymentDouble = (MonthlyPaymentDouble * TermMonths);
                double TotalPaymentDouble = TotalInterestPaymentDouble + Capital;
                string TotalInterestPaymentString = TotalInterestPaymentDouble.ToString();
                string TotalPaymentString = TotalPaymentDouble.ToString();
                string message2 = "Over the lifetime of the mortgage you will repay £" + TotalPaymentString + ", of that £" + TotalInterestPaymentString + " is interest.";
                System.Windows.MessageBox.Show(message2);

            }
            else if (CapitalRepaymentRadio.IsChecked == true)
            {
                double MonthlyPaymentDouble = CapitalRepay(Capital, MonthlyDecimalInterestRate, TermMonths);
                string MonthlyPaymentString = MonthlyPaymentDouble.ToString();
                string message = "Your Monthly Repayment is: £" + MonthlyPaymentString;
                System.Windows.MessageBox.Show(message);
                double TotalInterestPaymentDouble = (MonthlyPaymentDouble * TermMonths);
                double TotalPaymentDouble = TotalInterestPaymentDouble + Capital;
                string TotalInterestPaymentString = TotalInterestPaymentDouble.ToString();
                string TotalPaymentString = TotalPaymentDouble.ToString();
                string message2 = "Over the lifetime of the mortgage you will repay £" + TotalPaymentString + ", of that £" + TotalInterestPaymentString + " is interest.";
                System.Windows.MessageBox.Show(message2);
            }
            else
            {
                System.Windows.MessageBox.Show("Please Select a Mortgage Type");
            }
        }
        public double InterestOnly(double Capital,double MonthlyDecimalIntrestRate)
        {
            double MonthlyCost = Capital * MonthlyDecimalIntrestRate;
            return MonthlyCost;
        }
        private double CapitalRepay(double Capital, double MothlyDecimalInterestRate, double TermMonths)
        {
            // Uses formula from wikipedia http://en.wikipedia.org/w/index.php?title=Mortgage_calculator&diff=next&oldid=601962956
            double MonthlyCost = (Capital * MothlyDecimalInterestRate) / (1 - Math.Pow((1 + MothlyDecimalInterestRate),(-TermMonths)));
            return MonthlyCost;
        }
    }
}

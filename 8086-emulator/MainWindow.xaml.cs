using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace _8086_emulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comboBoxRegister1.Text = "AX";
            comboBoxRegister2.Text = "BX";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // wyswietl rozne w zaleznosci od combobox content.


            if (comboBoxRegister1.Text != comboBoxRegister2.Text)
            {
                Trace.WriteLine($"Instruction: {comboBoxInstruction.Text}");
                Trace.WriteLine($"From: {comboBoxRegister1.Text} \tTo: {comboBoxRegister2.Text}");
            } else
            {
                Trace.WriteLine($"Can't {comboBoxInstruction.Text} from {comboBoxRegister1.Text} to {comboBoxRegister2.Text}.");
                Trace.Write("Please choose different registers");
            }

            // We want a RESET and RANDOM button
            // We also want ACTUAL registers
            // And the ability to write to them.
        }
    }
}

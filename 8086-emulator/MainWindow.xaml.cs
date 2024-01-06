using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxRegister1.Text != comboBoxRegister2.Text)
            {
                RegisterManager registerManager = new RegisterManager(registerAX, registerBX, registerCX, registerDX);


                string instruction = comboBoxInstruction.Text;
                string register_one = "register" + comboBoxRegister1.Text;
                string register_two = "register" + comboBoxRegister2.Text;

                string res = registerManager.GetRegisterText(register_one);
                
                if (instruction == "MOV")
                {
                    registerManager.Mov(register_one, register_two);
                }
                if (instruction == "XCHG")
                {
                    registerManager.Xchg(register_one, register_two);
                }

                Trace.WriteLine($"Instruction: {comboBoxInstruction.Text}");
                Trace.WriteLine($"From: {comboBoxRegister1.Text} \tTo: {comboBoxRegister2.Text}");
            }
            else
            {
                Trace.WriteLine($"Can't {comboBoxInstruction.Text} from {comboBoxRegister1.Text} to {comboBoxRegister2.Text}.");
                Trace.Write("Please choose different registers");
            }
        }

        private void HandleInput(string input, TextBlock register)
        {
            string hexPattern = "^[0-9a-fA-F]+$";

            if (Regex.IsMatch(input, hexPattern))
            {
                // valid input, assign it to register.Text
                register.Text = input.PadLeft(4, '0');
            }
            else
            {
                // input not valid -> display an error message
                MessageBox.Show("Invalid input. Please enter a valid hexadecimal value.");
            }
        }

        private void InsertManualValueAX(object sender, RoutedEventArgs e)
        {
            HandleInput(registerAX_Input.Text, registerAX);
        }

        private void InsertManualValueBX(object sender, RoutedEventArgs e)
        {
            HandleInput(registerBX_Input.Text, registerBX);
        }

        private void InsertManualValueCX(object sender, RoutedEventArgs e)
        {
            HandleInput(registerCX_Input.Text, registerCX);
        }

        private void InsertManualValueDX(object sender, RoutedEventArgs e)
        {
            HandleInput(registerDX_Input.Text, registerDX);
        }

        private void RandomRegisterValues(object sender, RoutedEventArgs e)
        {
            // Randomize register values

            Random random = new Random();

            List<TextBlock> registers = new List<TextBlock>
            {
                registerAX,
                registerBX,
                registerCX,
                registerDX
            };

            // for each register

            foreach (TextBlock block in registers)
            {
                byte byte1 = (byte)random.Next(256);
                byte byte2 = (byte)random.Next(256);

                ushort randomValue = (ushort)((byte2 << 8) | byte1);

                block.Text = randomValue.ToString("X4");

            }
        }
        private void ResetRegisterValues(object sender, RoutedEventArgs e)
        {
            // Reset
            registerAX.Text = "0000";
            registerBX.Text = "0000";
            registerCX.Text = "0000";
            registerDX.Text = "0000";
        }
    }
}
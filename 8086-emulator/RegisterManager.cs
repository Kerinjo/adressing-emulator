using System;
using System.Collections.Generic;
using System.Windows.Controls;

public class RegisterManager
{
    private Dictionary<string, TextBlock> registerDictionary;

    public RegisterManager(TextBlock registerAX, TextBlock registerBX, TextBlock registerCX, TextBlock registerDX)
    {
        // Initialize the dictionary in the constructor
        registerDictionary = new Dictionary<string, TextBlock>
            {
                { "registerAX", registerAX },
                { "registerBX", registerBX },
                { "registerCX", registerCX },
                { "registerDX", registerDX }
                // Add more registers as needed
            };
    }

    // Method to get the TextBlock.Text for a given register name
    public string GetRegisterText(string registerName)
    {
        if (registerDictionary.TryGetValue(registerName, out TextBlock textBlock))
        {
            return textBlock.Text;
        }
        else
        {
            Console.WriteLine($"TextBlock for register {registerName} not found.");
            return string.Empty;
        }
    }
    public void Mov(string register_one, string register_two)
    {
        registerDictionary[register_one].Text = registerDictionary[register_two].Text;
    }

    public void Xchg(string register_one, string register_two)
    {
        string temp = registerDictionary[register_one].Text;
        registerDictionary[register_one].Text = registerDictionary[register_two].Text;
        registerDictionary[register_two].Text = temp;
    }
}
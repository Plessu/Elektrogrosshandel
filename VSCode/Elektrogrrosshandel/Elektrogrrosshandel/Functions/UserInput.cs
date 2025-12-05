using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.Functions
{
    internal class UserInput
    {
        static internal int MenuChoice(int MaxChoice)
        { 
            int confirmation = AnsiConsole.Prompt(
            new TextPrompt<int>("[bold #00afff]---[/] [bold blue]Your Choice[/] [bold #00afff]---[/]")
            .AddChoice(1)
            .AddChoice(MaxChoice));

            return confirmation;
        }
        static internal string GetStringInput(string PromptMessage)
        {
            string userInput = AnsiConsole.Prompt(
            new TextPrompt<string>($"[bold #00afff]---[/] [bold blue]{PromptMessage}[/] [bold #00afff]---[/]"));
            return userInput;
        }
    }
}

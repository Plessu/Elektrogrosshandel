using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel
{
    internal class GetUserInput
    {
        static internal int Choice(int MaxChoice)
        {
            AnsiConsole.MarkupLine("");
            int confirmation = AnsiConsole.Prompt(
            new TextPrompt<int>("[bold #00afff]---[/] [bold blue]Your Choice[/] [bold #00afff]---[/]")
            .AddChoice(1)
            .AddChoice(MaxChoice));

            return confirmation;
        }
    }
}

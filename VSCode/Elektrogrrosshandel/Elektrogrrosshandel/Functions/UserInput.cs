// """

using Spectre.Console;

namespace Elektrogrosshandel.Functions
{
    internal class UserInput
    {
        static internal int MenuChoice(int MaxChoice)
        {
            int confirmation = AnsiConsole.Prompt(
                                    new TextPrompt<int>("[bold #00afff]---[/] [bold blue]Your Choice[/] [bold #00afff]---[/]")
                                                    .AddChoices(GenerateChoices(MaxChoice)));

            return confirmation;
        }
        static internal string GetStringInput(string PromptMessage)
        {
            string userInput = AnsiConsole.Prompt(
            new TextPrompt<string>($"[bold #00afff]---[/] [bold blue]{PromptMessage}[/] [bold #00afff]---[/]"));
            return userInput;
        }

        static internal string GetPasswordInput(string PromptMessage)
        {
            string userInput = AnsiConsole.Prompt(
            new TextPrompt<string>($"[bold #00afff]---[/] [bold blue]{PromptMessage}[/] [bold #00afff]---[/]")
                .Secret('*'));
            return userInput;
        }

        static internal int GetIntInput(string PromptMessage)
        {
            int userInput = AnsiConsole.Prompt(
            new TextPrompt<int>($"[bold #00afff]---[/] [bold blue]{PromptMessage}[/] [bold #00afff]---[/]"));
            return userInput;
        }

        static private List<int> GenerateChoices(int MaxChoice)
        {
            List<int> choices = new List<int>();
            for (int i = 1; i <= MaxChoice; i++)
            {
                choices.Add(i);
            }
            return choices;
        }
    }
}

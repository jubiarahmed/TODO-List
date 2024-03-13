Console.WriteLine("1.TodoList");
Console.WriteLine("2.Add TodoList");
Console.WriteLine("3.Remove List");
Console.WriteLine("4.Exit");

var userchoice = Console.ReadLine();

if (userchoice == "1")
{
    PrintSelectedOption("TODOs");
}
else if (userchoice == "2")
{
    PrintSelectedOption("Add a TODO");
}
else if (userchoice == "3")
{
    PrintSelectedOption("Remove a TODO");
}
else if (userchoice == "4")
{
    PrintSelectedOption("Exit");
}

Console.ReadKey();
void PrintSelectedOption(string SelectedOption)
{
    Console.WriteLine("Selected option: " + SelectedOption);
}

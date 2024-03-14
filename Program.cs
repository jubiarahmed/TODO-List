using System;
using System.Reflection.Metadata.Ecma335;
Console.WriteLine("Welcome to the console project (TODO List)");

var todos = new List<string>();

bool shallExit = false;
while (!shallExit)
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("S.TodoList");
    Console.WriteLine("A.Add TodoList");
    Console.WriteLine("R.Remove List");
    Console.WriteLine("E.Exit");

    var userchoice = Console.ReadLine();

    switch (userchoice)
    {
        case "E":
        case "e":
            shallExit = true;
            break;
        case "S":
        case "s":
            SeeAllTodo();
            break;
        case "A":
        case "a":
            AddTodo();
            break;
        case "R":
        case "r":
            RemoveTodo();
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}



Console.ReadKey();

void SeeAllTodo()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    else
    {
        for (int i = 0; i < todos.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{todos[i]}");
        }
    }
}

void AddTodo()
{
    string description;

    do
    {
        Console.WriteLine("Enter the TODO description");
        description = Console.ReadLine();
    }
    while (!IsdescriptionValid(description));
    todos.Add(description);
}
bool IsdescriptionValid(string description)
{
    if (description == "")
    {
        Console.WriteLine("The Description cannnot be Empty");
        return false;
    }
    else if (todos.Contains(description))
    {
        Console.WriteLine("The description must be unique");
        return false;
    }
    return true;
}
void RemoveTodo()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    int index;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove");
        SeeAllTodo();
    }
    while (!TryReadIndex(out index));

   RemoveTodoAtIndex(index-1);
}
bool TryReadIndex(out int index)
{
    var userInput = Console.ReadLine();
    if (userInput == "")
    {
        index = 0;
        Console.WriteLine("Selected index cannot be empty");
        return false;
    }
    if (int.TryParse(userInput, out index) && index >= 1 && index <= todos.Count)
    {
        return true;
    }
    Console.WriteLine("The given index is not valid.");
    return false;

}
void RemoveTodoAtIndex(int index)
{

    var todoToBeRemoved = todos[index];
    todos.RemoveAt(index);
    Console.WriteLine("Todo Removed: " + todoToBeRemoved);
}
static void ShowNoTodosMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}
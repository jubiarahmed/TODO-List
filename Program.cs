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

    void PrintSelectedOption(string SelectedOption)
    {
        Console.WriteLine("Selected option: " + SelectedOption);
    }
    void AddTodo()
    {
        bool isValidDescription = false;
        while (!isValidDescription)
        {
            Console.WriteLine("Enter the TODO description");
            var description = Console.ReadLine();

            if (description == "")
            {
                Console.WriteLine("The Description cannnot be Empty");
            }
            else if (todos.Contains(description))
            {
                Console.WriteLine("The description must be unique");
            }
            else
            {
                isValidDescription = true;
                todos.Add(description);
            }
        }

    }
void SeeAllTodo()
{
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet");
    }
    else
    {
        for (int i = 0; i < todos.Count; i++)
        {
            Console.WriteLine ($"{i+1}.{todos[i]}");
        }
    }
}
void RemoveTodo()
{
    if(todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
        return;
    }
    bool isIndexValid=false;
    while (!isIndexValid)
    {
        Console.WriteLine("Select the index of the TODO you want to remove");
        SeeAllTodo();
        var userInput = Console.ReadLine();
        if (userInput == "")
        {
            Console.WriteLine("Selected index cannot be empty");
            continue;
        }
        if(int.TryParse(userInput,out int index) && index >=1 && index <= todos.Count)
        {
            var indexOfTodo = index - 1;
            var todoToBeRemoved = todos[indexOfTodo];
            todos.RemoveAt(indexOfTodo);
            isIndexValid = true;
            Console.WriteLine("TODO removed: " + todoToBeRemoved);
        }
        else
        {
            Console.WriteLine("The given index is not valid.");
        }
    }
}
   
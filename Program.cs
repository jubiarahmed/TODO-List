using System;
using System.Collections.Generic;

namespace TodoList
{
    class Program
    {
        static List<string> todos = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the console project (TODO List)");

            bool shallExit = false;
            while (!shallExit)
            {
                DisplayMenu();

                string userChoice = Console.ReadLine().Trim().ToLower();

                switch (userChoice)
                {
                    case "e":
                        shallExit = true;
                        break;
                    case "s":
                        SeeAllTodo();
                        break;
                    case "a":
                        AddTodo();
                        break;
                    case "r":
                        RemoveTodo();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("S. See Todo List");
            Console.WriteLine("A. Add Todo");
            Console.WriteLine("R. Remove Todo");
            Console.WriteLine("E. Exit");
        }

        static void SeeAllTodo()
        {
            if (todos.Count == 0)
            {
                ShowNoTodosMessage();
            }
            else
            {
                for (int i = 0; i < todos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{todos[i]}");
                }
            }
        }

        static void AddTodo()
        {
            string description;

            do
            {
                Console.WriteLine("Enter the TODO description");
                description = Console.ReadLine().Trim();
            }
            while (!IsDescriptionValid(description));

            todos.Add(description);
            Console.WriteLine("Todo Added: " + description);
        }

        static bool IsDescriptionValid(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("The Description cannot be Empty");
                return false;
            }
            else if (todos.Contains(description))
            {
                Console.WriteLine("The description must be unique");
                return false;
            }
            return true;
        }

        static void RemoveTodo()
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
            }
            while (!TryReadIndex(out index));

            RemoveTodoAtIndex(index - 1);
        }

        static bool TryReadIndex(out int index)
        {
            if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > todos.Count)
            {
                Console.WriteLine("The given index is not valid.");
                return false;
            }
            return true;
        }

        static void RemoveTodoAtIndex(int index)
        {
            var todoToBeRemoved = todos[index];
            todos.RemoveAt(index);
            Console.WriteLine("Todo Removed: " + todoToBeRemoved);
        }

        static void ShowNoTodosMessage()
        {
            Console.WriteLine("No TODOs have been added yet.");
        }
    }
}

using System;

class TestClass
{
    static int whichIndex;
    static int index;
    static bool choiceCheck;
    static string _todoName;
    static string _todoDesription;
    static List<string> todos = new List<string>();
    static List<string> descriptions = new List<string>();

    static void Main(string[] args)
    {
        showMenu();

        static void showMenu()
        {
            Console.Clear();
            Console.WriteLine(" -------MENU-------");
            Console.WriteLine("1. Create new todo ");
            Console.WriteLine("2. Show all todos ");
            Console.WriteLine("3. Edit existing todo ");
            Console.WriteLine("4. Complete todo ");
            Console.WriteLine("5. Exit");
            Console.WriteLine("-------------------");
            Console.WriteLine("Choose what you want to do: \n");
            string choice = Console.ReadLine();
            Console.Clear();
            if (!int.TryParse(choice, out int choiceValue) || choiceValue > 5)
            {
                Console.WriteLine("Try your choice again: ");
                showMenu();
            }
            else
            {
                switch (choiceValue)
                {
                    case 1:
                        createNewTodo();
                        break;
                    case 2:
                        showTodos();
                        break;
                    case 3:
                        editTodo();
                        break;
                    case 4:
                        completeTodo();
                        break;
                    case 5:
                        exit();
                        break;
                }
            }
        }

        static void createNewTodo()
        {
            bool next = true;
            do
            {
                Console.WriteLine("Add name: \n");
                _todoName = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Add description: \n");
                _todoDesription = Console.ReadLine();
                Console.Clear();
                todos.Add(_todoName);
                descriptions.Add(_todoDesription);

                Console.WriteLine("Want add another todo? Choose yes or no: ");
                string answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "yes":
                        continue;
                    case "no":
                        next = false;
                        showMenu();
                        break;
                    default:
                        Console.WriteLine("Wrong choice...back to menu!");
                        showMenu();
                        break;
                }
            } 
            while (next);
        }

        static void showTodos()
        {
            enumerate();
            escapeFromLoops();
        }

        static void editTodo()
        {
            string todoOrDescription;
            index = 1;

            enumerate();

            Console.WriteLine("Which todo do you want to update? Write a number: \n");
            whichIndex = int.Parse(Console.ReadLine());

            if (whichIndex <= index)
            {
                Console.WriteLine("Want you update name or description? Write 't' or 'd'");
                todoOrDescription = Console.ReadLine();
                Console.Clear();
                if (todoOrDescription == "t")
                {
                    Console.WriteLine("Write new name of your todo: \n");
                    string updatedTodo = Console.ReadLine();
                    Console.Clear();
                    todos[whichIndex] = updatedTodo;
                }
                else if (todoOrDescription == "d")
                {
                    Console.WriteLine("Write new name of your description: \n");
                    string updatedDescription = Console.ReadLine();
                    Console.Clear();
                    descriptions[whichIndex] = updatedDescription;
                }
            }
            else
            {
                Console.WriteLine("This todo doesnt exist, try it again...");
                editTodo();
            }

            Console.WriteLine("Done, now you are redirect back to menu...");
            showMenu();
        }

        static void completeTodo()
        {
            index = 1;
            enumerate();
            Console.WriteLine("Which todo do you want to complete? Write a number: ");
            Console.Clear();
            if (int.TryParse(Console.ReadLine(), out int whichIndex) && whichIndex >= 1 && whichIndex <= todos.Count)
            {
                todos.RemoveAt(whichIndex - 1);
                descriptions.RemoveAt(whichIndex - 1);
                Console.WriteLine("Todo completed and removed.");
            }
            else
            {
                Console.WriteLine("Invalid input or todo does not exist.");
                completeTodo();
            }

            escapeFromLoops();
        }


        static void exit()
        { 
            Environment.Exit(0);
        }

        static void escapeFromLoops()
        {
            Console.WriteLine("Want you go back to menu or exit application? Write 'menu' or 'exit'...");
            var choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "menu":
                    showMenu();
                    break;
                case "exit":
                    exit();
                    break;
                default:
                    Console.WriteLine("Wrong choice, try it again!");
                    break;
            }
        }

        static void enumerate()
        {
            foreach (var todoPair in todos.Zip(descriptions, (todo, desc) => new { Todo = todo, Description = desc }))
            {
                Console.WriteLine("{0}. {1}\n   - {2}", index, todoPair.Todo, todoPair.Description);
                index++;
            }
        }
    }
}

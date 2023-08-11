using System;

class TestClass
{
    static bool choiceCheck;
    static string _todoName;
    static string _todoDesription;
    static Dictionary<string, string> _todos = new ();

    static void Main(string[] args)
    {
        showMenu();
        //createNewTodo();
        //showTodos();

        static void showMenu()
        {
            

            bool choiceCheck = true;
            while (choiceCheck)
            {
                Console.WriteLine(" -------MENU-------");
                Console.WriteLine("1. Create new todo ");
                Console.WriteLine("2. Show all todos ");
                Console.WriteLine("3. Edit existing todo ");
                Console.WriteLine("4. Complete todo ");
                Console.WriteLine("5. Exit");
                Console.WriteLine("-------------------");
                Console.WriteLine("Choose what you want to do: \n");
                string choice = Console.ReadLine();
                if (!int.TryParse(choice, out int choiceValue) || choiceValue > 5)
                {
                    Console.WriteLine("Try your choice again: ");
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
                            break;
                        case 4:
                            break;
                        case 5:
                            exit();
                            break;
                    }
                }
            }
        }

        static void createNewTodo()
        {
            bool dalsi = true;
            do
            {
                Console.WriteLine("Add name: \n");
                _todoName = Console.ReadLine();
                Console.WriteLine("Add description: \n");
                _todoDesription = Console.ReadLine();
                _todos.Add(_todoName, _todoDesription);
                Console.WriteLine("Want add another todo? Choose yes or no: ");
                string answer = Console.ReadLine();
                
                if (answer == "no")
                {
                    dalsi = false;
                }
                else
                {
                    Console.WriteLine("Wrong choice...back to menu\n");
                    showMenu();
                }
            } while (dalsi);
            
        }

        
        static void showTodos()
        {
            foreach (KeyValuePair<string, string> pair in _todos)
            {
                Console.WriteLine("Todo: \n {0}\n  - {1}\n", pair.Key, pair.Value);
            }
        }

        static void editTodo()
        {
            
        }

        static void completeTodo()
        {
            
        }

        static void exit()
        {
            Environment.Exit(0);
        }
    }
}
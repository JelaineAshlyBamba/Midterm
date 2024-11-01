using System;
using System.Collections.Generic;

public class TreeNode
{
    public string Name { get; set; }
    public List<TreeNode> Children { get; set; }

    public TreeNode(string name)
    {
        Name = name;
        Children = new List<TreeNode>();
    }

    public void AddChild(TreeNode child)
    {
        Children.Add(child);
    }
}

public partial class Program
{
    static void Main(string[] args)
    {
        TreeNode menu = CreateMenu();
        NavigateMenu(menu);
    }

    static TreeNode CreateMenu()
    {
        var root = new TreeNode("Home");

        var developmentProcess = new TreeNode("Software Development Process");
        var traditional = new TreeNode("Traditional");
        traditional.AddChild(new TreeNode("Waterfall Model"));
        traditional.AddChild(new TreeNode("V-Model"));
        traditional.AddChild(new TreeNode("Back"));

        var agile = new TreeNode("Agile");
        agile.AddChild(new TreeNode("Scrum"));
        agile.AddChild(new TreeNode("Kanban"));
        agile.AddChild(new TreeNode("Back"));

        developmentProcess.AddChild(traditional);
        developmentProcess.AddChild(agile);
        developmentProcess.AddChild(new TreeNode("Back"));

        var programParadigms = new TreeNode("Program Paradigms");
        var imperative = new TreeNode("Imperative");
        imperative.AddChild(new TreeNode("Procedural Programming"));
        imperative.AddChild(new TreeNode("Object-Oriented Programming"));
        imperative.AddChild(new TreeNode("Back"));

        var declarative = new TreeNode("Declarative");
        declarative.AddChild(new TreeNode("Functional Programming"));
        declarative.AddChild(new TreeNode("Logic Programming"));
        declarative.AddChild(new TreeNode("Back"));

        programParadigms.AddChild(imperative);
        programParadigms.AddChild(declarative);
        programParadigms.AddChild(new TreeNode("Back"));

        root.AddChild(developmentProcess);
        root.AddChild(programParadigms);
        root.AddChild(new TreeNode("Close"));

        return root;
    }

    static void DisplayMenu(TreeNode node, int depth = 0)
    {
        Console.WriteLine(new string(' ', depth * 2) + node.Name);

        for (int i = 0; i < node.Children.Count; i++)
        {
            Console.WriteLine(new string(' ', (depth + 1) * 2) + $"{i}. {node.Children[i].Name}");
        }
    }

    static void NavigateMenu(TreeNode node)
    {
        TreeNode currentNode = node;
        Stack<TreeNode> history = new Stack<TreeNode>(); // Track navigation history

        while (true)
        {
            Console.Clear();
            DisplayMenu(currentNode);
            Console.WriteLine("Select a menu item by number (or type 'exit' to quit):");

            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                break;
            }

            if (int.TryParse(input, out int choice) && choice >= 0 && choice < currentNode.Children.Count)
            {
                var selectedNode = currentNode.Children[choice];

                if (selectedNode.Name == "Back")
                {
                    // Go back to the previous node if there is one
                    if (history.Count > 0)
                    {
                        currentNode = history.Pop(); // Pop from history to go back
                    }
                }
                else
                {
                    // Save the current node to history before navigating down
                    history.Push(currentNode);
                    currentNode = selectedNode;
                }
            }
            else
            {
                Console.WriteLine("Invalid selection, please try again.");
                Console.ReadLine(); // Wait for user input before continuing
            }
        }
    }
}

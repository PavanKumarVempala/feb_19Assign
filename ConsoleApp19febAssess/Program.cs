using ConsoleApp19febAssess;
using System;
using System.Collections.Generic;

public class Program
{
    static List<Players> players = new List<Players>();

    static void Main(string[] args)
    {
        
        players.Add(new Players(1, "John", "Doe", 25));
        players.Add(new Players(2, "Jane", "Smith", 30));
        players.Add(new Players(3, "Mike", "Johnson", 28));

        Console.WriteLine("Welcome to the Player Management. ");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Get all players");
        Console.WriteLine("2. Get player by id");
        Console.WriteLine("3. Exit");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 3))
        {
            Console.WriteLine("Invalid input. Please enter a valid option.");
        }

        switch (choice)
        {
            case 1:
                GetAllPlayers();
                break;
            case 2:
                GetPlayerById();
                break;
            case 3:
                Console.WriteLine("Exited");
                break;
        }
    }

    static void GetAllPlayers()
    {
        Console.WriteLine("List of all players:");
        foreach (var player in players)
        {
            Console.WriteLine($"{player.Id}: {player.FirstName} {player.LastName}, Age: {player.Age}");
        }
    }

    static void GetPlayerById()
    {
        Console.WriteLine("Enter player id:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid id.");
        }

        Players player = players.Find(p => p.Id == id);
        if (player != null)
        {
            Console.WriteLine($"Player found - {player.FirstName} {player.LastName}, Age: {player.Age}");
        }
        else
        {
            Console.WriteLine("Player not found.");
        }
    }
}
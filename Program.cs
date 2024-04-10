
class PlayerCharacter
// this class represents players character in this game 

{
    //properties for the  players Name , Health, Strength
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
   // Constructor to initialize the player character 
    public PlayerCharacter(string name, int health, int strength)
    {
        Name = name;
        Health = health;
        Strength = strength;
    }
    // Method to display player's information
    public void DisplayInfo()
    {
        // displaying players Name, Health and Strength
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Health: {Health}");
        Console.WriteLine($"Strength: {Strength}");
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            Health = 0; // Ensure that health doesn't go below 0
        }
        Console.WriteLine($"{Name} takes {damage} damage. Health: {Health}");
    }

    // Method to rest and regain health
    public void Rest()
    {
        int healthGain = Strength * 2; // Health gain is based on strength
        Health += healthGain;
        Console.WriteLine($"{Name} rests and gains {healthGain} health. Health: {Health}");
    }

}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Mystic Woods Adventure!");
        Console.WriteLine("You find yourself at the entrance of the Mystic Woods in search of a legendary treasure.");
        Console.WriteLine("Please enter your character's name:");

        string playerName = Console.ReadLine();

        // Initialize player character with 100 health and specified strength
        PlayerCharacter player = new PlayerCharacter(playerName, 100, 5);

        Console.WriteLine($"\nWelcome, {player.Name}! Your adventure begins now.");
        player.DisplayInfo(); // Display player's information

        // Start the adventure with the player
        StartAdventure(player);
    }

    static void StartAdventure(PlayerCharacter player)
    {
        Console.WriteLine("\nYou enter the Mystic Woods. The air is thick with mystery and anticipation.");
        Console.WriteLine("You come across a fork in the path. Will you go left or right?");

        string pathChoice = Console.ReadLine().ToLower();
        switch (pathChoice)
        {
            case "left":
                ExploreLeftPath(player);
                break;
            case "right":
                ExploreRightPath(player);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                StartAdventure(player); // Restart the adventure
                break;
        }
    }

    static void ExploreLeftPath(PlayerCharacter player)
    {
        Console.WriteLine("\nYou chose the left path. The trees seem to close in around you as you venture deeper.");
        Console.WriteLine("You encounter a trap! What will you do? (attempt to disarm/run)");

        string trapChoice = Console.ReadLine().ToLower();
        if (trapChoice == "attempt to disarm")
        {
            Console.WriteLine("You successfully disarm the trap and continue on your path.");
            Console.WriteLine("You find a hidden passage that leads you to the legendary treasure!");
            Console.WriteLine("Congratulations! You found the treasure and completed your adventure.");
        }
        else if (trapChoice == "run")
        {
            Console.WriteLine("You try to run but trigger the trap, taking damage!");
            player.TakeDamage(20);
            if (player.Health == 0)
            {
                Console.WriteLine("You ran out of health and succumbed to your injuries. Game Over.");
            }
            else
            {
                Console.WriteLine("You managed to escape the trap and continue on your path.");
                Console.WriteLine("After some time, you realize you're lost in the woods and unable to find your way back.");
                Console.WriteLine("You wander aimlessly, never finding the treasure. Game Over.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
            ExploreLeftPath(player); // Restart the left path exploration
        }
    }

    static void ExploreRightPath(PlayerCharacter player)

      // print out intial scene 
    {
        Console.WriteLine("\nYou chose the right path. Sunlight filters through the canopy, casting enchanting patterns on the forest floor.");
        Console.WriteLine("You stumble upon a mysterious old hut. What will you do? (enter/ignore)");

        string hutChoice = Console.ReadLine().ToLower(); // read the players choice 
        if (hutChoice == "enter")
        {
            Console.WriteLine("You cautiously enter the hut and find a map leading to the legendary treasure!");//player decided to enter in hut
            Console.WriteLine("With the map in hand, you navigate through the woods and find the treasure!");
            Console.WriteLine("Congratulations! You found the treasure and completed your adventure.");
        }
        else if (hutChoice == "ignore")
        {
            Console.WriteLine("You decide to ignore the hut and continue on your path.");// player decide to ignore the hut
            Console.WriteLine("After wandering for hours, you find yourself back at the entrance of the Mystic Woods.");
            Console.WriteLine("You realize you've wasted too much time and energy and give up on your quest. Game Over.");
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");//player entered  invalid choice 
            ExploreRightPath(player); // Restart the right path exploration
        }
    }

}



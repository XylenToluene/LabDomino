using System;

namespace LabDomino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            try
            {
                Game game = new Game(); 
                Console.WriteLine("<<ДОМИНО КОЗЕЛ>>");
                Console.WriteLine($"НАЧАЛО ИГРЫ\t Раунд:{Game.Round}");
                while (true) 
                {
                    game.StartGame(); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

}
        

          
            
           
            

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDomino
{
    
    public class Game
    {
        Random random = new Random();
        Player player1 = new Player();
        Player player2 = new Player();
        Compare compare = new Compare();


        public static int Round = 1;
        int Moves = 0;  //ходы в игре
        public static int z2T = 0;  //последний знак кости на столе

        public static string[] AllKosty = { "0|0","0|1","0|2","0|3","0|4","0|5","0|6","1|1","1|2","1|3","1|4","1|5","1|6","2|2",
                     "2|3","2|4","2|5","2|6","3|3","3|4","3|5","3|6","4|4","4|5","4|6","5|5","5|6","6|6"};  //все кости Домино

        public static List<string> Bazar = new List<string>(AllKosty); //базар

        public static List<string> KOnTable = new List<string>(); //кости на столе

        
        /// <summary>
        /// Начало игры
        /// </summary>
        public void StartGame()
        {
            if (Round == 1)
            {
                Console.WriteLine("Игрок 1 напишите имя");
                player1.Name = Console.ReadLine();
                Console.WriteLine("Игрок 2 напишите имя");
                player2.Name = Console.ReadLine();
                ClearPlayer();
                player1.Score = 0;
                player2.Score = 0;

            }
            if(Round > 1)
            {
                Console.WriteLine($"ИГРА ПРОДОЛЖАЕТСЯ\t Раунд: {Round}");
                Console.WriteLine($"Игрок {player1.Name} набрал {player1.Score} очков" +
                    $"\tИгрок {player2.Name} набрал {player2.Score} очков");
                ClearPlayer();
            }
            GetSevenK(player1);
            GetSevenK(player2);
            CheckFirstTurn();

        }

        public void ClearPlayer()
        {
            Moves = 0;
            Bazar.Clear();
            KOnTable.Clear();
            Bazar = new List<string>(AllKosty);
            player1.KInHand.Clear();
            player2.KInHand.Clear();
        }

        /// <summary>
        /// раздает по 7 костей в начале игры
        /// </summary>
        /// <param name="playerhand"></param>
        public void GetSevenK(Player player)
        {
            int k;

            for(int i = 0; i < 7; i++)
            {
                while(true)
                {
                    k = random.Next(AllKosty.Length);

                    if(AllKosty[k] != null)
                    {
                        player.KInHand.Add(AllKosty[k]);
                        Bazar.Remove(AllKosty[k]);
                        AllKosty[k] = null;
                        break;
                    }
                }
            }
        } 

        /// <summary>
        /// Выбирает, кто из игроков будет ходить первым
        /// </summary>
        public void CheckFirstTurn()
        {
            string[] s = {"0|0", "1|1", "2|2", "3|3","4|4","5|5","6|6"};
            for (int i = 0; i < s.Length; i++)
            {
                if (player1.KInHand.Contains(s[i]))
                {
                    Console.WriteLine($"Ход игрока:\t <<{player1.Name}>>");
                    player1.Moves += 1;
                    SelectK(player1);
                    
                }
                else if(player2.KInHand.Contains(s[i]))
                {
                    Console.WriteLine($"Ход игрока:\t <<{player2.Name}>>");
                    player2.Moves += 1;
                    SelectK(player2);
                }
            }
        }

        /// <summary>
        /// Игрок выбирает кость для хода
        /// </summary>
        /// <param name="k"></param>
        public void SelectK(Player player)
        {
            if (Moves == 0)
            {
                Turn(player);
                Moves++;
                SelectPlayerTurn();
            }
            else
            {
                ShowKOnTable();
                Console.WriteLine("\n");
                GetPlayersKOnTAble(player);
                PlaceKOnTable(player);
            }
        }

        /// <summary>
        /// Обьявление ходов 
        /// </summary>
        public void SelectPlayerTurn()
        {
            if(player1.Moves < player2.Moves)
            {
                Console.WriteLine($"Ход игрока:\t <<{player1.Name}>>");
                player1.Moves += 1;
                SelectK(player1);
            }
            if(player2.Moves < player1.Moves)
            {
                Console.WriteLine($"Ход игрока:\t <<{player2.Name}>>");
                player2.Moves += 1;
                SelectK(player2);
            }
        }

        /// <summary>
        /// Первый ход игрока
        /// </summary>
        /// <param name="plHand"></param>
        public void Turn(Player player)
        {
            GetPlayersKOnTAble(player);
            int selectedK = int.Parse(Console.ReadLine());
            KOnTable.Add(player.KInHand[selectedK]);
            player.KInHand.Remove(player.KInHand[selectedK]);
        }

        /// <summary>
        /// Ставит кость игрока на стол
        /// </summary>
        /// <param name="player"></param>
        public void PlacePlayerKOntable(Player player)
        {
            if (player.KInHand == null)
            {
                Console.WriteLine($"<<РАУНД ЗАКОНЧЕН>> Игрок {player} избавился от всех костей");
                Console.WriteLine("Начать новый раунд?\n<ДА> - 1\n<НЕТ> - 0");
                StartOrNot(int.Parse(Console.ReadLine()));
            }
            KOnTable.Add(player.KInHand[player.SelectedK]);
            player.KInHand.Remove(player.KInHand[player.SelectedK]);

            
        }

        /// <summary>
        /// Вывод костей игрока на консоль
        /// </summary>
        /// <param name="plHand"></param>
        public void GetPlayersKOnTAble(Player player)
        {
            for (int i = 0; i < player.KInHand.Count; i++)
            {
                Console.WriteLine($"{i}. [{player.KInHand[i]}]");
            }
            Console.WriteLine($"Выберите кость (напишите цифру от 0 до {player.KInHand.Count - 1})");
        }
        
        /// <summary>
        /// Выводит кости на столе
        /// </summary>
        public void ShowKOnTable()
        {
            Console.WriteLine("Стол:");

            for (int i = 0; i < KOnTable.Count; i++)
            {
                Console.Write($"[{KOnTable[i]}] ");
            }
        }

        /// <summary>
        /// Добавляет кость или предупреждает о невозможности хода
        /// </summary>
        /// <param name="plHand"></param>
        /// <returns></returns>
        public void PlaceKOnTable(Player player)
        {
            compare.Convert(player, int.Parse(Console.ReadLine()));

            switch (compare.CompareSigns(player))
            {
                case 1:    //Совпадение найдено, переворачивать кость не надо
                    {
                        PlacePlayerKOntable(player);
                        player.Moves += 1;
                        SelectPlayerTurn();
                    }
                    break;
                case 2:    //Совпадение найдено, но нужно перевернуть кость
                    {
                        RotateK(player);
                        PlacePlayerKOntable(player);
                        player.Moves += 1;
                        SelectPlayerTurn();
                    }
                    break;
                case 0:    //совпадений нет
                    {
                        Console.WriteLine("=====\nНевозможно поставить кость\n=====");
                        player.Moves -= 1;
                        Console.WriteLine("Хотите взять кость из Базара?\n<ДА> - 1\n<НЕТ> - 0");
                        GetKFromBazar(player,int.Parse(Console.ReadLine()));
                        SelectPlayerTurn();
                    }
                    break;
            }
        }

        /// <summary>
        /// Переворачивает коcть
        /// </summary>
        public void RotateK(Player player)
        {
            string s = new string(player.KInHand[player.SelectedK].Reverse().ToArray());
            player.KInHand.Remove(player.KInHand[player.SelectedK]);
            player.KInHand.Add(s);
            player.SelectedK = player.KInHand.Count - 1;
        }


        public bool CheckArrayNull(string[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Берет кость из Базара
        /// </summary>
        /// <param name="player"></param>
        /// <param name="a"></param>
        public void GetKFromBazar(Player player, int a)
        {
            bool checkarr = CheckArrayNull(AllKosty);

            switch (a)
            {
                case 1:
                    {
                        int k;

                        if(Bazar != null && checkarr == true)
                        {
                            k = random.Next(AllKosty.Length);
                           
                                if (AllKosty[k] != null)
                                {
                                    player.KInHand.Add(AllKosty[k]);
                                    Bazar.Remove(AllKosty[k]);
                                    AllKosty[k] = null;
                                    Console.WriteLine("|Вы взяли кость из Базара|");
                                    break;
                                }
                            else
                            {
                                GetKFromBazar(player, 1);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("|В Базаре не осталось костей|");
                            Console.WriteLine("Хотите закончить раунд?\n<ДА> - 1\n<НЕТ> - 0");
                            EndRound(player, int.Parse(Console.ReadLine()));
                            break;
                        }
                    }
                case 0:
                    break;
            }
        }
        
        public void EndRound(Player player, int a)
        {
            switch(a)
            {
                case 1:
                    {
                        compare.CompareEndRoundK(player1);
                        compare.CompareEndRoundK(player2);
                        if(player.Score >= 101)
                        {
                            Console.Clear();
                            Console.WriteLine("<<ИГРА ЗАКОНЧЕНА>>");
                            Console.WriteLine($"Игрок {player.Name} проиграл. Он набрал {player.Score} очков");
                            Console.WriteLine("Начать новую игру?\n<ДА> - 1\n<НЕТ> - 0");
                            StartOrNot(int.Parse(Console.ReadLine()));
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Раунд {Round} закончен");
                            Round++;
                            Console.WriteLine("Начать новый раунд?\n<ДА> - 1\n<НЕТ> - 0");
                            StartOrNot(int.Parse(Console.ReadLine()));
                        }
                        break;
                    }
                    
                case 0:
                    {
                        player.Moves -= 1;
                        SelectPlayerTurn();
                        break;
                    }
                    
            }
        }
        public void StartOrNot(int a)
        {
            if(a == 1)
            {
                Console.Clear();
                 Round = 1;
               
                StartGame();
            }
            if(a == 0)
            {
                Console.WriteLine("До свидания(");
                Console.Clear();
                Round = 1;
                Console.ReadLine();
            }
            else
            {
                throw new Exception("Вы ввели неправильный символ");
            }
        }

    }

}

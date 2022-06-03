using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDomino
{
    /// <summary>
    /// Сравнивает кости игрока с костями на столе
    /// </summary>
    public class Compare
    {
        public int z2T = 0;    //2-ой знак на кости на столе
        int z1P = 0;   //1-ый знак кости игрока
        int z2P = 0;   //2-ой знак кости игрока

        /// <summary>
        /// Конвертирует знаки на кости игрока
        /// </summary>
        /// <param name="plHand">лист с костями игрока</param>
        /// <param name="index">индекс элемента листа</param>
        public void Convert(Player player, int index)
        {
            player.SelectedK = index;
            string[] Signs = player.KInHand[index].Split('|');
            z1P = int.Parse(Signs[0]);
            z2P = int.Parse(Signs[1]);
        }

        /// <summary>
        /// Сравнивает значения знаков на кости, выбранной игроком и кости на столе
        /// </summary>
        /// <param name="z1">знак на кости игрока 1</param>
        /// <param name="z2">знак на кости игрока 2</param>
        /// <param name="plHand">список костей игрока</param>
        /// <param name="index">индекс кости игрока</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int CompareSigns(Player player)
        {
            ConvertKOnTable();

            if(z1P == z2T)
                return 1;
            else if (z2P == z2T)
                return 2;
            else
                return 0;
        }

        /// <summary>
        /// Конвертирует знаки на кости в подходящие для сравнения значения
        /// </summary>
        /// <param name="k"></param>
        public void ConvertKOnTable()
        {
            string[] z = Game.KOnTable[Game.KOnTable.Count - 1].Split('|');
            z2T = int.Parse(z[1]);
        }

        /// <summary>
        /// Считает очки игроков
        /// </summary>
        /// <param name="player"></param>
        public void CompareEndRoundK(Player player)
        {
            string[] pK;

            for(int i = 0; i < player.KInHand.Count; i++)
            {
                pK = player.KInHand[i].Split('|');

                for(int j = 0; j < pK.Length; j++)
                {
                    player.Score += int.Parse(pK[j]);
                }
            }
        }

    }
}

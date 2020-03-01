﻿using System;
using System.Collections.Generic;
using System.Text;

namespace firstPZ
{
    class GameProcess : IGameProcess, IResultGameEvent
    {
        public event Display eDisplay;
        public event ColoredDisplay eColoredDisplay;

        public Dictionary<cardModel, playerModel> getCard(cardModel _cardModel, playerModel _playerModel)
        {
            
            Dictionary<cardModel, playerModel> pairs = new Dictionary<cardModel, playerModel>();
            pairs.Add(_cardModel, _playerModel);
            return pairs;
        }

        public void isLuckyPlayer(Dictionary<cardModel, playerModel> pairs)
        {
            eDisplay = null;
            eColoredDisplay = null;
            foreach (KeyValuePair<cardModel, playerModel> pair in pairs)
            {
                if (pair.Key.luck < pair.Value.cardNum)
                {
                    eDisplay += Display;
                    eDisplay?.Invoke("Lucky one");
                }

                else
                {
                    eColoredDisplay += ColoredDisplay;
                    eColoredDisplay?.Invoke();
                    eDisplay += Display;
                    eDisplay?.Invoke("Unlucky one");
                }

            }
        }

        public void Battle(Dictionary<cardModel, playerModel> players)
        {
            eDisplay = null;
            eColoredDisplay = null;
            foreach (KeyValuePair<cardModel, playerModel> pair in players)
            {
                if (pair.Key.luck * pair.Value.cardNum > 30)
                {
                    eDisplay += Display;
                    eDisplay.Invoke("Win");
                }
                else
                {
                    eDisplay += Display;
                    eColoredDisplay += ColoredAnotherDisplay;
                    eColoredDisplay?.Invoke();
                    eDisplay.Invoke("Lose");
                    eColoredDisplay += ColoredDisplay;
                    eColoredDisplay?.Invoke();
                    eDisplay.Invoke("Such a huge mistake");

                }

            }
        }
        public void Display(string s)
        {
            Console.WriteLine($"{s}");
        }

        public void ColoredDisplay()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public void ColoredAnotherDisplay()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }


    }
}

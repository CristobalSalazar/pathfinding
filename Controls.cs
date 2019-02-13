using System;

namespace Program
{
    static class Controls
    {
        public static string GetInput()
        {
            ConsoleKeyInfo ckinfo = Console.ReadKey(true);
            switch (ckinfo.Key)
            {
                case ConsoleKey.NumPad1:
                    {
                        return "1";
                    }
                case ConsoleKey.D1:
                    {
                        return "1";
                    }
                case ConsoleKey.NumPad2:
                    {
                        return "2";
                    }
                case ConsoleKey.D2:
                    {
                        return "2";
                    }
                case ConsoleKey.NumPad3:
                    {
                        return "3";
                    }
                case ConsoleKey.D3:
                    {
                        return "3";
                    }
                case ConsoleKey.NumPad4:
                    {
                        return "4";
                    }
                case ConsoleKey.D4:
                    {
                        return "4";
                    }
                case ConsoleKey.NumPad5:
                    {
                        return "5";
                    }
                case ConsoleKey.D5:
                    {
                        return "5";
                    }
                case ConsoleKey.NumPad6:
                    {
                        return "6";
                    }
                case ConsoleKey.D6:
                    {
                        return "6";
                    }
                case ConsoleKey.NumPad7:
                    {
                        return "7";
                    }
                case ConsoleKey.D7:
                    {
                        return "7";
                    }
                case ConsoleKey.NumPad8:
                    {
                        return "8";
                    }
                case ConsoleKey.D8:
                    {
                        return "8";
                    }
                case ConsoleKey.NumPad9:
                    {
                        return "9";
                    }
                case ConsoleKey.D9:
                    {
                        return "9";
                    }
                case ConsoleKey.NumPad0:
                    {
                        return "0";
                    }
                case ConsoleKey.D0:
                    {
                        return "0";
                    }
                case ConsoleKey.UpArrow:
                    {
                        return "up";
                    }
                case ConsoleKey.DownArrow:
                    {
                        return "down";
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return "left";
                    }
                case ConsoleKey.RightArrow:
                    {
                        return "right";
                    }
            }
            return GetInput();
        }
    }
}
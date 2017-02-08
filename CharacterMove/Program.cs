using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CharacterMove
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const char toWrite = '*'; // Character to write on-screen.
            const char wall = '#';  //wall character

            int x = 1, y = 1; // Contains current cursor position.

            Write(toWrite, wall); // Write the character on the default location (1,1).

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            y++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (y > 0)
                            {
                                y--;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (x > 0)
                            {
                                x--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            x++;
                            break;
                    }

                    Write(toWrite,wall, x, y);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        //since the x and y have initial values in the declaration here, you can call this method
        //by just passing toWrite and wall
        public static void Write(char toWrite,char wall, int x = 1, int y = 1)
        {
            try
            {
                if (x >= 0 && y >= 0) // 0-based
                {
                    Console.Clear();
                    drawWall(wall);
                    Console.SetCursorPosition(x, y);
                    Console.Write(toWrite);
                    Console.SetCursorPosition(0, 15);
                    Console.Write("Current cursor position is ({0},{1})", x, y);
                }
            }
            catch (Exception)
            {
            }
        }

        //just draws a 20x10 wall using whatever "wall" character is passsed to it
        public static void drawWall(char wall)
        {
            int x = 0;
            int y = 0;
            //Console.Clear();
            for (x = 0; x < 20; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(wall);
            }
            for (y = 0; y < 10; y++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(wall);
            }
            for (x = 19; x > 0; x--)
            {
                y = 9;
                Console.SetCursorPosition(x, y);
                Console.Write(wall);
            }
            for (y = 9; y > 0; y--)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(wall);
            }
        }
    }
}

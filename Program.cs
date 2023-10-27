using static System.Runtime.CompilerServices.RuntimeHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;
using Box_Dungeon_RPG;
using System.Diagnostics;
using System.Numerics;

namespace C_Sharp_Mechanics
{
    class Program
    {
        public static char currentOutput = ' ';
        public static int screenSizeX = 120;
        public static int screenSizeY = 29;
        public static char[,] screen = new char[screenSizeY, screenSizeX];


        private static void ReadKeys()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape)
            {

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.W:
                        currentOutput = 'W';
                        break;
                    case ConsoleKey.S:
                        currentOutput = 'S';
                        break;
                    case ConsoleKey.D:
                        currentOutput = 'D';
                        break;
                    case ConsoleKey.A:
                        currentOutput = 'A';
                        break;
                    case ConsoleKey.D1:
                        currentOutput = '1';
                        break;
                    case ConsoleKey.D2:
                        currentOutput = '2';
                        break;
                    case ConsoleKey.D3:
                        currentOutput = '3';
                        break;
                    case ConsoleKey.D4:
                        currentOutput = '4';
                        break;
                    case ConsoleKey.D5:
                        currentOutput = '5';
                        break;
                    case ConsoleKey.D6:
                        currentOutput = '6';
                        break;
                    case ConsoleKey.D7:
                        currentOutput = '7';
                        break;
                    case ConsoleKey.D8:
                        currentOutput = '8';
                        break;
                    case ConsoleKey.D9:
                        currentOutput = '9';
                        break;
                    case ConsoleKey.D0:
                        currentOutput = '0';
                        break;
                    case ConsoleKey.Escape:
                        currentOutput = '!';
                        break;
                    default:
                        //Console.WriteLine(key.KeyChar);
                        currentOutput = ' ';
                        break;
                }
            }
        }

        private static void taskInput(Entity player)
        {
            Console.SetCursorPosition(1, 29);
            player.Name = Console.ReadLine();
        }
        static void resetScreen()
        {
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    screen[i, j] = ' ';
                }
            }
        }
        static void createBox(char character, int width, int height, int offsetX, int offsetY) {
            int boxHeight = (offsetY + height);
            int boxWidth = (offsetX + width);
            if (offsetX < 0)
            {
                offsetX = 0;
            }
            if (offsetY < 0)
            {
                offsetY = 0;
            }
            if (boxHeight > screenSizeY)
            {
                boxHeight = screenSizeY - 1;
            }
            if (boxWidth > screenSizeX)
            {
                boxWidth = screenSizeX - 1;
            }
            if (offsetY > screenSizeY)
            {
                offsetY = screenSizeY - 1;
            }
            if (offsetX > screenSizeX)
            {
                offsetX = screenSizeX - 1;
            }
            if (boxHeight < screenSizeY && boxWidth < screenSizeX && offsetX > 0 && offsetY > 0)
            {
                for (int i = offsetY; i < boxHeight; i++)
                {
                    for (int j = offsetX; j < boxWidth; j++)
                    {
                        if (i == offsetY)
                        {
                            screen[i, j] = character;
                        }
                        if (i > offsetY && i < boxHeight && (j == offsetX || j == boxWidth - 1))
                        {
                            screen[i, j] = character;
                        }
                        if (i == boxHeight - 1)
                        {
                            screen[i, j] = character;
                        }
                    }
                }
            }
            
        }
        static void createLine(char character, int length, int offsetX, int offsetY, string direction)
        {
            int lineUpCap = (offsetY - length);
            int lineDownCap = (offsetY + length);
            int lineLeftCap = (offsetX - length);
            int lineRightCap = (offsetX + length);

            if (offsetX < 0)
            {
                offsetX = 0;
            }
            if (offsetY < 0)
            {
                offsetY = 0;
            }

            if (direction == "Up")
            {
                if (lineUpCap < screenSizeY)
                {
                    lineUpCap = 0;
                }
                for (int i = offsetX; i > lineUpCap; i--)
                {
                    screen[i, offsetY] = character;
                }
            }
            if (direction == "Down")
            {
                if (lineDownCap >= screenSizeY)
                {
                    lineDownCap = screenSizeY;
                }
                for (int i = offsetX; i < lineDownCap; i++)
                {
                    screen[i, offsetY] = character;
                }
            }
            if (direction == "Left")
            {
                if (lineLeftCap < screenSizeX)
                {
                    lineLeftCap = 0;
                }
                for (int i = offsetY; i > lineLeftCap; i--)
                {
                    screen[offsetX, i] = character;
                }
            }
            if (direction == "Right")
            {
                if (lineRightCap >= screenSizeX)
                {
                    lineRightCap = screenSizeX;
                }
                for (int i = offsetY; i < lineRightCap; i++)
                {
                    screen[offsetX, i] = character;
                }
            }

        }
        static void createString(string text, int offsetY, int offsetX)
        {
            
            Char[] textCharArray = text.ToCharArray();
            int j = 0;

            for (int i = offsetX; i < ((textCharArray.Length) + offsetX); i++)
            {
                /*
                if(j < textCharArray.Length)
                {
                    screen[offsetX, i] = textCharArray[j];
                    j++;
                }
                */
                screen[offsetY, i] = textCharArray[j];
                j++;
            }

        }

        static void createGameOutline()
        {
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        screen[i, j] = '-';
                    }
                    if (i > 0 && i < screen.GetLength(0) && (j == 0 || j == screen.GetLength(1) - 1))
                    {
                        screen[i, j] = '-';
                    }
                    if (i == screen.GetLength(0) - 1)
                    {
                        screen[i, j] = '-';
                    }
                    if (i == 1)
                    {
                        createString("Box Dungeon RPG", i, 50);
                    }
                }
            }
        }
        static void mainMenu()
        {
            string menuLine = "";
            Char[] menuLineChar;
            int menu_Print_Increment = 0;
            int menu_Print_Offset = 0;


            while (true)
            {
                
                
                if (currentOutput == '!')
                {
                    Environment.Exit(0);
                }
                if (currentOutput == '1')
                {
                    return;
                }
                if (currentOutput == '2')
                {
                    Environment.Exit(0);
                }

                for (int i = 0; i < screen.GetLength(0); i++)
                {
                    for (int j = 0; j < screen.GetLength(1); j++)
                    {
                        if (i == 0)
                        {
                            screen[i, j] = '-';
                        }
                        if (i > 0 && i < screen.GetLength(0) && (j == 0 || j == screen.GetLength(1) - 1))
                        {
                            screen[i, j] = '-';
                        }
                        if (i == screen.GetLength(0) - 1)
                        {
                            screen[i, j] = '-';
                        }
                        if (i == 1)
                        {
                            createString("Box Dungeon RPG", i, 50);
                        }
                        if (i == screen.GetLength(0) - 4)
                        {
                            menuLine = " Choose An Option";
                            menuLineChar = menuLine.ToCharArray();
                            menu_Print_Offset = 0;
                            if (j > menu_Print_Offset && j <= menuLineChar.Length + menu_Print_Offset)
                            {
                                if (menu_Print_Increment < menuLineChar.Length)
                                {
                                    screen[i, j] = menuLineChar[menu_Print_Increment];
                                }

                                menu_Print_Increment++;
                                if (menu_Print_Increment == menuLineChar.Length)
                                {
                                    menu_Print_Increment = 0;
                                }
                            }
                        }
                        if (i == screen.GetLength(0) - 3)
                        {
                            menuLine = " 1. Start Your Adventure";
                            menuLineChar = menuLine.ToCharArray();
                            menu_Print_Offset = 0;
                            if (j > menu_Print_Offset && j <= menuLineChar.Length + menu_Print_Offset)
                            {
                                if (menu_Print_Increment < menuLineChar.Length)
                                {
                                    screen[i, j] = menuLineChar[menu_Print_Increment];
                                }

                                menu_Print_Increment++;
                                if (menu_Print_Increment == menuLineChar.Length)
                                {
                                    menu_Print_Increment = 0;
                                }
                            }
                        }
                        if (i == screen.GetLength(0) - 2)
                        {
                            menuLine = " 2. Exit";
                            menuLineChar = menuLine.ToCharArray();
                            menu_Print_Offset = 0;
                            if (j > menu_Print_Offset && j <= menuLineChar.Length + menu_Print_Offset)
                            {
                                if (menu_Print_Increment < menuLineChar.Length)
                                {
                                    screen[i, j] = menuLineChar[menu_Print_Increment];
                                }

                                menu_Print_Increment++;
                                if (menu_Print_Increment == menuLineChar.Length)
                                {
                                    menu_Print_Increment = 0;
                                }
                            }
                        }


                    }

                }


                for (int i = 0; i < screen.GetLength(0); i++)
                {
                    for (int j = 0; j < screen.GetLength(1); j++)
                    {
                        Console.Write(screen[i, j]);
                        
                    }
                    Console.Write("\n");

                }
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 0);
            }


        }
        static void characterCreator(Entity player)
        {
            //menu Setup
            int characterCreatorState = 0;
            int characterCreatorStateStats = 0;
            currentOutput = ' ';
            resetScreen();
            createGameOutline();
            
            while (true)
            {
                
                if (currentOutput == '!')
                {
                    Environment.Exit(0);
                }

                //setup state
                if (characterCreatorState == 0)
                {
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(0, 0);
                    resetScreen();
                    createGameOutline();
                    createBox('*', 80, 10, 1, 3);
                    for (int i = 0; i < screen.GetLength(0); i++)
                    {
                        if (i == 4) { createString(" Character Name:" + player.Name.ToString(), i, 2); }
                        if (i == 6) { createLine('-', 60, 6, 3, "Right"); }
                        if (i == 7) { createString(" Character Stats:", i, 2); }
                        
                        if (i == 8)
                        {
                            createString("Health: " + player.Health.ToString() + "  Mana: " + player.Mana.ToString() + "  Stamina: " + player.Stamina.ToString(), i, 3);
                        }
                        if (i == 9)
                        {
                            createString("Strength: " + player.stats["Strength"].ToString() + "  Dexerity: " + player.stats["Dexerity"].ToString() + " Constitution: " + player.stats["Constitution"].ToString() + 
                            " Intelligence: " + player.stats["Intelligence"].ToString() + " Speed: " + player.stats["Speed"].ToString(), i, 3);
                        }
                        if (i == 10)
                        {
                            createString("Attack: " + player.Attack.ToString() + "   Defense: " + player.Defense.ToString(), i , 3);
                        }
                        if (i == (screen.GetLength(0) - 5)){
                            createString(" Create Your Character:", i, 2);
                        }
                        if (i == (screen.GetLength(0) - 4))
                        {
                            createString(" 1. Choose Character Name", i, 1);
                        }
                        if (i == (screen.GetLength(0) - 3))
                        {
                            createString(" 2. Edit Character Stats", i, 1);
                        }
                        if (i == (screen.GetLength(0) - 2))
                        {
                            createString(" 3. Exit", i, 1);
                        }
                    }
                    if(currentOutput == '1')
                    {
                        currentOutput = ' ';
                        characterCreatorState = 1;
                    }
                    if (currentOutput == '2')
                    {
                        currentOutput = ' ';
                        characterCreatorState = 2;
                    }
                    if (currentOutput == '3')
                    {
                        Environment.Exit(0);
                    }

                }

                //choose name
                if (characterCreatorState == 1)
                {
                    
                    resetScreen();
                    createGameOutline();
                    createBox('*', 80, 10, 1, 3);
                    for (int i = 0; i < screen.GetLength(0); i++)
                    {
                        if (i == 4) { createString(" Character Name:" + player.Name.ToString(), i, 2); }
                        if (i == 6) { createLine('-', 60, 6, 3, "Right"); }
                        if (i == 7) { createString(" Character Stats:", i, 2); }

                        if (i == 8)
                        {
                            createString("Health: " + player.Health.ToString() + "  Mana: " + player.Mana.ToString() + "  Stamina: " + player.Stamina.ToString(), i, 3);
                        }
                        if (i == 9)
                        {
                            createString("Strength: " + player.stats["Strength"].ToString() + "  Dexerity: " + player.stats["Dexerity"].ToString() + " Constitution: " + player.stats["Constitution"].ToString() +
                            " Intelligence: " + player.stats["Intelligence"].ToString() + " Speed: " + player.stats["Speed"].ToString(), i, 3);
                        }
                        if (i == 10)
                        {
                            createString("Attack: " + player.Attack.ToString() + "   Defense: " + player.Defense.ToString(), i, 3);
                        }
                        if (i == (screen.GetLength(0) - 4))
                        {
                            createString(" Create Your Character:", i, 2);
                        }
                    }
                    //currentOutput = ' ';
                    Console.CursorVisible = true;
                    Thread inputThread = new Thread(() => taskInput(player));
                    inputThread.Start();
                    inputThread.Join();
                    //Task.WaitAll(tasks);
                    characterCreatorState = 0;
                }
                if (characterCreatorState == 2)
                {
                    resetScreen();
                    createGameOutline();
                    createBox('*', 80, 10, 1, 3);

                    /////////////////////////////////working on this
                    characterCreatorStateStats = 0 ;
                    for (int i = 0; i < screen.GetLength(0); i++)
                    {
                        if (i == 4) { createString(" Character Name:" + player.Name.ToString(), i, 2); }
                        if (i == 6) { createLine('-', 60, 6, 3, "Right"); }
                        if (i == 7) { createString(" Character Stats:", i, 2); }

                        if (i == 8)
                        {
                            createString("Health: " + player.Health.ToString() + "  Mana: " + player.Mana.ToString() + "  Stamina: " + player.Stamina.ToString(), i, 3);
                        }
                        if (i == 9)
                        {
                            createString("Strength: " + player.stats["Strength"].ToString() + "  Dexerity: " + player.stats["Dexerity"].ToString() + " Constitution: " + player.stats["Constitution"].ToString() +
                            " Intelligence: " + player.stats["Intelligence"].ToString() + " Speed: " + player.stats["Speed"].ToString(), i, 3);
                        }
                        if (i == 10)
                        {
                            createString("Attack: " + player.Attack.ToString() + "   Defense: " + player.Defense.ToString(), i, 3);
                        }
                        if (i == (screen.GetLength(0) - 8))
                        {
                            createString(" Choose A Stat to Edit:", i, 2);
                        }
                        if (i == (screen.GetLength(0) - 7))
                        {
                            createString(" 1. Strength: ", i, 1);
                        }
                        if (i == (screen.GetLength(0) - 6))
                        {
                            createString(" 2. Dexerity: ", i, 1);
                        }
                        if (i == (screen.GetLength(0) - 5))
                        {
                            createString(" 3. Constitution: ", i, 1);
                        }
                        if (i == (screen.GetLength(0) - 4))
                        {
                            createString(" 4. Intelligence: ", i, 1);
                        }
                        if (i == (screen.GetLength(0) - 3))
                        {
                            createString(" 5. Speed: ", i, 1);
                        }
                        if (i == (screen.GetLength(0) - 2))
                        {
                            createString(" 6. Return to Character Creation", i, 1);
                        }
                    }
                    if (currentOutput == '1')
                    {
                        
                        resetScreen();
                        createGameOutline();
                        createBox('*', 80, 10, 1, 3);
                        for (int i = 0; i < screen.GetLength(0); i++)
                        {
                            if (i == 4) { createString(" Character Name:" + player.Name.ToString(), i, 2); }
                            if (i == 6) { createLine('-', 60, 6, 3, "Right"); }
                            if (i == 7) { createString(" Character Stats:", i, 2); }

                            if (i == 8)
                            {
                                createString("Health: " + player.Health.ToString() + "  Mana: " + player.Mana.ToString() + "  Stamina: " + player.Stamina.ToString(), i, 3);
                            }
                            if (i == 9)
                            {
                                createString("Strength: " + player.stats["Strength"].ToString() + "  Dexerity: " + player.stats["Dexerity"].ToString() + " Constitution: " + player.stats["Constitution"].ToString() +
                                " Intelligence: " + player.stats["Intelligence"].ToString() + " Speed: " + player.stats["Speed"].ToString(), i, 3);
                            }
                            if (i == 10)
                            {
                                createString("Attack: " + player.Attack.ToString() + "   Defense: " + player.Defense.ToString(), i, 3);
                            }
                            if (i == (screen.GetLength(0) - 6))
                            {
                                createString(" Choose A Stat to Edit:", i, 2);
                            }
                            if (i == (screen.GetLength(0) - 5))
                            {
                                createString(" Total Stats Left: " + player.availableStats, i, 2);
                            }
                            if (i == (screen.GetLength(0) - 4))
                            {
                                createString(" 1. Increase Strength By 1:   3. Decrease Strength By 1: ", i, 1);
                            }
                            if (i == (screen.GetLength(0) - 3))
                            {
                                createString(" 2. Increase Strength By 5:   4. Decrease Strength By 5: ", i, 1);
                            }
                            if (i == (screen.GetLength(0) - 2))
                            {
                                createString(" 6. Return to Stats Menu", i, 1);
                            }
                        }
                    }
                    if (currentOutput == '2')
                    {
                        currentOutput = ' ';
                    }
                    if (currentOutput == '3')
                    {
                        currentOutput = ' ';
                    }
                    if (currentOutput == '4')
                    {
                        currentOutput = ' ';
                    }
                    if (currentOutput == '5')
                    {
                        currentOutput = ' ';
                    }
                    if (currentOutput == '6')
                    {
                        currentOutput = ' ';
                        characterCreatorState = 0;
                    }
                }







                    for (int i = 0; i < screen.GetLength(0); i++)
                {
                    for (int j = 0; j < screen.GetLength(1); j++)
                    {
                        Console.Write(screen[i, j]);

                    }
                    Console.Write("\n");

                }
                //Thread.Sleep(100);
                Console.SetCursorPosition(0, 0);
            }
        }
        static void gameScreen()    
        {
            //starting player location
            char player = 'P';
            int playerPosX = 60;
            int playerPosY = 7;

            int prevPlayerPosX = 60;
            int prevPlayerPosY = 7;

            char prevPlayerChar = ' ';

            int movementUpdate = 0;

            screen[playerPosY, playerPosX] = player;

            while (true)
            {
                //threads
                var taskKeys = new Task(ReadKeys);
                taskKeys.Start();
                var tasks = new[] { taskKeys };
                //Task.WaitAll(tasks);

                if (currentOutput == 'W')
                {
                    currentOutput = ' ';
                    if (playerPosY > 0)
                    {
                        prevPlayerPosY = playerPosY;
                        prevPlayerPosX = playerPosX;
                        playerPosY = playerPosY - 1;
                        movementUpdate = 1;
                    }
                }
                if (currentOutput == 'S')
                {
                    currentOutput = ' ';
                    if (playerPosY < screenSizeY - 1)
                    {
                        prevPlayerPosY = playerPosY;
                        prevPlayerPosX = playerPosX;
                        playerPosY = playerPosY + 1;
                        movementUpdate = 1;
                    }
                }
                if (currentOutput == 'A')
                {
                    currentOutput = ' ';
                    if (playerPosX > 0)
                    {
                        prevPlayerPosY = playerPosY;
                        prevPlayerPosX = playerPosX;
                        playerPosX = playerPosX - 1;
                        movementUpdate = 1;
                    }
                }
                if (currentOutput == 'D')
                {
                    currentOutput = ' ';
                    if (playerPosX < screenSizeX - 1)
                    {
                        prevPlayerPosY = playerPosY;
                        prevPlayerPosX = playerPosX;
                        playerPosX = playerPosX + 1;
                        movementUpdate = 1;
                    }
                }
                if (currentOutput == '!')
                {
                    //return;
                    Environment.Exit(0);
                    //Application.Exit(0);
                    //break;
                }
                //update player position
                screen[playerPosY, playerPosX] = player;
                if (movementUpdate == 1)
                {
                    screen[prevPlayerPosY, prevPlayerPosX] = prevPlayerChar;
                    movementUpdate = 0;
                }



                //Console.WriteLine(screen[playerPosY, playerPosX]);
                //Console.WriteLine(screen[prevPlayerPosY, prevPlayerPosX]);

                //Console.WriteLine(playerPosY);

                //print screen
                for (int i = 0; i < screen.GetLength(0); i++)
                {
                    for (int j = 0; j < screen.GetLength(1); j++)
                    {
                        Console.Write(screen[i, j]);
                        //Thread.Sleep(200);
                    }
                    Console.Write("\n");

                }
                Thread.Sleep(100);
                //Console.Clear();
                Console.SetCursorPosition(0, 0);

                //counter++;

            }

        }
        static void Main(string[] args)
        {

            //Setup Console
            //Process.Start("tput", "civis -- invisible");
            Console.CursorVisible = false;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.SetWindowSize(121, 30);

            resetScreen();
            //int counter = 0;
            int state = 0;
            
            //create player entity
            Entity player = new Entity("", 100, 100, 100);

            


            //states
            while (true)
            {
                var taskKeys = new Task(ReadKeys);
                taskKeys.Start();
                var tasks = new[] { taskKeys };
                //Task.WaitAll(tasks);


                //main menu
                if (state == 0)
                {
                    mainMenu();
                    state = 1;
                }
                //character creator
                if (state == 1)
                {
                    resetScreen();
                    characterCreator(player);
                    state = 2;
                }
                //game screen
                if (state == 2)
                {
                    return;
                    //gameScreen();
                }
            }

        }
    }
}
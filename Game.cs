using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Player
    {
        public int health;
        public float speed;
        public bool datDood;
        public string playerName;
        public int level;
        public int item;
        public int damage;
    }

    struct Item
    {
        public string name;
        public int durability;
    }
    class Game
    {

        bool _gameOver = false;
        //Player 1 Stats
        Player player1;
        string player1Name = "Player 1";
        int player1Health = 100;
        int player1Damage = 20;
        int player1Defense = 5;
        int levelScaleMax = 5;
        //Player 2 Stats
        Player player2;
        string player2Name = "Player 2";
        int player2Health = 100;
        int player2Damage = 20;
        int player2Defense = 5;
        int levelScaleMax2 = 5;



        public void Run()
        {
            Start();
            while (_gameOver == false) ;
            {
                Update();
            }
            End();
        }
        public void Start()
        {
            SelectCharacter();
            BeginMultiplayerBattle();

        }

        public void Update()
        {
            

        }

        public void End()
        {
            if (player1Health <= 0)
            {
                Console.WriteLine("Player 2 Wins");
                return;
            }
            //Print game over message
            Console.WriteLine("Player 1 Wins");
        }
        void SelectCharacter()
        {
            //Player 1 selects ITEM
            char input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {
                Console.WriteLine("Player 1, select your ITEM.");
                Console.WriteLine("[1]Sword");
                Console.WriteLine("[2]Gun");
                Console.WriteLine("[2]None (Hands)");
                Console.WriteLine("> ");
                input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        {
                            Console.WriteLine("Sword");
                         int damage = 30;
                            break;
                        }
                    case '2':
                        {
                            Console.WriteLine("Item = Gun");
                            int damage = 50;
                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine("Item = None(Hands");
                            int damage = 10;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Aye. Pick an ITEM NOW!!!");
                            Console.Write("> ");
                            Console.ReadKey();
                            break;
                        }
                }
                Console.Clear();

                //Player 2 selects ITEM
                Console.WriteLine("Player 2, select your ITEM.");
                Console.WriteLine("[1]Sword");
                Console.WriteLine("[2]Gun");
                Console.WriteLine("[2]None (Hands)");
                Console.WriteLine("> ");
                input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        {
                            Console.WriteLine("Sword");
                            int damage = 30;
                            break;
                        }
                    case '2':
                        {
                            Console.WriteLine("Item = Gun");
                            int damage = 50;
                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine("Item = None(Hands");
                            int damage = 10;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Aye. Pick an ITEM NOW!!!");
                            Console.Write("> ");
                            Console.ReadKey();
                            break;
                        }

                }



            }
           

            

            void PrintStats(Player player1)
            {
                Console.WriteLine("\n" + player1Name);
                Console.WriteLine("Health: " + player1Health);
                Console.WriteLine("Damage: " + player1Damage);
            }
        }
        void BeginMultiplayerBattle()
        {
            //Fight Time
            while (player1Health > 0 && player2Health > 0)
            {
                void BlockAttack(ref int player1Health, int attackVal, int player2Defense)
                {
                    int damage = attackVal - player1Defense;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    player1Health -= damage;
                }

                void GetInput(out char input, string option1, string option2, string query)
                {
                    Console.WriteLine(query);
                    //Initialize input
                    input = ' ';
                    //Loop until the player enters a valid input
                    while (input != '1' && input != '2')
                    {
                        Console.WriteLine("1." + option1);
                        Console.WriteLine("2." + option2);
                        Console.Write("> ");
                        input = Console.ReadKey().KeyChar;
                    }

                }

                char input = ' ';
                GetInput(out input, "Attack", "Defend", "Player one turn");
                if (input == '1')
                {
                    BlockAttack(ref player2Health, player1Damage, player2Defense);
                    Console.WriteLine("You dealt " + (player1Damage - player2Defense) + "damage.");
                    Console.WriteLine("> ");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    player2Health -= player1Damage;
                    Console.WriteLine("You dealt " + (player1Damage - player2Defense) + "damage.");
                    Console.WriteLine("> ");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.Clear();
                if (player2Health <= 0)
                {
                    break;
                }
                GetInput(out input, "Attack", "Defend", "Player two turn");
                if (input == '2')
                {
                    BlockAttack(ref player1Health, player2Damage, player1Defense);
                    Console.Clear();
                    Console.WriteLine("You dealt " + (player2Damage - player1Defense) + " damage.");
                    Console.Write("> ");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    BlockAttack(ref player2Health, player1Damage, player2Defense);
                    Console.WriteLine(player2Name + " dealt " + (player2Damage - player2Defense) + " damage.");
                    Console.Write("> ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            _gameOver = true;
        }
        void InitializeCharacters()
        {
            player1Name = "Player1";
            player1Defense = 10;
            player1Health = 100;
            player2Name = "Player2";
            player2Defense = 10;
            player2Health = 100;
        }

    }
}

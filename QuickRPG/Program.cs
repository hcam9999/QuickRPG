//This very simple silly RPG was created to demonstrate using interface and OOP.
//For  the purpose of simplifying things,
//everything will be consolidated to one page
//Created by Hien Cam based on the very popular Diablo3.

using System;

namespace QuickRPG
{
    internal class Program
    {
        //Player class
        class Player
        {
            //ecapsulation, protect data from being changed
            private int _health = 100; 
            public string title;
            public string name;

            public int health
                {
                    
                    get { return _health; }

                    set { 
                          if (value <= 0)           //cath negative health number
                            _health = 0;            
                          else if (value >= 100)    //catch health > 100
                             _health = 100;         
                          else
                             _health = value; 
                        }
                }

            public Player (string _title, string _name)
            {
                title = _title;
                name = _name;
            }

            public void Greeting ()
            {
                Console.WriteLine("Greetings player!\n You are " + title + " " + name +".");
                Console.WriteLine ("Your health is at " + health + ".");
            }
            public void Damage (int _damage)
            {
                health -= _damage;
                {
                    Console.WriteLine("Ouch! You were damaged for some odd reason, - " + _damage + ".Health: " + health + ".");
                }
                
            }

            public void Heal (int addHealth)
            {
                health += addHealth;
                Console.WriteLine("You've been healed: + " + addHealth + ". Your health is at " + health +".");
            }
           
        }
        //Interface: We can only inherit from one base class but we can implement from several interfaces.
        interface IEquip
        {
            void equipped ();
        }

        interface ITradeIn
        {
            void tradein(int _coin);
        }

        interface IMelee
        {
            void melee();
        }

        interface ICastSpells
        {
            void castspells();
        }
        //Weapon class
        class Weapon : IEquip
        {
            public string name;
            public int goldValue;


            public Weapon(string _name, int _goldvalue)
            {
                name = _name;
                goldValue = _goldvalue;
            }
            public void equipped()
            {
                Console.WriteLine("You equipped the " + name);
            }

            public void print()
            {
                Console.WriteLine("You picked up a " + name + ". It's worth " + goldValue + " coins.");
            }
        }

        class Staff : Weapon , ICastSpells, IMelee          //derived from Weapon class, implementing ICastSpells interface
        {
            public Staff(string _name, int _goldvalue) : base(_name, _goldvalue)
            {
                goldValue = _goldvalue;
                name = _name;
            }

           
            public void castspells( )                       //Staff cast spells but Sword doesn't -- implemented only in Staff class
            {
                Console.WriteLine(name + " can turn enemies into chickens!");
            }
            public void melee()
            {
                Console.WriteLine(name + " can do 3 physical damage!");
            }
        }

        class Sword : Weapon, IMelee
        {
            public Sword(string _name, int _goldvalue) : base(_name, _goldvalue)
            {
                goldValue = _goldvalue;
                name = _name;
            }

            public void melee()                         // polymorphism -- Sword class implementing IMelee but different than in Staff class
            {
                Console.WriteLine( name + " can do 10 physical damage!");
            }
        }

            static void Main(string[] args)
        {
            
            Player one = new Player("Princess", "Tutu");
            Staff longstaff = new Staff("Chicken Wand", 30);
            Sword exc = new Sword("Excelle", 28);

            one.Greeting();
            Console.Write("Would you like to continue? (enter Y for yes and any other key will exit the program) ");
            char ans = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (ans == 'y' || ans == 'Y')
            {
                Console.WriteLine("You walked a while and found an item");
                longstaff.print(); //inherit from Weapon class
                longstaff.castspells();
                longstaff.melee();
                Console.Write("Would you like to equip! E will equip, anything else will end the game! ");
                char ans2 = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (ans2 == 'E' || ans2 == 'e') 
                {
                    longstaff.equipped();
                    Console.WriteLine("You encountered a monster!");
                    one.Damage(10);
                    Console.WriteLine("Don't worry, you've got a potion!");
                    Console.Write("Would you like to use potion! Hit P to use potion! ");
                    char ans3 = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if (ans3 == 'P' || ans2 == 'p')
                    {
                        one.Heal(10);
                    }
                    else
                    {
                        Console.WriteLine("Found another weapon!");
                        exc.print(); //inherit from Weapon class
                        exc.melee();
                        Console.Write("You're tired. Hit any key to exit. ");
                        char ans4 = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (ans4 == 'y')
                        {
                            Console.WriteLine("Bye!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Bye!");
                            return;
                        }
                    }
                }
                else return;

                
            }
            else return;
            
                

            
            
            

            
           

            

        }
    }
}

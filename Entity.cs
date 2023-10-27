using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Box_Dungeon_RPG
{
    class Entity
    {
        private static int counter = 0;
        public int Id { get; set; }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Stamina { get; set; }
        public int Attack {  get; set; }
        public int Defense { get; set; }
        public int availableStats { get; set; }


        public Hashtable stats;

        

        public Entity()
        {
            this.Name = "";
            this.Health = 0;
            this.Mana = 0;
            this.Stamina = 0;
            this.Attack = 0;
            this.Defense = 0;
            this.availableStats = 35;

            this.stats = new Hashtable();
            this.stats.Add("Strength", 0);
            this.stats.Add("Dexerity", 0);
            this.stats.Add("Constitution", 0);
            this.stats.Add("Intelligence", 0);
            this.stats.Add("Speed", 0);

            calcHealth();
            calcMana();
            calcStamina();
            calcAttack();
            calcDefense();

            counter++;
            this.Id = counter;
        }
        public Entity(string entityName, int entityHealth, int entityMana, int entityStamina)
        { 
            
            this.Name = entityName;
            this.Health = entityHealth;
            this.Mana = entityMana;
            this.Stamina = entityStamina;
            this.Attack = 0;
            this.Defense = 0;
            this.availableStats = 35;

            this.stats = new Hashtable();
            this.stats.Add("Strength", 5);
            this.stats.Add("Dexerity", 5);
            this.stats.Add("Constitution", 5);
            this.stats.Add("Intelligence", 5);
            this.stats.Add("Speed", 5);

            calcHealth();
            calcMana();
            calcStamina();
            calcAttack();
            calcDefense();

            counter++;
            this.Id = counter;
        }

        public void calcHealth()
        {
            int str_HP = (int)this.stats["Strength"];
            int con_HP = (int)this.stats["Constitution"];
            this.Health = (str_HP*5) + (con_HP*10) + Health;
        }
        public void calcMana()
        {
            int intl_MP = (int)this.stats["Intelligence"];
            int con_MP = (int)this.stats["Constitution"];
            this.Mana = (intl_MP * 10) + (con_MP * 5) + this.Mana;
        }
        public void calcStamina()
        {
            int str_SP = (int)this.stats["Strength"];
            int dex_SP = (int)this.stats["Dexerity"];
            int con_SP = (int)this.stats["Constitution"];
            int intl_SP = (int)this.stats["Intelligence"];
            this.Stamina = (intl_SP * 5) + (dex_SP * 5) + (str_SP * 5) + (con_SP * 5) + this.Stamina;
        }
        public void calcAttack()
        {
            this.Attack = ((int)this.stats["Strength"] * 2) + ((int)this.stats["Dexerity"] * 1);
        }
        public void calcDefense()
        {
            this.Defense = ((int)this.stats["Strength"] * 1) + ((int)this.stats["Dexerity"] * 1) + ((int)this.stats["Constitution"] * 2) + ((int)this.stats["Speed"] * 1);
        }
    }
}

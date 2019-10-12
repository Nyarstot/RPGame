using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGame
{

   public class Enemy
    {
        public int HPenemy;
        public int EnemyStamina;
        public string Description;
        public string Name;

        public Enemy()
        {
            HPenemy = 100;
            EnemyStamina = 100;
        }

        public void EnemyHuman (string name,string Desc, int x, int y)
        {
            Name = name;
            Description = Desc;
            EnemyStamina = x;
            HPenemy = y;

        }

        public void Monster (string name, string Desc, int x, int y)
        {
            Name = name;
            Description = Desc;
            EnemyStamina = x;
            HPenemy = y;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientExample
{
    public class Fighter
    {
        public int HP { get; set; }

        public int Pos { get; }

        public bool IsDead { get { return HP <= 0; } }

        public string Name { get; }

        public Fighter(int hp, string name, int pos)
        {
            this.HP = hp;
            this.Pos = pos;
            this.Name = name;
        }

        public void hit(Fighter target, int strength)
        {
            target.HP -= strength;
        }
    }
}

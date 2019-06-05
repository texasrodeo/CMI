using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientExample
{
    public class Game
    {
        public Fighter FighterLeft { get; }
        public Fighter FighterRight { get; }

        

        public bool IsGameEnded { get { return FighterLeft.IsDead || FighterRight.IsDead; } }

        public Fighter winner {
            get
            {
                if (IsGameEnded)
                {
                    if (FighterLeft.IsDead)
                        return FighterRight;
                    else
                        return FighterLeft;
                }
                else
                    return null;
                    
            }

        }

        public Game()
        {
            FighterLeft = new Fighter(15000, "Котана", 0);
            FighterRight = new Fighter(15000, "Кот-Зиро", 1);

           
        }

        public void makeTurn(int strength,bool isLeftTurn)
        {
            if (isLeftTurn)
            {
                FighterLeft.hit(FighterRight, strength);
            }
            else
            {
                FighterRight.hit(FighterLeft, strength);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;


namespace HREngine.Bots
{

    public class Sim_DRG_052 : SimTemplate
    {


        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, own.own, true);
        }
    }
}
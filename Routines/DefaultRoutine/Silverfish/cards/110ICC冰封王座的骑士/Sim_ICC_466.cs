using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_466: SimTemplate //* Saronite Chain Gang
    {
        // Taunt Battlecry: Summon another Saronite Chain Gang.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(m.handcard.card, m.zonepos, m.own);
        }
    }
}
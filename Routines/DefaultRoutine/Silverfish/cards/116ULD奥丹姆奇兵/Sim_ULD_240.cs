using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ULD_240 : SimTemplate //* 对空奥术法师 Arcane Flakmage
    {
        //After you play a <b>Secret</b>, deal 2 damage to all enemy minions.
        //在你使用一张<b>奥秘</b>牌后，对所有敌方随从造成2点伤害。
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
    
            if (m.own == ownplay && hc.card.Secret) p.allMinionOfASideGetDamage(!ownplay, dmg, true);

        }
    }
}
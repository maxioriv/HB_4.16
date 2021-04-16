using System;
using System.Collections.Generic;
using System.Text;


namespace HREngine.Bots
{
class Sim_ULD_276 : SimTemplate 
{




public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
{
if (turnEndOfOwner == triggerEffectMinion.own)
{
p.drawACard(CardDB.cardIDEnum.None, turnEndOfOwner);
}
}


}
}
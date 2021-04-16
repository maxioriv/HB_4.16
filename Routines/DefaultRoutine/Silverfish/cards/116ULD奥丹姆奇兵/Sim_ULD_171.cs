using System;
using System.Collections.Generic;
using System.Text;
namespace HREngine.Bots
{
class Sim_ULD_171 : SimTemplate //* 图腾潮涌 Totemic Surge
{
//Give your Totems +2 Attack.
//使你的图腾获得+2攻击力。
public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
{
List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
foreach (Minion t in temp)
{
if (t.handcard.card.race == 21) 
{
p.minionGetBuffed(t, 2, 0);
}
}
}




}
}

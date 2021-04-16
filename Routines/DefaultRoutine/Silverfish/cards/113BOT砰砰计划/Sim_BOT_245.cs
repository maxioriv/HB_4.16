using System;
using System.Collections.Generic;
using System.Text;


namespace HREngine.Bots
{
class Sim_BOT_245: SimTemplate //* 风暴聚合器
{
CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_182);
public override void onCardPlay(Playfield p,bool ownplay,Minion target,int choice)
{
List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
foreach(Minion m in temp)
{
p.minionTransform(m,kid);
}
}
}
}

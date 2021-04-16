using System;
using System.Collections.Generic;
using System.Text;


namespace HREngine.Bots
{
	class Sim_BOT_910 : SimTemplate //* 亮石技师 Glowstone Technician
	{
		//<b>Battlecry:</b> Give all minions in your hand +2/+2.
		//<b>战吼：</b>使你手牌中的所有随从牌获得+2/+2。
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{

foreach (Handmanager.Handcard hc in p.owncards)
{
if (hc.card.type == CardDB.cardtype.MOB)
{
hc.addattack+=2;
hc.addHp+=2;
}
}
}

		



	}
}
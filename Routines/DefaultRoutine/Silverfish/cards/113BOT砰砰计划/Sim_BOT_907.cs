using System;
using System.Collections.Generic;
using System.Text;


namespace HREngine.Bots
{
	class Sim_BOT_907 : SimTemplate //* 通电机器人 Galvanizer
	{
		//[x]<b>Battlecry:</b> Reduce theCost of Mechs in yourhand by (1).
		//<b>战吼：</b>使你手牌中所有机械牌的法力值消耗减少（1）点。
		//<b>战吼：</b>使你手牌中所有机械牌的法力值消耗减少（1）点。
public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{
if (own.own && p.ownMinions != null)
{
foreach (Handmanager.Handcard hc in p.owncards)
{
if (hc.card.race == 17)
{
if (hc.manacost >= 1) hc.manacost--;
}
}
}
}

	}
}
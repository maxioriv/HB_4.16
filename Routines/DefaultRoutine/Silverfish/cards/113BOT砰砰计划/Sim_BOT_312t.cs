using System;
using System.Collections.Generic;
using System.Text;


namespace HREngine.Bots
{
	class Sim_BOT_312t : SimTemplate //* 微型机器人 Microbot
	{
		//
		//
		// CardDB.Card kid = CardDB. Instance.getCardDataFromID(CardDB.cardIDEnum.BOT_312t);
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{
if (own.own) p.Magnetic(own);
}


	}
}
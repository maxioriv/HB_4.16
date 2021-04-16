using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_ULD_413 : SimTemplate //* 分裂战斧 Splitting Axe
	{
		//<b>Battlecry:</b> Summon copies of your Totems.
		//<b>战吼：</b>召唤你的图腾的复制。
		CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ULD_413);
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			p.equipWeapon(weapon, ownplay);
			List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
			List<Minion> CopiesMinion = new List<Minion>();
			foreach (Minion t in temp)
				if ((TAG_RACE)t.handcard.card.race == TAG_RACE.TOTEM)
					CopiesMinion.Add(t);
			foreach (Minion t in CopiesMinion)
			{
				int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
				if (pos < 7)
				{
					p.callKid(t.handcard.card, pos, ownplay);
					if(ownplay) p.ownMinions[pos].setMinionToMinion(t);	
					else p.enemyMinions[pos].setMinionToMinion(t);
				}
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_076 : SimTemplate //* Sir Finley Mrrgglton
	{
		//Battlecry: Discover a new Basic Hero Power.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, own.own, true);
		}
	}
}
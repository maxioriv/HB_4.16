using System;
using System.Collections.Generic;
using System.Text;



namespace HREngine.Bots
{
	class Sim_BOT_563 : SimTemplate //* 战争机兵 Wargear
	{
		//<b>Magnetic</b>
		//<b>磁力</b>
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{
if (own.own) p.Magnetic(own);
}


	}
}
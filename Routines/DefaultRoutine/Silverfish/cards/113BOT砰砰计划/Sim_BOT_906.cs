using System;
using System.Collections.Generic;
using System.Text;



namespace HREngine.Bots
{
	class Sim_BOT_906 : SimTemplate //* 格洛顿 Glow-Tron
	{
		//<b>Magnetic</b>
		//<b>磁力</b>
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{
if (own.own) p.Magnetic(own);
}


	}
}
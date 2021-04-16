using System;
using System.Collections.Generic;
using System.Text;



namespace HREngine.Bots
{
	class Sim_BOT_911 : SimTemplate //* 吵吵模组 Annoy-o-Module
	{
		//<b>Magnetic</b><b>Divine Shield</b><b>Taunt</b>
		//<b>磁力</b><b>圣盾</b><b>嘲讽</b>
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{
if (own.own) p.Magnetic(own);
}


	}
}
using System;
using System.Collections.Generic;
using System.Text;



namespace HREngine.Bots
{
	class Sim_BOT_548 : SimTemplate //* 奇利亚斯 Zilliax
	{
		//<b>Magnetic</b><b><b>Divine Shield</b>, <b>Taunt</b>, Lifesteal, Rush</b>
		//<b>磁力，圣盾，嘲讽，吸血，突袭</b>
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{
if (own.own) p.Magnetic(own);
}


	}
}
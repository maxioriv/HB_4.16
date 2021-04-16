using System;
using System.Collections.Generic;
using System.Text;


namespace HREngine.Bots
{
	class Sim_BOT_909 : SimTemplate //* 水晶学 Crystology
	{
		//[x]Draw two 1-Attackminions from your deck.
		//从你的牌库中抽两张攻击力为1的随从牌。
     public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)


{


p.drawACard(CardDB.cardIDEnum.None, ownplay);


p.drawACard(CardDB.cardIDEnum.None, ownplay);


}


	}
}
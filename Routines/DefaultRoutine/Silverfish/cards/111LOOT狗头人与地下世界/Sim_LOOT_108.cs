using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOOT_108 : SimTemplate //* 艾露尼斯 Aluneth
    {
        //At the end of your turn, draw 3 cards.
        //在你的回合结束时，抽三张牌。
    CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOOT_108);
 
    public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
    {
        p.equipWeapon(weapon, ownplay);
    }

    }
}
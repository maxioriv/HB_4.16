using System;
using System.Collections.Generic;
using System.Text;
namespace HREngine.Bots
{
class Sim_GIL_586 : SimTemplate //* 大地之力 Earthen Might
{
//[x]Give a minion +2/+2.If it's an Elemental, adda random Elementalto your hand.
//使一个随从获得+2/+2。如果该随从是元素，则随机将一张元素牌置入你的手牌。
public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
{
p.minionGetBuffed(target, 2, 2);
if ((TAG_RACE)target.handcard.card.race == TAG_RACE.ELEMENTAL)
p.drawACard(CardDB.cardName.unknown, ownplay, true);
if ((TAG_RACE)target.handcard.card.race == TAG_RACE.TOTEM)
p.evaluatePenality -= 5;
}




}
}

namespace HREngine.Bots
{
	class Sim_ULD_209t : SimTemplate //* 神秘选项 Mystery Choice!
	{
		//Add a random spell to your hand.
		//随机将一张法术牌置入你的手牌。
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay,true);
        }

	}
}
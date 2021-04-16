namespace HREngine.Bots
{
	class Sim_ULD_209 : SimTemplate //* 狐人恶棍 Vulpera Scoundrel
	{
		//<b>Battlecry</b>: <b>Discover</b> a spell or pick a mystery choice.
		//<b>战吼：发现</b>一张法术牌或选择一个神秘选项。
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.thecoin, own.own, true);
		}

	}
}
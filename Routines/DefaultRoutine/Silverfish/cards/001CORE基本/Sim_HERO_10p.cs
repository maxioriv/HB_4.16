namespace HREngine.Bots
{
	class Sim_HERO_10p : SimTemplate //* 恶魔之爪 Demon Claws
	{
		//[x]<b>Hero Power</b>+1 Attack this turn.
		//<b>英雄技能</b>在本回合中获得+1攻击力。

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			p.minionGetTempBuff(ownplay ? p.ownHero : p.enemyHero, 1, 0);
		}
	}
}
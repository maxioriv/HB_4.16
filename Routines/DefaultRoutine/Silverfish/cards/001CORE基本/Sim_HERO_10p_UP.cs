namespace HREngine.Bots
{
	class Sim_HERO_10p_UP : SimTemplate //* 恶魔之咬 Demon's Bite
	{
		//[x]<b>Hero Power</b>+2 Attack this turn.
		//<b>英雄技能</b>在本回合中获得+2攻击力。

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			p.minionGetTempBuff(ownplay ? p.ownHero : p.enemyHero, 2, 0);
		}
	}
}
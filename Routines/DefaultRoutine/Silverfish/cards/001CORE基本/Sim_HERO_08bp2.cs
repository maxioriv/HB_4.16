namespace HREngine.Bots
{
	class Sim_HERO_08bp2 : Sim_AT_132_MAGE //* 二级火焰冲击
	{
		  public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
        }

	}
}
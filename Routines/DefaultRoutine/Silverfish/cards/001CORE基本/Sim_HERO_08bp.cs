namespace HREngine.Bots
{
	class Sim_HERO_08bp : SimTemplate //* 火冲
	{
		  public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
        }

	}
}
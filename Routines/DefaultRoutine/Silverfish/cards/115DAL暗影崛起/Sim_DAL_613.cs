using System;
using System.Collections.Generic;
using System.Text;


namespace HREngine.Bots
{ 

public class Sim_DAL_613: SimTemplate 
{ 



public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice) 
{ 
CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_121);
List<Minion> list = (m.own) ? p.ownMinions : p.enemyMinions; 
int anz = list.Count; 
p.callKid(kid, m.zonepos, m.own); 
if (anz < 7 && !list[m.zonepos].taunt) 
{ 
list[m.zonepos].taunt = true; 
if (m.own) 
{ 
p.anzOwnTaunt++; 
} 
else 
{ 
p.anzEnemyTaunt++; 
} 
} 
}
} 
}
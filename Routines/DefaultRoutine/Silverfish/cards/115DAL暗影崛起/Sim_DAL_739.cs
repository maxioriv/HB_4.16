using System;
using System.Collections.Generic;
using System.Text;
namespace HREngine.Bots
{
public class Sim_DAL_739 : SimTemplate
{
public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{
if (target != null && own.own) 
{
p.minionGetBuffed(target, 1, 0);
p.minionGetRush(target);
}
}
}
}

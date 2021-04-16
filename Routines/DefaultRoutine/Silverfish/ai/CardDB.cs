using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HREngine.Bots
{
    public struct targett
    {
        public int target;
        public int targetEntity;

        public targett(int targ, int ent)
        {
            this.target = targ;
            this.targetEntity = ent;
        }
    }


    public partial class CardDB
    {
        // Data is stored in hearthstone-folder -> data->win cardxml0
        //(data-> cardxml0 seems outdated (blutelfkleriker has 3hp there >_>)
        public enum cardtype
        {
            NONE,
            MOB=4,
            SPELL=5,
            WEAPON=7,
            HEROPWR=10,
            ENCHANTMENT=6,
            HERO=3,
        }

        public enum cardtrigers
        {
            newtriger,
            getBattlecryEffect,
            onAHeroGotHealedTrigger,
            onAMinionGotHealedTrigger,
            onAuraEnds,
            onAuraStarts,
            onCardIsGoingToBePlayed,
            onCardPlay,
            onCardWasPlayed,
            onDeathrattle,
            onEnrageStart,
            onEnrageStop,
            onMinionDiedTrigger,
            onMinionGotDmgTrigger,
            onMinionIsSummoned,
            onMinionWasSummoned,
            onSecretPlay,
            onTurnEndsTrigger,
            onTurnStartTrigger,
            triggerInspire
        }

        public enum cardrace
        {
            INVALID,
            BLOODELF,
            DRAENEI,
            DWARF,
            GNOME,
            GOBLIN,
            HUMAN,
            NIGHTELF,
            ORC,
            TAUREN,
            TROLL,
            UNDEAD,
            WORGEN,
            GOBLIN2,
            MURLOC,
            DEMON,
            SCOURGE,
            MECHANICAL,
            ELEMENTAL,
            OGRE,
            PET,
            TOTEM,
            NERUBIAN,
            PIRATE,
            DRAGON
        }


        public cardIDEnum cardIdstringToEnum(string s)
        {
            CardDB.cardIDEnum CardEnum;
            if (Enum.TryParse<cardIDEnum>(s, false, out CardEnum)) return CardEnum;
            else return CardDB.cardIDEnum.None;
        }

        public cardName cardNamestringToEnum(string s)
        {
            CardDB.cardName NameEnum;
            if (Enum.TryParse<cardName>(s, false, out NameEnum)) return NameEnum;
            else return CardDB.cardName.unknown;
        }

        public enum ErrorType2
        {
            INVALID = -1,
            NONE = 0,
            REQ_MINION_TARGET = 1,
            REQ_FRIENDLY_TARGET = 2,
            REQ_ENEMY_TARGET = 3,
            REQ_DAMAGED_TARGET = 4,
            REQ_MAX_SECRETS = 5,
            REQ_FROZEN_TARGET = 6,
            REQ_CHARGE_TARGET = 7,
            REQ_TARGET_MAX_ATTACK = 8,
            REQ_NONSELF_TARGET = 9,
            REQ_TARGET_WITH_RACE = 10,
            REQ_TARGET_TO_PLAY = 11,
            REQ_NUM_MINION_SLOTS = 12,
            REQ_WEAPON_EQUIPPED = 13,
            REQ_ENOUGH_MANA = 14,
            REQ_YOUR_TURN = 15,
            REQ_NONSTEALTH_ENEMY_TARGET = 16,
            REQ_HERO_TARGET = 17,
            REQ_SECRET_ZONE_CAP = 18,
            REQ_MINION_CAP_IF_TARGET_AVAILABLE = 19,
            REQ_MINION_CAP = 20,
            REQ_TARGET_ATTACKED_THIS_TURN = 21,
            REQ_TARGET_IF_AVAILABLE = 22,
            REQ_MINIMUM_ENEMY_MINIONS = 23,
            REQ_TARGET_FOR_COMBO = 24,
            REQ_NOT_EXHAUSTED_ACTIVATE = 25,
            REQ_UNIQUE_SECRET_OR_QUEST = 26,
            REQ_TARGET_TAUNTER = 27,
            REQ_CAN_BE_ATTACKED = 28,
            REQ_ACTION_PWR_IS_MASTER_PWR = 29,
            REQ_TARGET_MAGNET = 30,
            REQ_ATTACK_GREATER_THAN_0 = 31,
            REQ_ATTACKER_NOT_FROZEN = 32,
            REQ_HERO_OR_MINION_TARGET = 33,
            REQ_CAN_BE_TARGETED_BY_SPELLS = 34,
            REQ_SUBCARD_IS_PLAYABLE = 35,
            REQ_TARGET_FOR_NO_COMBO = 36,
            REQ_NOT_MINION_JUST_PLAYED = 37,
            REQ_NOT_EXHAUSTED_HERO_POWER = 38,
            REQ_CAN_BE_TARGETED_BY_OPPONENTS = 39,
            REQ_ATTACKER_CAN_ATTACK = 40,
            REQ_TARGET_MIN_ATTACK = 41,
            REQ_CAN_BE_TARGETED_BY_HERO_POWERS = 42,
            REQ_ENEMY_TARGET_NOT_IMMUNE = 43,
            REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY = 44,
            REQ_MINIMUM_TOTAL_MINIONS = 45,
            REQ_MUST_TARGET_TAUNTER = 46,
            REQ_UNDAMAGED_TARGET = 47,
            REQ_CAN_BE_TARGETED_BY_BATTLECRIES = 48,
            REQ_STEADY_SHOT = 49,
            REQ_MINION_OR_ENEMY_HERO = 50,
            REQ_TARGET_IF_AVAILABLE_AND_DRAGON_IN_HAND = 51,
            REQ_LEGENDARY_TARGET = 52,
            REQ_FRIENDLY_MINION_DIED_THIS_TURN = 53,
            REQ_FRIENDLY_MINION_DIED_THIS_GAME = 54,
            REQ_ENEMY_WEAPON_EQUIPPED = 55,
            REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS = 56,
            REQ_TARGET_WITH_BATTLECRY = 57,
            REQ_TARGET_WITH_DEATHRATTLE = 58,
            REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_SECRETS = 59,
            REQ_SECRET_ZONE_CAP_FOR_NON_SECRET = 60,
            REQ_TARGET_EXACT_COST = 61,
            REQ_STEALTHED_TARGET = 62,
            REQ_MINION_SLOT_OR_MANA_CRYSTAL_SLOT = 63,
            REQ_MAX_QUESTS = 64,
            REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN = 65,
            REQ_TARGET_NOT_VAMPIRE = 66,
            REQ_TARGET_NOT_DAMAGEABLE_ONLY_BY_WEAPONS = 67,
            REQ_NOT_DISABLED_HERO_POWER = 68,
            REQ_MUST_PLAY_OTHER_CARD_FIRST = 69,
            REQ_HAND_NOT_FULL = 70,
            REQ_DRAG_TO_PLAY = 71,
            REQ_TARGET_TO_PLAY2 = 75,
        }

        public class Card
        {
            //public string CardID = "";
            public cardName name = cardName.unknown;
            public int race = 0;
            public int rarity = 0;
            public int cost = 0;
            public int Class = 0;
            public cardtype type = CardDB.cardtype.NONE;
            //public string description = "";

            public int Attack = 0;
            public int Health = 0;
            public int Durability = 0;//for weapons
            public bool tank = false;
            public bool Silence = false;
            public bool choice = false;
            public bool windfury = false;
            public bool poisonous = false;
            public bool lifesteal = false;
            public bool dormant = false;//����
            public bool reborn = false;
            public bool deathrattle = false;
            public bool battlecry = false;
            public bool discover = false;
            public bool oneTurnEffect = false;
            public bool Enrage = false;
            public bool Aura = false;
            public bool Elite = false;
            public bool Combo = false;
            public int overload = 0;
            public bool immuneWhileAttacking = false;
            public bool untouchable = false;
            public bool Stealth = false;
            public bool Freeze = false;
            public bool AdjacentBuff = false;
            public bool Shield = false;
            public bool Charge = false;
            public bool Rush = false;
            public bool Secret = false;
            public bool Quest = false;
            public bool Morph = false;
            public bool Spellpower = false;
            public bool Inspire = false;
            public bool outcast = false;//����



            public int needEmptyPlacesForPlaying = 0;
            public int needWithMinAttackValueOf = 0;
            public int needWithMaxAttackValueOf = 0;
            public int needRaceForPlaying = 0;
            public int needMinNumberOfEnemy = 0;
            public int needMinTotalMinions = 0;
            public int needMinOwnMinions = 0;
            public int needMinionsCapIfAvailable = 0;
            public int needControlaSecret = 0;
            
            //additional data
            public bool isToken = false;
            public int isCarddraw = 0;
            public bool damagesTarget = false;
            public bool damagesTargetWithSpecial = false;
            public int targetPriority = 0;
            public bool isSpecialMinion = false;

            public int spellpowervalue = 0;
            public cardIDEnum cardIDenum = cardIDEnum.None;
            public List<ErrorType2> playrequires;
            public List<cardtrigers> trigers;

            public SimTemplate sim_card;

            public Card()
            {
                playrequires = new List<ErrorType2>();
            }

            public bool isRequirementInList(CardDB.ErrorType2 et)
            {
                return this.playrequires.Contains(et);
            }

            public List<Minion> getTargetsForCard(Playfield p, bool isLethalCheck, bool own)
            {
                //if wereTargets=true and 0 targets at end -> then can not play this card
                List<Minion> retval = new List<Minion>();
                if (this.type == CardDB.cardtype.MOB && ((own && p.ownMinions.Count >= 7) || (!own && p.enemyMinions.Count >=7))) return retval; // cant play mob, if we have allready 7 mininos
                if (this.Secret && ((own && (p.ownSecretsIDList.Contains(this.cardIDenum) || p.ownSecretsIDList.Count >= 5)) || (!own && p.enemySecretCount >= 5))) return retval;
                //if (p.mana < this.getManaCost(p, 1)) return retval;

                if (this.playrequires.Count == 0) { retval.Add(null); return retval; }

                List<Minion> targets = new List<Minion>();
                bool targetAll = false;
                bool targetAllEnemy = false;
                bool targetAllFriendly = false;
                bool targetEnemyHero = false;
                bool targetOwnHero = false;
                bool targetOnlyMinion = false;
                bool extraParam = false;
                bool wereTargets = false;
                bool REQ_UNDAMAGED_TARGET = false;
                bool REQ_TARGET_WITH_DEATHRATTLE = false;
                bool REQ_TARGET_WITH_RACE = false;
                bool REQ_TARGET_MIN_ATTACK = false;
                bool REQ_TARGET_MAX_ATTACK = false;
                bool REQ_MUST_TARGET_TAUNTER = false;
                bool REQ_STEADY_SHOT = false;
                bool REQ_FROZEN_TARGET = false;
                bool REQ_HERO_TARGET = false;
                bool REQ_DAMAGED_TARGET = false;
                bool REQ_LEGENDARY_TARGET = false;
                bool REQ_TARGET_IF_AVAILABLE = false;
                bool REQ_STEALTHED_TARGET = false;
                bool REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN = false;

                foreach (CardDB.ErrorType2 PlayReq in this.playrequires)
                {
                    switch (PlayReq)
                    {
                        case ErrorType2.REQ_TARGET_TO_PLAY:
                        case ErrorType2.REQ_TARGET_TO_PLAY2:
                            targetAll = true;
                            continue;
                        case ErrorType2.REQ_MINION_TARGET:
                            targetOnlyMinion = true;
                            continue;
                        case ErrorType2.REQ_TARGET_IF_AVAILABLE:
                            REQ_TARGET_IF_AVAILABLE = true;
                            targetAll = true;
                            continue;
                        case ErrorType2.REQ_FRIENDLY_TARGET:
                            if (own) targetAllFriendly = true;
                            else targetAllEnemy = true;
                            continue;
                        case ErrorType2.REQ_NUM_MINION_SLOTS:
                            if ((own ? p.ownMinions.Count : p.enemyMinions.Count) > 7 - this.needEmptyPlacesForPlaying) return retval;
                            continue;
                        case ErrorType2.REQ_MINION_SLOT_OR_MANA_CRYSTAL_SLOT:
                            if (own) { if (p.ownMinions.Count > 6 & p.ownMaxMana > 9) return retval; }
                            else if (p.enemyMinions.Count > 6 & p.enemyMaxMana > 9) return retval;
                            continue;
                        case ErrorType2.REQ_ENEMY_TARGET:
                            if (own) targetAllEnemy = true;
                            else targetAllFriendly = true;
                            continue;
                        case ErrorType2.REQ_HERO_TARGET:
                            REQ_HERO_TARGET = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_MINIMUM_ENEMY_MINIONS:
                            if ((own ? p.enemyMinions.Count : p.ownMinions.Count) < this.needMinNumberOfEnemy) return retval;
                            continue;
                        case ErrorType2.REQ_NONSELF_TARGET:
                            targetAll = true;
                            continue;
                        case ErrorType2.REQ_TARGET_WITH_RACE:
                            REQ_TARGET_WITH_RACE = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_DAMAGED_TARGET:
                            REQ_DAMAGED_TARGET = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_TARGET_MAX_ATTACK:
                            REQ_TARGET_MAX_ATTACK = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_WEAPON_EQUIPPED:
                            if ((own ? p.ownWeapon.Durability : p.enemyWeapon.Durability) == 0) return retval;
                            continue;
                        case ErrorType2.REQ_TARGET_FOR_COMBO:
                            if (p.cardsPlayedThisTurn >=1) targetAll = true;
                            continue;
                        case ErrorType2.REQ_TARGET_MIN_ATTACK:
                            REQ_TARGET_MIN_ATTACK = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_MINIMUM_TOTAL_MINIONS:
                            if (this.needMinTotalMinions > p.ownMinions.Count + p.enemyMinions.Count) return retval;
                            continue;
                        case ErrorType2.REQ_MINION_CAP_IF_TARGET_AVAILABLE:
                            if ((own ? p.ownMinions.Count : p.enemyMinions.Count) > 7 - this.needMinionsCapIfAvailable) return retval;
                            continue;
                        case ErrorType2.REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY:
                            int difftotem = 0;
                            foreach (Minion m in (own ? p.ownMinions : p.enemyMinions))
                            {
                                if (m.name == CardDB.cardName.healingtotem || m.name == CardDB.cardName.wrathofairtotem || m.name == CardDB.cardName.searingtotem || m.name == CardDB.cardName.stoneclawtotem) difftotem++;
                            }
                            if (difftotem == 4) return retval;
                            continue;
                        case ErrorType2.REQ_MUST_TARGET_TAUNTER:
                            REQ_MUST_TARGET_TAUNTER = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_DRAGON_IN_HAND:
                            if (own)
                            {
                                foreach (Handmanager.Handcard hc in p.owncards)
                                {
                                    if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) {targetAll = true; break; }
                                }
                            }
                            else targetAll = true; // apriori the enemy have a dragon
                            continue;
                        case ErrorType2.REQ_LEGENDARY_TARGET:
                            REQ_LEGENDARY_TARGET = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_UNDAMAGED_TARGET:
                            REQ_UNDAMAGED_TARGET = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_TARGET_WITH_DEATHRATTLE:
                            REQ_TARGET_WITH_DEATHRATTLE = true;
                            targetOnlyMinion = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN:
                            REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_STEADY_SHOT:
                            REQ_STEADY_SHOT = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_FROZEN_TARGET:
                            REQ_FROZEN_TARGET = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_MINION_OR_ENEMY_HERO:
                            REQ_STEADY_SHOT = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_STEALTHED_TARGET:
                            REQ_STEALTHED_TARGET = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_ENEMY_WEAPON_EQUIPPED:
                            if (own)
                            {
                                if (p.enemyWeapon.Durability > 0) targetEnemyHero = true;
                                else return retval;
                            }
                            else
                            {
                                if (p.ownWeapon.Durability > 0) targetOwnHero = true;
                                else return retval;
                            }
                            continue;
                        case ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS:
                            int tmp = (own) ? p.ownMinions.Count : p.enemyMinions.Count;
                            if (tmp >= needMinOwnMinions) targetAll = true;
                            continue;
                        case ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_SECRETS:
                            if (p.ownSecretsIDList.Count >= needControlaSecret) targetAll = true;
                            continue;
                        case ErrorType2.REQ_MUST_PLAY_OTHER_CARD_FIRST:
                            if (p.cardsPlayedThisTurn == 0) return retval;
                            continue;
                        case ErrorType2.REQ_HAND_NOT_FULL:
                            if (p.owncards.Count == 10) return retval;
                            continue;

                            //default:
                    }
                }

			    if(targetAll)
			    {
                    wereTargets = true;
                    if (targetAllFriendly != targetAllEnemy)
                    {
                        if (targetAllFriendly)
                        {
                            foreach (Minion m in p.ownMinions) if (!m.untouchable) targets.Add(m);
                        }
                        else
                        {
                            foreach (Minion m in p.enemyMinions) if (!m.untouchable) targets.Add(m);
                        }
                    }
                    else
                    {
                        foreach (Minion m in p.ownMinions) if (!m.untouchable) targets.Add(m);
                        foreach (Minion m in p.enemyMinions) if (!m.untouchable) targets.Add(m);
                    }
				    if(targetOnlyMinion)
				    {
                        targetEnemyHero = false;
                        targetOwnHero = false;
				    }
                    else
                    {
                        if (!p.enemyHero.immune) targetEnemyHero = true;
                        if (!p.ownHero.immune) targetOwnHero = true;
                        if (targetAllEnemy) targetOwnHero = false;
                        if (targetAllFriendly) targetEnemyHero = false;
                    }
			    }

                if(extraParam)
                {
                    wereTargets = true;
                    if(REQ_TARGET_WITH_RACE)
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.handcard.card.race != this.needRaceForPlaying) m.extraParam = true;
                        }
                        targetOwnHero = (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                        targetEnemyHero = (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    }
                    if(REQ_HERO_TARGET)
                    {
                        foreach (Minion m in targets)
                        {
                            m.extraParam = true;
                        }
                        targetOwnHero = true;
                        targetEnemyHero = true;
                    }
                    if(REQ_DAMAGED_TARGET)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.wounded)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if(REQ_TARGET_MAX_ATTACK)
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.Angr > this.needWithMaxAttackValueOf)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if(REQ_TARGET_MIN_ATTACK)
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.Angr < this.needWithMinAttackValueOf)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if(REQ_MUST_TARGET_TAUNTER)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.taunt)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if(REQ_UNDAMAGED_TARGET)
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.wounded)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_STEALTHED_TARGET)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.stealth)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_TARGET_WITH_DEATHRATTLE)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.silenced && (m.handcard.card.deathrattle || m.deathrattle2 != null ||
                            m.ancestralspirit + m.desperatestand + m.souloftheforest + m.stegodon + m.livingspores + m.explorershat + m.returnToHand + m.infest > 0)) continue;               
                            else m.extraParam = true;
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN)
                    {
                        if (p.anzOwnElementalsLastTurn < 1)
                        {
                            foreach (Minion m in targets) m.extraParam = true;
                            targetOwnHero = false;
                            targetEnemyHero = false;
                        }
                    }
                    if(REQ_LEGENDARY_TARGET)
                    {
                        wereTargets = false;
                        foreach (Minion m in targets)
                        {
                            if (m.handcard.card.rarity != 5) m.extraParam = true;
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if(REQ_STEADY_SHOT)
                    {
                        if ((p.weHaveSteamwheedleSniper && own) || (p.enemyHaveSteamwheedleSniper && !own))
                        {
                            foreach (Minion m in targets)
                            {
                                if (m.cantBeTargetedBySpellsOrHeroPowers && (this.type == cardtype.HEROPWR || this.type == cardtype.SPELL))
                                {
                                    m.extraParam = true;
                                    if(m.stealth && !m.own) m.extraParam = true;
                                }
                            }
                            if (own) targetEnemyHero = true;
                            else targetOwnHero = true;
                        }
                        else wereTargets = false;
                    }
                    if (REQ_FROZEN_TARGET)
                    {
                        
                        foreach (Minion m in targets)
                        {
                            if (!m.frozen) m.extraParam = true;
                        }
                    }                    
                }

                if (targetEnemyHero && own && p.enemyHero.stealth) targetEnemyHero = false;
                if (targetOwnHero && !own && p.ownHero.stealth) targetOwnHero = false;

                if (isLethalCheck) 
                {
                    if (targetEnemyHero && own) retval.Add(p.enemyHero);
                    else if (targetOwnHero && !own) retval.Add(p.ownHero);
                    
                    switch (this.type)
                    {
                        case cardtype.SPELL:
                            if (p.prozis.penman.attackBuffDatabase.ContainsKey(this.name))
                            {
                                if (targetOwnHero && own) retval.Add(p.ownHero);
                                foreach (Minion m in targets)
                                {
                                    if (m.extraParam != true && !m.cantBeTargetedBySpellsOrHeroPowers)
                                    {
                                        if (m.own)
                                        {
                                            if (m.Ready) retval.Add(m);
                                        }
                                        else if (m.taunt) retval.Add(m);
                                    }
                                    m.extraParam = false;
                                }
                            }
                            else
                            {
                                switch (this.name)
                                {
                                    case cardName.polymorphboar:
                                        foreach (Minion m in targets)
                                        {
                                            m.extraParam = false;
                                            if (m.cantBeTargetedBySpellsOrHeroPowers) continue;
                                            if (m.own) retval.Add(m);
                                            else if (m.taunt) retval.Add(m);
                                        }
                                        break;
                                    case cardName.hex: goto case cardName.polymorph;
                                    case cardName.polymorph:
                                        foreach (Minion m in targets)
                                        {
                                            m.extraParam = false;
                                            if (!m.own && m.taunt && !m.cantBeTargetedBySpellsOrHeroPowers) retval.Add(m);
                                        }
                                        break;
                                }
                            }
                            break;
                        case cardtype.MOB:
                            foreach (Minion m in targets)
                            {
                                if (m.extraParam != true)
                                {
                                    if (m.stealth && !m.own) continue;
                                    retval.Add(m);
                                }
                                m.extraParam = false;
                            }
                            break;
                        case cardtype.HEROPWR:
                            if (p.prozis.penman.attackBuffDatabase.ContainsKey(this.name))
                            {
                                foreach (Minion m in targets)
                                {
                                    if (m.extraParam != true && !m.cantBeTargetedBySpellsOrHeroPowers)
                                    {
                                        if (m.own)
                                        {
                                            if (m.Ready) retval.Add(m);
                                        }
                                        else if (m.taunt) retval.Add(m);
                                    }
                                    m.extraParam = false;
                                }
                            }
                            break;
                    }
                }
                else
                {
                    if (targetEnemyHero) retval.Add(p.enemyHero);
                    if (targetOwnHero) retval.Add(p.ownHero);

                    foreach (Minion m in targets)
                    {
                        if (m.extraParam != true)
                        {
                            if (m.stealth && !m.own) continue;
                            if (m.cantBeTargetedBySpellsOrHeroPowers && (this.type == cardtype.SPELL || this.type == cardtype.HEROPWR)) continue;
                            retval.Add(m);
                        }
                        m.extraParam = false;
                    }
                }

                if (retval.Count == 0 && (!wereTargets || REQ_TARGET_IF_AVAILABLE)) retval.Add(null);

                return retval;
            }
            

            public List<Minion> getTargetsForHeroPower(Playfield p, bool own)
            {
                List<Minion> trgts = getTargetsForCard(p, p.isLethalCheck, own);
                cardName abName = own ? p.ownHeroAblility.card.name : p.enemyHeroAblility.card.name;
                int abType = 0; //0 none, 1 damage, 2 heal, 3 baff
                switch (abName)
                {
                    case cardName.heal: goto case cardName.lesserheal; 
                    case cardName.lesserheal:
                        if (p.anzOwnAuchenaiSoulpriest > 0 || p.embracetheshadow > 0) abType = 1;
                        else abType = 2;
                        break;
                    case cardName.ballistashot: abType = 1; break; 
                    case cardName.steadyshot: abType = 1; break;
                    case cardName.fireblast: abType = 1; break;
                    case cardName.fireblastrank2: abType = 1; break;
                    case cardName.lightningjolt: abType = 1; break;
                    case cardName.mindspike: abType = 1; break;
                    case cardName.mindshatter: abType = 1; break;
                    case cardName.powerofthefirelord: abType = 1; break;
                    case cardName.shotgunblast: abType = 1; break;
                    case cardName.unbalancingstrike: abType = 1; break;
                    case cardName.dinomancy: abType = 3; break;
                }

                switch (abType)
                {
                    case 2:
                        List<Minion> minions = own ? p.ownMinions : p.enemyMinions;
                        int tCount = minions.Count;
                        bool needCut = true;
                        for (int i = 0; i < tCount; i++)
                        {
                            switch (minions[i].name)
                            {
                                case cardName.shadowboxer: 
                                    if (own && p.enemyHero.Hp == 1 && p.enemyMinions.Count > 0) needCut = false;
                                    break;
                                case cardName.holychampion: needCut = false; break;
                                case cardName.lightwarden: needCut = false; break;
                                case cardName.northshirecleric: needCut = false; break;
                                
                                
                            }
                        }
                        
                        tCount = trgts.Count;
                        if (tCount > 0)
                        {
                            if (trgts[0] != null)
                            {
                                List<Minion> tmp = new List<Minion>();
                                for (int i = 0; i < tCount; i++)
                                {
                                    Minion m = trgts[i];
                                    if (m.Hp < m.maxHp)
                                    {
                                        if (needCut)
                                        {
                                            if (m.own == own) tmp.Add(m);
                                        }
                                        else tmp.Add(m);
                                    }
                                }
                                return tmp;
                            }
                        }
                        break;
                }
                return trgts;
            }

            public int calculateManaCost(Playfield p)//calculates the mana from orginal mana, needed for back-to hand effects and new draw
            {
                int retval = this.cost;
                int offset = 0;

                if (p.anzOwnShadowfiend > 0) offset -= p.anzOwnShadowfiend;

                switch (this.type)
                {
                    case cardtype.MOB:
                        if (p.anzOwnAviana > 0) retval = 1;

                        offset += p.ownMinionsCostMore;

                        if (this.deathrattle) offset += p.ownDRcardsCostMore;

                        offset += p.managespenst;

                        int temp = -(p.startedWithbeschwoerungsportal) * 2;
                        if (retval + temp <= 0) temp = -retval + 1;
                        offset = offset + temp;

                        if (p.mobsplayedThisTurn == 0)
                        {
                            offset -= p.winzigebeschwoererin;
                        }

                        if (this.battlecry)
                        {
                            offset += p.nerubarweblord * 2;
                        }

                        if ((TAG_RACE)this.race == TAG_RACE.MECHANICAL)
                        { //if the number of zauberlehrlings change
                            offset -= p.anzOwnMechwarper;
                        }
                        break;
                    case cardtype.SPELL:
                        if (p.nextSpellThisTurnCost0) return 0;
                        offset += p.ownSpelsCostMore; 
                        if (p.playedPreparation)
                        { //if the number of zauberlehrlings change
                            offset -= 2;
                        }
                        break;
                    case cardtype.WEAPON:
                        offset -= p.blackwaterpirate * 2;
                        if (this.deathrattle) offset += p.ownDRcardsCostMore;
                        break;
                }

                offset -= p.myCardsCostLess;

                switch (this.name)
                {
                    case CardDB.cardName.happyghoul:
                        if (p.ownHero.anzGotHealed > 0) retval = offset;
                        break;
                    case CardDB.cardName.wildmagic:
                        retval = offset;
                        break;
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeapon.Angr;
                        break;
                    case CardDB.cardName.volcanicdrake:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.knightofthewild:
                        retval = retval + offset - p.tempTrigger.ownBeastSummoned;
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count;
                        break;
                    case CardDB.cardName.clockworkgiant:
                        retval = retval + offset - p.enemyAnzCards;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset - p.ownHero.maxHp + p.ownHero.Hp;
                        break;
                    case CardDB.cardName.frostgiant:
                        retval = retval + offset - p.anzUsedOwnHeroPower;
                        break;
                    case CardDB.cardName.arcanegiant:
                        retval = retval + offset - p.spellsplayedSinceRecalc;
                        break;
                    case CardDB.cardName.snowfurygiant:
                        retval = retval + offset - p.ueberladung;
                        break;
                    case CardDB.cardName.kabalcrystalrunner:
                        retval = retval + offset - 2 * p.secretsplayedSinceRecalc;
                        break;
                    case CardDB.cardName.secondratebruiser:
                        retval = retval + offset - ((p.enemyMinions.Count < 3) ? 0 : 2);
                        break;
                    case CardDB.cardName.golemagg:
                        retval = retval + offset - p.ownHero.maxHp + p.ownHero.Hp;
                        break;
                    case CardDB.cardName.volcaniclumberer:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.skycapnkragg:
                        int costBonus = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) costBonus++;
                        }
                        retval = retval + offset - costBonus;
                        break;
                    case CardDB.cardName.everyfinisawesome:
                        int costBonusM = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) costBonusM++;
                        }
                        retval = retval + offset - costBonusM;
                        break;
                    case CardDB.cardName.crush:
                        // cost 4 less if we have a dmged minion
                        bool dmgedminions = false;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.wounded) dmgedminions = true;
                        }
                        if (dmgedminions)
                        {
                            retval = retval + offset - 4;
                        }
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret)
                {
                    if (p.anzOwnCloakedHuntress > 0 || p.nextSecretThisTurnCost0) retval = 0;
                }

                retval = Math.Max(0, retval);

                return retval;
            }

            public int getManaCost(Playfield p, int currentcost)
            {
                int retval = currentcost;
                
                int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

                // CARDS that increase/decrease the manacosts of others ##############################
                switch (this.type)
                {
                    case cardtype.HEROPWR:
                        retval += p.ownHeroPowerCostLessOnce;
                        if (retval < 0) retval = 0;
                        return retval;
                    case cardtype.MOB:
                        
                        if (p.ownMinionsCostMore != p.ownMinionsCostMoreAtStart)
                        {
                            offset += (p.ownMinionsCostMore - p.ownMinionsCostMoreAtStart);
                        }

                        
                        if (this.deathrattle && p.ownDRcardsCostMore != p.ownDRcardsCostMoreAtStart)
                        {
                            offset += (p.ownDRcardsCostMore - p.ownDRcardsCostMoreAtStart);
                        }

                        
                        if (p.managespenst != p.startedWithManagespenst)
                        {
                            offset += (p.managespenst - p.startedWithManagespenst);
                        }

                        
                        if (this.battlecry && p.nerubarweblord != p.startedWithnerubarweblord)
                        {
                            offset += (p.nerubarweblord - p.startedWithnerubarweblord) * 2;
                        }
                        
                        
                        if (p.anzOwnAviana > 0)
                        {
                            retval = 1;
                        }

                        
                        if (p.anzOwnMechwarper != p.anzOwnMechwarperStarted && (TAG_RACE)this.race == TAG_RACE.MECHANICAL)
                        {
                            offset += (p.anzOwnMechwarperStarted - p.anzOwnMechwarper);
                        }

                        
                        if (p.startedWithbeschwoerungsportal != p.beschwoerungsportal)
                        {
                            offset += (p.startedWithbeschwoerungsportal - p.beschwoerungsportal) * 2;
                        }

                        
                        if (p.winzigebeschwoererin != p.startedWithWinzigebeschwoererin && ((p.turnCounter == 0 && p.startedWithMobsPlayedThisTurn == 0) || (p.turnCounter > 0 && p.mobsplayedThisTurn == 0)))
                        {
                            offset += (p.startedWithWinzigebeschwoererin - p.winzigebeschwoererin);
                        }

                        
                        if (p.anzOwnDragonConsort != p.anzOwnDragonConsortStarted && (TAG_RACE)this.race == TAG_RACE.DRAGON)
                        {
                            offset += (p.anzOwnDragonConsortStarted - p.anzOwnDragonConsort) * 2;
                        }
                        break;
                    case cardtype.SPELL:
                        
                        if (p.nextSpellThisTurnCost0) return 0;
                        
                        
                        if (p.ownSpelsCostMoreAtStart != p.ownSpelsCostMore)
                        {
                            offset += p.ownSpelsCostMore - p.ownSpelsCostMoreAtStart;
                        }

                        
                        if (p.playedPreparation)
                        {
                            offset -= 2;
                        }
                        break;
                    case cardtype.WEAPON:
                        
                        if (p.blackwaterpirateStarted != p.blackwaterpirate)
                        {
                            offset += (p.blackwaterpirateStarted - p.blackwaterpirate) * 2;
                        }
                        
                        if (this.deathrattle && p.ownDRcardsCostMore != p.ownDRcardsCostMoreAtStart)
                        {
                            offset += (p.ownDRcardsCostMore - p.ownDRcardsCostMoreAtStart);
                        }
                        break;
                }

                
                if (p.startedWithmyCardsCostLess != p.myCardsCostLess)
                {
                    offset += p.startedWithmyCardsCostLess - p.myCardsCostLess;
                }

                switch (this.name)
                {
                    case CardDB.cardName.volcaniclumberer:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.solemnvigil:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.volcanicdrake:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.knightofthewild:
                        retval = retval + offset - p.tempTrigger.ownBeastSummoned;
                        break;
                    case CardDB.cardName.dragonsbreath:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeapon.Angr + p.ownWeaponAttackStarted; // if weapon attack change we change manacost
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count + p.ownMobsCountStarted + p.enemyMobsCountStarted;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count + p.ownCardsCountStarted;
                        break;
                    case CardDB.cardName.clockworkgiant:
                        retval = retval + offset - p.enemyAnzCards + p.enemyCardsCountStarted;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset - p.ownHeroHpStarted + p.ownHero.Hp;
                        break;
                    case CardDB.cardName.frostgiant:
                        retval = retval + offset - p.anzUsedOwnHeroPower;
                        break;
                    case CardDB.cardName.arcanegiant:
                        retval = retval + offset - p.spellsplayedSinceRecalc;
                        break;
                    case CardDB.cardName.snowfurygiant:
                        retval = retval + offset - p.ueberladung;
                        break;
                    case CardDB.cardName.kabalcrystalrunner:
                        retval = retval + offset - 2 * p.secretsplayedSinceRecalc;
                        break;
                    case CardDB.cardName.secondratebruiser:
                        retval = retval + offset - ((p.enemyMinions.Count < 3) ? 0 : 2) + ((p.enemyMobsCountStarted < 3) ? 0 : 2);
                        break;
                    case CardDB.cardName.golemagg:
                        retval = retval + offset - p.ownHeroHpStarted + p.ownHero.Hp;
                        break;
                    case CardDB.cardName.skycapnkragg:
                        int costBonus = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) costBonus++;
                        }
                        retval = retval + offset - costBonus + p.anzOwnPiratesStarted;
                        break;
                    case CardDB.cardName.everyfinisawesome:
                        int costBonusM = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) costBonusM++;
                        }
                        retval = retval + offset - costBonusM + p.anzOwnMurlocStarted;
                        break;
                    case CardDB.cardName.crush:
                        // cost 4 less if we have a dmged minion
                        bool dmgedminions = false;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.wounded) dmgedminions = true;
                        }
                        if (dmgedminions != p.startedWithDamagedMinions)
                        {
                            if (dmgedminions)
                            {
                                retval = retval + offset - 4;
                            }
                            else
                            {
                                retval = retval + offset + 4;
                            }
                        }
                        break;
                    case CardDB.cardName.happyghoul:
                        if (p.ownHero.anzGotHealed > 0) retval = 0;
                        break;
                    case CardDB.cardName.wildmagic:
                        retval = 0;
                        break;
                    case CardDB.cardName.thingfrombelow:
                        if (p.playactions.Count > 0)
                        {
                            foreach (Action a in p.playactions)
                            {
                                if (a.actionType == actionEnum.playcard)
                                {
                                    switch(a.card.card.name)
                                    {
                                        case cardName.tuskarrtotemic: retval -= p.ownBrannBronzebeard + 1; break;
                                        default:
                                            if ((TAG_RACE)a.card.card.race == TAG_RACE.TOTEM) retval--;
                                            break;
                                    }
                                }
                                else if (a.actionType == actionEnum.useHeroPower)
                                {
                                    switch (a.card.card.name)
                                    {
                                        case cardName.totemiccall: retval--; break;
                                        case cardName.totemicslam: retval--; break;
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret && (p.anzOwnCloakedHuntress > 0 || p.nextSecretThisTurnCost0))
                {
                    retval = 0;
                }
                
                retval = Math.Max(0, retval);
                
                return retval;
            }

            public bool canplayCard(Playfield p, int manacost, bool own)
            {
                if (p.mana < this.getManaCost(p, manacost)) return false;
                if (this.getTargetsForCard(p, false, own).Count == 0) return false;
                return true;
            }

        }

        List<Card> cardlist = new List<Card>();
        Dictionary<cardIDEnum, Card> cardidToCardList = new Dictionary<cardIDEnum, Card>();
        public Card unknownCard;
        public bool installedWrong = false;

        public Card burlyrockjaw;
        private static CardDB instance;

        public static CardDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardDB();
                    //instance.enumCreator();// only call this to get latest cardids
                    // have to do it 2 times (or the kids inside the simcards will not have a simcard :D
                    foreach (Card c in instance.cardlist)
                    {
                        c.sim_card = instance.getSimCard(c.cardIDenum);
                    }
                    instance.setAdditionalData();
                }
                return instance;
            }
        }

        CardDB()
        {
            this.cardlist.Clear();
            this.cardidToCardList.Clear();

            //placeholdercard
            this.cardlist.Add(new Card { name = cardName.unknown, cost = 10 });
            this.unknownCard = cardlist[0];

            using (var stream = File.OpenRead(Settings.Instance.path + "CardDefs.xml"))
            using (var reader = new StreamReader(stream))
            {
                Card c = null;
                string s; int index1 = -1, index2 = -1;
                var sb = new System.Text.StringBuilder();
                while ((s = reader.ReadLine()) != null)
                {
                    if (s.Contains("</Entity>"))
                    {
                        if (c.type == cardtype.ENCHANTMENT)
                        {
                            continue;
                        }
                        if (c.cardIDenum != CardDB.cardIDEnum.None)
                        {
                            this.cardlist.Add(c);
                            if (!this.cardidToCardList.ContainsKey(c.cardIDenum))
                                this.cardidToCardList.Add(c.cardIDenum, c);
                        }
                    }
                    else if ((index1 = s.IndexOf("<Entity CardID=\"")) != -1)
                    {
                        index2 = s.IndexOf("\"", index1 + 16);
                        var temp = s.Substring(index1 + 16, index2 - index1 - 16);

                        c = new Card();
                        c.cardIDenum = this.cardIdstringToEnum(temp);

                        //token:
                        if (temp.EndsWith("t")) c.isToken = true;
                        if (temp.Equals("ds1_whelptoken")) c.isToken = true;
                        if (temp.Equals("CS2_mirror")) c.isToken = true;
                        if (temp.Equals("CS2_050")) c.isToken = true;
                        if (temp.Equals("CS2_052")) c.isToken = true;
                        if (temp.Equals("CS2_051")) c.isToken = true;
                        if (temp.Equals("NEW1_009")) c.isToken = true;
                        if (temp.Equals("CS2_152")) c.isToken = true;
                        if (temp.Equals("CS2_boar")) c.isToken = true;
                        if (temp.Equals("EX1_tk11")) c.isToken = true;
                        if (temp.Equals("EX1_506a")) c.isToken = true;
                        if (temp.Equals("skele21")) c.isToken = true;
                        if (temp.Equals("EX1_tk9")) c.isToken = true;
                        if (temp.Equals("EX1_finkle")) c.isToken = true;
                        if (temp.Equals("EX1_598")) c.isToken = true;
                        if (temp.Equals("EX1_tk34")) c.isToken = true;
                        //if (c.isToken) Helpfunctions.Instance.ErrorLog(temp +" is token");
                    }

                    else if ((index1 = s.IndexOf("<Tag enumID=\"")) != -1)
                    {
                        index2 = s.IndexOf("\"", index1 + 13);
                        var temp = s.Substring(index1 + 13, index2 - index1 - 13);
                        int enumID = int.Parse(temp);

                        int value = 0;
                        index1 = s.IndexOf("value=\"", index2 + 2);
                        if (index1 != -1)
                        {
                            index2 = s.IndexOf("\"", index1 + 7);
                            temp = s.Substring(index1 + 7, index2 - index1 - 7);
                            value = Convert.ToInt32(temp);
                        }

                        switch (enumID)
                        {
                            case   45: c.Health             = value;            break; //health
                            case   47: c.Attack             = value;            break; //attack
                            case   48: c.cost               = value;            break; //manacost
                            case  114: c.Elite              = value == 1;       break; //elite
                            case  185: {
                                    while ((index1 = s.IndexOf("<enUS>")) == -1)
                                    {
                                        s = reader.ReadLine();
                                    }   
                                        index1 += 6;
                                        index2 = s.IndexOf("</enUS>", index1);
                                        temp = s.Substring(index1, index2 - index1);
                                    sb.Clear();
                                    sb.Append(temp);
                                    sb.Replace("&lt;", "");
                                    sb.Replace("b&gt;", "");
                                    sb.Replace("/b&gt;", "");
                                    sb.Replace("'", "");
                                    sb.Replace(" ", "");
                                    sb.Replace(":", "");
                                    sb.Replace(".", "");
                                    sb.Replace("!", "");
                                    sb.Replace("?", "");
                                    sb.Replace("-", "");
                                    sb.Replace("_", "");
                                    sb.Replace(",", "");
                                    sb.Replace("(", "");
                                    sb.Replace(")", "");
                                    sb.Replace("/", "");
                                    sb.Replace("\"", "");
                                    c.name = this.cardNamestringToEnum(sb.ToString().ToLower());
                                    if(c.name == CardDB.cardName.unknown)
                                    {
                                        // try chinese
                                    while ((index1 = s.IndexOf("<zhCN>")) == -1)
                                    {
                                        s= reader.ReadLine();
                                     }
                                     index1 += 6;
                                     index2 = s.IndexOf("</zhCN>",index1);
                                     temp = s.Substring(index1,index2-index1);
                                     sb.Clear();
                                    sb.Append(temp);
                                    sb.Replace("&lt;", "");
                                    sb.Replace("b&gt;", "");
                                    sb.Replace("/b&gt;", "");
                                    sb.Replace("'", "");
                                    sb.Replace(" ", "");
                                    sb.Replace(":", "");
                                    sb.Replace(".", "");
                                    sb.Replace("!", "");
                                    sb.Replace("?", "");
                                    sb.Replace("-", "");
                                    sb.Replace("_", "");
                                    sb.Replace(",", "");
                                    sb.Replace("(", "");
                                    sb.Replace(")", "");
                                    sb.Replace("/", "");
                                    sb.Replace("\"", "");
                                    c.name = this.cardNamestringToEnum(sb.ToString().ToLower());
                                    if(c.name == CardDB.cardName.unknown)
                                    {
                                        ;
                                     } 
                                 }  
 
                             }                                       break; //durability
                            case  187: c.Durability         = value;            break; //CARDNAME
                            case  189: c.windfury           = value == 1;       break; //windfury
                            case  190: c.tank               = value == 1;       break; //taunt
                            case  191: c.Stealth            = value == 1;       break; //stealh
                            case  192: c.spellpowervalue    = value;            break; //spellpower
                            case  194: c.Shield             = value == 1;       break; //divineshield
                            case  197: c.Charge             = value == 1;       break; //charge
                            case  199: c.Class              = value;            break; //Class
                            case  200: c.race               = value;            break; //race
                            case  202: c.type               = (cardtype)value;  break; //cardtype
                            case  203: c.rarity             = value;            break; //rarity
                            case  208: c.Freeze             = value == 1;       break; //freeze
                            case  212: c.Enrage             = value == 1;       break; //enrage
                            case  217: c.deathrattle        = value == 1;       break; //deathrattle
                            case  218: c.battlecry          = value == 1;       break; //battlecry
                            case  219: c.Secret             = value == 1;       break; //secret
                            case  220: c.Combo              = value == 1;       break; //combo
                            case  293: c.Morph              = value == 1;       break; //morph
                            case  296: c.overload        	= value;            break; //overload
                            case  338: c.oneTurnEffect      = value == 1;       break; //OneTurnEffect
                            case  339: c.Silence            = value == 1;       break; //silence
                            case  350: c.AdjacentBuff       = value == 1;       break; //adjacentbuff
                            case  362: c.Aura               = value == 1;       break; //aura
                            case  363: c.poisonous          = value == 1;       break; //poisonous
                            case  403: c.Inspire            = value == 1;       break; //Inspire
                            case  415: c.discover           = value == 1;       break; //discover
                            case  443: c.choice             = value == 1;       break; //choice
                            case  448: c.untouchable        = value == 1;       break; //untouchable
                            case  462: c.Quest              = value == 1;       break; //quest
                            case  685: c.lifesteal          = value == 1;       break; //lifesteal
                            case  791: c.Rush               = value == 1;       break; //RUSH
                            case 1085: c.reborn             = value == 1;       break; //REBORN
                            case 1333: c.outcast             = value == 1;       break; //outcast
                            case 1518: c.dormant             = value == 1;       break; //dormant
                        }
                    }

                    else if ((index1 = s.IndexOf("<PlayRequirement")) != -1)
                    {
                        index1 = s.IndexOf("param=\"");
                        index2 = s.IndexOf("\"", index1 + 7);
                        var temp = s.Substring(index1 + 7, index2 - index1 - 7);
                        int param = temp.Length > 0 ? Convert.ToInt32(temp) : 0;

                        index1 = s.IndexOf("reqID=\"");
                        index2 = s.IndexOf("\"", index1 + 7);
                        temp = s.Substring(index1 + 7, index2 - index1 - 7);
                        int reqID = Convert.ToInt32(temp);
                        c.playrequires.Add((ErrorType2)reqID);

                        if (param > 0)
                        {
                            switch (reqID)
                            {
                                case  8: c.needWithMaxAttackValueOf     = param; continue;
                                case 10: c.needRaceForPlaying           = param; continue;
                                case 12: c.needEmptyPlacesForPlaying    = param; continue;
                                case 19: c.needMinionsCapIfAvailable    = param; continue;
                                case 23: c.needMinNumberOfEnemy         = param; continue;
                                case 41: c.needWithMinAttackValueOf     = param; continue;
                                case 45: c.needMinTotalMinions          = param; continue;
                                case 56: c.needMinOwnMinions            = param; continue;
                                case 59: c.needControlaSecret           = param; continue;
                            }
                        }
                    }
                }
            }

            Helpfunctions.Instance.ErrorLog("CardList:" + cardidToCardList.Count);

            //var sbb = new System.Text.StringBuilder();
            //foreach (var item in cardidToCardList)
            //{
            //    sbb.Append(item.Value.cardIDenum.ToString());
            //    sbb.Append('\t');
            //    sbb.Append(item.Value.cost.ToString());
            //    sbb.Append('\t');
            //    sbb.AppendLine();
            //}

            //File.WriteAllText("test.xml",sbb.ToString());

        }

        public Card getCardData(CardDB.cardName cardname)
        {

            foreach (Card ca in this.cardlist)
            {
                if (ca.name == cardname)
                {
                    return ca;
                }
            }

            return unknownCard;
        }

        public Card getCardDataFromID(cardIDEnum id)
        {
            Card c;
            if (this.cardidToCardList.TryGetValue(id, out c))
                return c;
            return this.unknownCard;
        }

        private void setAdditionalData()
        {
            PenalityManager pen = PenalityManager.Instance;

            foreach (Card c in this.cardlist)
            {
                if (pen.cardDrawBattleCryDatabase.ContainsKey(c.name))
                {
                    c.isCarddraw = pen.cardDrawBattleCryDatabase[c.name];
                }

                if (pen.DamageTargetSpecialDatabase.ContainsKey(c.name))
                {
                    c.damagesTargetWithSpecial = true;
                }

                if (pen.DamageTargetDatabase.ContainsKey(c.name))
                {
                    c.damagesTarget = true;
                }

                if (pen.priorityTargets.ContainsKey(c.name))
                {
                    c.targetPriority = pen.priorityTargets[c.name];
                }

                if (pen.specialMinions.ContainsKey(c.name))
                {
                    c.isSpecialMinion = true;
                }
                
                c.trigers = new List<cardtrigers>();
                Type trigerType = c.sim_card.GetType();
                foreach (string trigerName in Enum.GetNames(typeof(cardtrigers)))
                {
                    try
                    {
	                    foreach (var m in trigerType.GetMethods().Where(e=>e.Name.Equals(trigerName, StringComparison.Ordinal)))
	                    {
							if (m.DeclaringType == trigerType)
								c.trigers.Add((cardtrigers)Enum.Parse(typeof(cardtrigers), trigerName));
						}
                    }
                    catch
                    {
                    }
                }
                if (c.trigers.Count > 10) c.trigers.Clear();
            }
        }

    }

}
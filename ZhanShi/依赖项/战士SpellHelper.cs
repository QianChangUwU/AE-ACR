// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.依赖项.战士SpellHelper
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Define;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Game.ClientState.Objects.Types;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace QianChang.ZhanShi.依赖项
{
  public static class 战士SpellHelper
  {
    public static IPlayerCharacter 自身 => Core.Me;

    public static uint 自身血量 => ((ICharacter) Core.Me).CurrentHp;

    public static uint 自身蓝量 => ((ICharacter) Core.Me).CurrentMp;

    public static float 自身血量百分比 => GameObjectExtension.CurrentHpPercent((ICharacter) Core.Me);

    public static float 自身蓝量百分比 => GameObjectExtension.CurrentMpPercent((ICharacter) Core.Me);

    public static int 队伍成员数量 => PartyHelper.Party.Count;

    public static uint 自身当前等级 => (uint) ((ICharacter) Core.Me).Level;

    public static int 兽魂 => Core.Resolve<JobApi_Warrior>().BeastGauge;

    public static bool 是否在副本中() => Core.Resolve<MemApiCondition>().IsBoundByDuty();

    public static uint 当前地图id => Core.Resolve<MemApiZoneInfo>().GetCurrTerrId();

    public static int 副本人数() => Core.Resolve<MemApiDuty>().DutyMembersNumber();

    public static bool 自身是否在移动() => Core.Resolve<MemApiMove>().IsMoving();

    public static bool 自身是否在读条() => ((IBattleChara) Core.Me).IsCasting;

    public static int 自身周围单位数量(int range) => TargetHelper.GetNearbyEnemyCount(range);

    public static bool 自身存在Buff(uint id)
    {
      return GameObjectExtension.HasAura((IBattleChara) Core.Me, id, 0);
    }

    public static bool 自身存在其中Buff(List<uint> auras, int msLeft = 0)
    {
      return GameObjectExtension.HasAnyAura((IBattleChara) Core.Me, auras, msLeft);
    }

    public static uint 自身命中其中Buff(List<uint> auras, int msLeft = 0)
    {
      return GameObjectExtension.HitAnyAura((IBattleChara) Core.Me, auras, msLeft);
    }

    public static bool 自身存在Buff时间大于(uint id, int time)
    {
      return GameObjectExtension.HasMyAuraWithTimeleft((IBattleChara) Core.Me, id, time);
    }

    public static float 目标血量百分比
    {
      get
      {
        return GameObjectExtension.CurrentHpPercent((ICharacter) GameObjectExtension.GetCurrTarget((IBattleChara) Core.Me));
      }
    }

    public static bool 目标战斗状态(IBattleChara target)
    {
      return GameObjectExtension.InCombat((ICharacter) target);
    }

    public static bool 目标是否可见或在技能范围内(uint actionId)
    {
      bool flag;
      switch (Core.Resolve<MemApiSpell>().GetActionInRangeOrLoS(actionId))
      {
        case 562:
        case 566:
          flag = true;
          break;
        default:
          flag = false;
          break;
      }
      return !flag;
    }

    public static float 目标到自身距离()
    {
      return GameObjectExtension.Distance((IGameObject) GameObjectExtension.GetCurrTarget((IBattleChara) Core.Me), (IGameObject) Core.Me, (DistanceMode) 7);
    }

    public static bool 目标是否在近战距离内()
    {
      return (double) GameObjectExtension.Distance((IGameObject) Core.Me, (IGameObject) GameObjectExtension.GetCurrTarget((IBattleChara) Core.Me), (DistanceMode) 7) > (double) SettingMgr.GetSetting<GeneralSettings>().AttackRange;
    }

    public static float 到自身近战距离(IBattleChara target)
    {
      return GameObjectExtension.Distance((IGameObject) Core.Me, (IGameObject) target, (DistanceMode) 7);
    }

    public static float 到自身距离(IBattleChara target)
    {
      return GameObjectExtension.Distance((IGameObject) Core.Me, (IGameObject) target, (DistanceMode) 7);
    }

    public static bool 目标是否为假人()
    {
      return GameObjectExtension.IsDummy(GameObjectExtension.GetCurrTarget((IBattleChara) Core.Me));
    }

    public static bool 目标的指定buff剩余时间是否大于(uint id, int timeLeft = 0)
    {
      return GameObjectExtension.HasMyAuraWithTimeleft(GameObjectExtension.GetCurrTarget((IBattleChara) Core.Me), id, timeLeft);
    }

    public static bool 指定buff剩余时间是否大于(IBattleChara target, uint id, int timeLeft = 0)
    {
      return GameObjectExtension.HasMyAuraWithTimeleft(target, id, timeLeft);
    }

    public static int 目标的指定BUFF层数(IBattleChara target, uint buff)
    {
      return Core.Resolve<MemApiBuff>().GetStack(target, buff);
    }

    public static bool 目标可选状态(IBattleChara target) => ((IGameObject) target).IsTargetable;

    public static bool 目标是否拥有BUFF(uint id)
    {
      return GameObjectExtension.HasAura(GameObjectExtension.GetCurrTarget((IBattleChara) Core.Me), id, 0);
    }

    public static bool 目标是否拥有其中的BUFF(List<uint> auras, int timeLeft = 0)
    {
      return GameObjectExtension.HasAnyAura(GameObjectExtension.GetCurrTarget((IBattleChara) Core.Me), auras, timeLeft);
    }

    public static bool 是否拥有其中的BUFF(IBattleChara target, List<uint> auras, int timeLeft = 0)
    {
      return GameObjectExtension.HasAnyAura(target, auras, timeLeft);
    }

    public static bool 目标是否存在于DOT黑名单中(IBattleChara r) => DotBlacklistHelper.IsBlackList(r);

    public static bool 队员是否拥有可驱散状态()
    {
      return PartyHelper.CastableAlliesWithin30.Any<IBattleChara>((Func<IBattleChara, bool>) (agent => GameObjectExtension.HasCanDispel(agent) && (double) GameObjectExtension.Distance((IGameObject) agent, (IGameObject) Core.Me, (DistanceMode) 7) <= 30.0));
    }

    public static bool 队员是否拥有BUFF(uint buff)
    {
      return PartyHelper.CastableAlliesWithin30.Any<IBattleChara>((Func<IBattleChara, bool>) (agent => GameObjectExtension.HasAura(agent, buff, 0)));
    }

    public static int 二十米视线内血量低于设定的队员数量(float hp)
    {
      return PartyHelper.CastableAlliesWithin20.Count<IBattleChara>((Func<IBattleChara, bool>) (r => ((ICharacter) r).CurrentHp != 0U && (double) GameObjectExtension.CurrentHpPercent((ICharacter) r) <= (double) hp));
    }

    public static int 三十米视线内血量低于设定的队员数量(float hp)
    {
      return PartyHelper.CastableAlliesWithin30.Count<IBattleChara>((Func<IBattleChara, bool>) (r => ((ICharacter) r).CurrentHp != 0U && (double) GameObjectExtension.CurrentHpPercent((ICharacter) r) <= (double) hp));
    }

    public static int 十十米视线内血量低于设定的队员数量(float hp)
    {
      return PartyHelper.CastableAlliesWithin10.Count<IBattleChara>((Func<IBattleChara, bool>) (r => ((ICharacter) r).CurrentHp != 0U && (double) GameObjectExtension.CurrentHpPercent((ICharacter) r) <= (double) hp));
    }

    public static IBattleChara 自身目标 => GameObjectExtension.GetCurrTarget((IBattleChara) Core.Me);

    public static IBattleChara 自身目标的目标
    {
      get => GameObjectExtension.GetCurrTargetsTarget((IBattleChara) Core.Me);
    }

    public static IBattleChara 获取拥有buff队员(uint buff)
    {
      return PartyHelper.CastableAlliesWithin30.LastOrDefault<IBattleChara>((Func<IBattleChara, bool>) (agent => GameObjectExtension.HasAura(agent, buff, 0)));
    }

    public static IBattleChara 获取血量最低成员()
    {
      return PartyHelper.CastableAlliesWithin30.Count == 0 ? (IBattleChara) Core.Me : PartyHelper.CastableAlliesWithin30.Where<IBattleChara>((Func<IBattleChara, bool>) (r => ((ICharacter) r).CurrentHp > 0U)).MinBy<IBattleChara, float>((Func<IBattleChara, float>) (r => GameObjectExtension.CurrentHpPercent((ICharacter) r)));
    }

    public static IBattleChara 获取血量最低成员_排除buff(uint buffId)
    {
      return PartyHelper.CastableAlliesWithin30.Count == 0 ? (IBattleChara) Core.Me : PartyHelper.CastableAlliesWithin30.Where<IBattleChara>((Func<IBattleChara, bool>) (r => ((ICharacter) r).CurrentHp > 0U && !GameObjectExtension.HasAura(r, buffId, 0))).MinBy<IBattleChara, float>((Func<IBattleChara, float>) (r => GameObjectExtension.CurrentHpPercent((ICharacter) r)));
    }

    public static IBattleChara 获取最低血量T()
    {
      if (PartyHelper.CastableTanks.Count == 0)
        return (IBattleChara) Core.Me;
      return PartyHelper.CastableTanks.Count == 2 && (double) GameObjectExtension.CurrentHpPercent((ICharacter) PartyHelper.CastableTanks[1]) < (double) GameObjectExtension.CurrentHpPercent((ICharacter) PartyHelper.CastableTanks[0]) ? PartyHelper.CastableTanks[1] : PartyHelper.CastableTanks[0];
    }

    public static IBattleChara 获取最低血量T_排除buff(uint buffId)
    {
      if (PartyHelper.CastableTanks.Count == 0)
        return (IBattleChara) Core.Me;
      return PartyHelper.CastableTanks.Count == 2 && (double) GameObjectExtension.CurrentHpPercent((ICharacter) PartyHelper.CastableTanks[1]) < (double) GameObjectExtension.CurrentHpPercent((ICharacter) PartyHelper.CastableTanks[0]) && !GameObjectExtension.HasAura(PartyHelper.CastableTanks[1], buffId, 0) ? PartyHelper.CastableTanks[1] : PartyHelper.CastableTanks[0];
    }

    public static IBattleChara 获取距离最远成员()
    {
      return PartyHelper.CastableAlliesWithin30.Where<IBattleChara>((Func<IBattleChara, bool>) (r => ((ICharacter) r).CurrentHp > 0U)).MaxBy<IBattleChara, float>((Func<IBattleChara, float>) (r => GameObjectExtension.Distance((IGameObject) r, (IGameObject) PartyHelper.CastableAlliesWithin30.FirstOrDefault<IBattleChara>(), (DistanceMode) 7)));
    }

    public static IBattleChara 获取第几号小队列表(int index) => PartyHelper.CastableParty[index - 1];

    public static Spell 获取技能(uint id) => SpellHelper.GetSpell(id);

    public static uint 技能状态码(uint id) => Core.Resolve<MemApiSpell>().GetActionState(id);

    public static Spell 获取会变化的技能(uint id)
    {
      return SpellHelper.GetSpell(Core.Resolve<MemApiSpell>().CheckActionChange(id));
    }

    public static uint 获取会变化的技能id(uint id) => Core.Resolve<MemApiSpell>().CheckActionChange(id);

    public static int 高优先级gcd队列中技能数量() => AI.Instance.BattleData.HighPrioritySlots_GCD.Count;

    public static uint 上一个连击技能() => Core.Resolve<MemApiSpell>().GetLastComboSpellId();

    public static int GCD剩余时间() => GCDHelper.GetGCDCooldown();

    public static bool GCD可用状态() => GCDHelper.CanUseGCD();

    public static uint 上一个gcd技能() => Core.Resolve<MemApiSpellCastSuccess>().LastGcd;

    public static uint 上一个能力技能() => Core.Resolve<MemApiSpellCastSuccess>().LastAbility;

    public static bool 技能是否刚使用过(this uint spellId, int time = 1200)
    {
      return SpellHistoryHelper.RecentlyUsed(SpellHelper.GetSpell(spellId), time);
    }

    public static float 充能层数(this uint spellId) => Core.Resolve<MemApiSpell>().GetCharges(spellId);

    public static long GetTimeStamps()
    {
      return Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds);
    }
  }
}

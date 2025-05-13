// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.起手.战士起手
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.DynamicComplie;
using AEAssist.Helper;
using QianChang.ZhanShi.设置;
using QianChang.ZhanShi.依赖项;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

#nullable disable
namespace QianChang.ZhanShi.起手;
  public class 战士起手 : IOpener
  {
    public int StartCheck()
    {
      if (!战士ACR入口.QT.GetQt("起手"))
        return -100;
      if (战士设置.Instance.当前是否为8人小队 && PartyHelper.CastableParty.Count < 8)
        return -99;
      return AI.Instance.BattleData.CurrBattleTimeInMs > 2000L ? -2 : 0;
    }

    public int StopCheck(int index) => -1;
    
    public List<Action<Slot>> Sequence { get; }

    private static void Step0(Slot slot)
    {
      slot.Add(new Spell(31U, (SpellTargetType) 0));
      slot.Add(new Spell(52U, (SpellTargetType) 1));
    }

    private static void Step1(Slot slot) => slot.Add(new Spell(37U, (SpellTargetType) 0));

    private static void Step2(Slot slot)
    {
      slot.Add(new Spell(45U, (SpellTargetType) 0));
      if (!战士设置.Instance.起手爆发药)
        return;
      slot.Add(Spell.CreatePotion());
    }

    private static void Step3(Slot slot)
    {
      slot.Add(new Spell(7389U, (SpellTargetType) 1));
      slot.Add(new Spell(16465U, (SpellTargetType) 0));
      slot.Add(new Spell(7387U, (SpellTargetType) 0));
    }
    
    public Action CompletedAction { get; set; }

    public void InitCountDown(CountDownHandler countDownHandler)
    {
      if (!战士SpellHelper.自身存在Buff(91U) && 战士ACR入口.QT.GetQt("盾姿"))
        countDownHandler.AddAction(15000, 战士Data.技能.守护);
      if (战士设置.Instance.倒计时大减)
      {
        if (SpellExtension.IsUnlock(36923U))
          countDownHandler.AddAction(战士设置.Instance.倒计时使用大减时间 * 1004, 36923U, (SpellTargetType) 1);
        else
          countDownHandler.AddAction(战士设置.Instance.倒计时使用大减时间 * 1004, 44U, (SpellTargetType) 1);
      }
      if (战士设置.Instance.倒计时铁壁)
        countDownHandler.AddAction(战士设置.Instance.倒计时使用铁壁时间 * 1001, 7531U, (SpellTargetType) 1);
      if (战士设置.Instance.倒计时血气)
        countDownHandler.AddAction(战士设置.Instance.倒计时使用血气时间 * 1002, 25751U, (SpellTargetType) 1);
      if (战士设置.Instance.倒计时摆脱)
        countDownHandler.AddAction(战士设置.Instance.倒计时使用摆脱时间 * 1003, 7388U, (SpellTargetType) 1);
      if (战士设置.Instance.倒计时战栗)
        countDownHandler.AddAction(战士设置.Instance.倒计时使用战栗时间 * 1005, 40U, (SpellTargetType) 1);
      switch (战士设置.Instance.Opener)
      {
        case 0:
          countDownHandler.AddAction(400, 7386U, (SpellTargetType) 0);
          break;
        case 1:
          countDownHandler.AddAction(400, 46U, (SpellTargetType) 0);
          break;
      }
    }
  }

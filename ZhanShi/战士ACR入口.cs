// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.战士ACR入口
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.CombatRoutine.Trigger;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.CombatRoutine.View.JobView.HotkeyResolver;
using QianChang.ZhanShi.能力技;
using QianChang.ZhanShi.起手;
using QianChang.ZhanShi.设置;
using QianChang.ZhanShi.通用;
using QianChang.ZhanShi.依赖项;
using QianChang.ZhanShi.GCD;
using QianChang.ZhanShi.Triggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable enable
namespace QianChang.ZhanShi
{
  public class 战士ACR入口 : IRotationEntry, IDisposable
  {
    public const 
    #nullable disable
    string version = "Beta-0.0.4-fix2";
    public const string UpdateLog = "更新日志：12.17\n- 增加起手自定义战栗\n- 修复了一些奇奇怪怪的bug";
    private List<SlotResolverData> SlotResolvers = new ()
    {
      new (new 战士飞斧(), (SlotMode) 1),
      new (new 战士蛮荒崩裂(), (SlotMode) 1),
      new (new 战士原初的混沌(), (SlotMode) 1),
      new (new 战士基础GCD(), (SlotMode) 1),
      new (new 战士能力技动乱(), (SlotMode) 2),
      new (new 战士能力技原初的解放(), (SlotMode) 2),
      new (new 战士能力技原初的怒震(), (SlotMode) 2),
      new (new 战士能力技战嚎(), (SlotMode) 2),
      new (new 战士能力技猛攻(), (SlotMode) 2)
    };
    
    public string AuthorName { get; set; } = "QianChang";

    public Rotation Build(string settingFolder)
    {
      战士设置.Build(settingFolder);
      this.BuildQT();
      Rotation rotation = new Rotation(this.SlotResolvers)
      {
        TargetJob = (Jobs) 21,
        AcrType = (AcrType) 2,
        MinLevel = 70,
        MaxLevel = 100,
        Description = "有问题请联系QianChang"
      };
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      rotation.AddOpener(战士ACR入口.GetOpener);
      rotation.SetRotationEventHandler(new 战士事件处理());
      rotation.AddTriggerAction(new TriggerAction_QT());
      return rotation;
    }

    private static IOpener GetOpener(uint level)
    {
      int 起手选择 = 战士设置.Instance.起手选择;
      if (true)
        ;
      IOpener opener;
      switch (起手选择)
      {
        case 0:
          if (level >= 70U)
          {
            opener = (IOpener) new 战士起手();
            break;
          }
          goto default;
        case 1:
          if (level == 70U && 战士SpellHelper.当前地图id == 777U)
          {
            opener = (IOpener) new 绝神兵起手();
            break;
          }
          goto default;
        default:
          opener = (IOpener) null;
          break;
      }
      if (true)
        ;
      return opener;
    }
    
    public static JobViewWindow QT { get; private set; }

    public IRotationUI GetRotationUI() => (IRotationUI) 战士ACR入口.QT;

    public void OnDrawSetting() => 战士UI设置.Instance.Draw();

    public void BuildQT()
    {
      战士ACR入口.QT = new JobViewWindow(战士设置.Instance.JobViewSave, new Action(战士设置.Instance.Save), "QianChang");
      战士ACR入口.QT.AddTab("通用", QianChang.ZhanShi.通用.通用.DrawQtGeneral);
      战士ACR入口.QT.AddTab("Dev", Dev.DrawQtGeneral);
      战士ACR入口.QT.AddQt("基础连招", true);
      战士ACR入口.QT.AddQt("战嚎", true);
      战士ACR入口.QT.AddQt("解放", true);
      战士ACR入口.QT.AddQt("位移", true, "超过近战距离/移动时不使用");
      战士ACR入口.QT.AddQt("飞斧", true, "超过近战距离时使用");
      战士ACR入口.QT.AddQt("起手", true, "默认常用起手");
      战士ACR入口.QT.AddQt("盾姿", true, "是否开启盾姿/需要先开启起手");
      战士ACR入口.QT.AddQt("最终爆发", false);
      战士ACR入口.QT.AddQt("优先解放连击", false);
      战士ACR入口.QT.AddQt("优先动乱", false);
      战士ACR入口.QT.AddQt("AOE", false);
      战士ACR入口.QT.AddHotkey("冲刺", (IHotkeyResolver) new HotKeyResolver_疾跑());
      战士ACR入口.QT.AddHotkey("爆发药", (IHotkeyResolver) new HotKeyResolver_Potion());
      战士ACR入口.QT.AddHotkey("极限技", (IHotkeyResolver) new HotKeyResolver_LB());
      战士ACR入口.QT.AddHotkey("摆脱", (IHotkeyResolver) new HotKeyResolver_NormalSpell(7388U, (SpellTargetType) 1, true));
      战士ACR入口.QT.AddHotkey("勇猛2号位", (IHotkeyResolver) new HotKeyResolver_NormalSpell(16464U, (SpellTargetType) 4, true));
      战士ACR入口.QT.AddHotkey("退避2号位", (IHotkeyResolver) new HotKeyResolver_NormalSpell(7537U, (SpellTargetType) 4, true));
      战士ACR入口.QT.AddHotkey("挑衅目标", (IHotkeyResolver) new HotKeyResolver_NormalSpell(7533U, (SpellTargetType) 0, true));
      战士ACR入口.QT.AddHotkey("防击退", (IHotkeyResolver) new HotKeyResolver_NormalSpell(7548U, (SpellTargetType) 1, false));
      战士ACR入口.QT.AddHotkey("无敌", (IHotkeyResolver) new HotKeyResolver_NormalSpell(43U, (SpellTargetType) 1, true));
    }

    public void Dispose()
    {
    }
  }
}

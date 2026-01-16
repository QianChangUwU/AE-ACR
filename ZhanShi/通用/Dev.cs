// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.通用.Dev
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Helper;
using Dalamud.Bindings.ImGui;
using QianChang.ZhanShi.设置;
using System.Runtime.CompilerServices;

#nullable disable
namespace QianChang.ZhanShi.通用
{
  public class Dev
  {
    public static void DrawQtGeneral(JobViewWindow jobViewWindow)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
      interpolatedStringHandler.AppendLiteral("爆发药是否开启：");
      interpolatedStringHandler.AppendFormatted<bool>(战士设置.Instance.起手爆发药);
      ImGui.Text(interpolatedStringHandler.ToStringAndClear());
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
      interpolatedStringHandler.AppendLiteral("gcd是否可用：");
      interpolatedStringHandler.AppendFormatted<bool>(GCDHelper.CanUseGCD());
      ImGui.Text(interpolatedStringHandler.ToStringAndClear());
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
      interpolatedStringHandler.AppendLiteral("gcd剩余时间：");
      interpolatedStringHandler.AppendFormatted<int>(GCDHelper.GetGCDCooldown());
      ImGui.Text(interpolatedStringHandler.ToStringAndClear());
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
      interpolatedStringHandler.AppendLiteral("gcd总时间：");
      interpolatedStringHandler.AppendFormatted<int>(GCDHelper.GetGCDDuration());
      ImGui.Text(interpolatedStringHandler.ToStringAndClear());
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
      interpolatedStringHandler.AppendLiteral("可使用的能力技数量：");
      interpolatedStringHandler.AppendFormatted<bool>(GCDHelper.CanUseOffGcd());
      ImGui.Text(interpolatedStringHandler.ToStringAndClear());
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
      interpolatedStringHandler.AppendLiteral("小队人数：");
      interpolatedStringHandler.AppendFormatted<int>(PartyHelper.CastableParty.Count);
      ImGui.Text(interpolatedStringHandler.ToStringAndClear());
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
      interpolatedStringHandler.AppendLiteral("小队坦克数量：");
      interpolatedStringHandler.AppendFormatted<int>(PartyHelper.CastableTanks.Count);
      ImGui.Text(interpolatedStringHandler.ToStringAndClear());
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
      interpolatedStringHandler.AppendLiteral("小队DPS数量：");
      interpolatedStringHandler.AppendFormatted<int>(PartyHelper.CastableDps.Count);
      ImGui.Text(interpolatedStringHandler.ToStringAndClear());
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
      interpolatedStringHandler.AppendLiteral("小队奶妈数量：");
      interpolatedStringHandler.AppendFormatted<int>(PartyHelper.CastableHealers.Count);
      ImGui.Text(interpolatedStringHandler.ToStringAndClear());
    }
  }
}

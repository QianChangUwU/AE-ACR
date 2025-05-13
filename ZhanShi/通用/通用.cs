// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.通用.通用
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist.CombatRoutine.View.JobView;
using AEAssist.GUI;
using ImGuiNET;
using QianChang.ZhanShi.设置;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#nullable disable
namespace QianChang.ZhanShi.通用
{
  public abstract class 通用
  {
    public static void DrawQtGeneral(JobViewWindow jobViewWindow)
    {
      if (ImGui.CollapsingHeader("   说明"))
      {
        ImGui.Text("更新日志：05.14\n- 修复了一些奇奇怪怪的bug");
        ImGui.Separator();
        ImGui.Text("当前ACR版本：Beta-0.0.4-fix3");
        if (ImGui.Button("反馈问题"))
        {
          string str = "https://qm.qq.com/q/DOX0BQTBZ0";
          try
          {
            Process.Start(new ProcessStartInfo()
            {
              FileName = str,
              UseShellExecute = true
            });
          }
          catch (Exception ex)
          {
            Console.WriteLine("打开浏览器失败：" + ex.Message);
          }
        }
      }
      if (ImGui.CollapsingHeader("更新时间轴"))
      {
        if (ImGui.Button("检查更新"))
          FileVersionUpdater.UpdateFiles();
        ImGui.Text("时间轴问题请联系浅唱/QC");
      }
      if (ImGui.CollapsingHeader("起手选择"))
      {
        ImGui.TextColored(ImGui.ColorConvertU32ToFloat4(4285164287U), "请选择您需要的起手序列");
        ImGui.Separator();
        int 起手选择 = 战士设置.Instance.起手选择;
        if (true)
          ;
        string str;
        switch (起手选择)
        {
          case 0:
            str = "默认起手";
            break;
          case 1:
            str = "绝神兵起手";
            break;
          default:
            str = "";
            break;
        }
        if (true)
          ;
        if (ImGui.BeginCombo("", str))
        {
          if (ImGui.Selectable("默认起手"))
          {
            战士设置.Instance.起手选择 = 0;
            战士设置.Instance.自定义起手 = true;
            战士设置.Instance.Save();
          }
          if (ImGui.Selectable("绝神兵起手"))
          {
            战士设置.Instance.起手选择 = 1;
            战士设置.Instance.自定义起手 = false;
            战士设置.Instance.Save();
          }
          ImGui.EndCombo();
        }
        ImGui.Separator();
        if (ImGui.Checkbox("检测当前是否为8人小队", ref 战士设置.Instance.当前是否为8人小队))
          战士设置.Instance.Save();
        if (ImGui.Checkbox("起手是否使用爆发药", ref 战士设置.Instance.起手爆发药))
          战士设置.Instance.Save();
      }
      if (战士设置.Instance.自定义起手)
      {
        if (ImGui.CollapsingHeader("起手方式选择"))
        {
          ImGui.TextColored(ImGui.ColorConvertU32ToFloat4(4285164287U), "请选择您的起手方式");
          ImGui.Separator();
          int opener = 战士设置.Instance.Opener;
          if (true)
            ;
          string str;
          switch (opener)
          {
            case 0:
              str = "猛攻起手";
              break;
            case 1:
              str = "飞斧起手";
              break;
            default:
              str = "";
              break;
          }
          if (true)
            ;
          if (ImGui.BeginCombo("#仅适用于默认起手", str))
          {
            if (ImGui.Selectable("猛攻起手"))
            {
              战士设置.Instance.Opener = 0;
              战士设置.Instance.Save();
            }
            if (ImGui.Selectable("飞斧起手"))
            {
              战士设置.Instance.Opener = 1;
              战士设置.Instance.Save();
            }
            ImGui.EndCombo();
            ImGui.Separator();
          }
        }
        if (ImGui.CollapsingHeader("倒计时减伤设置"))
        {
          ImGui.PushStyleColor((ImGuiCol) 0, ImGui.ColorConvertU32ToFloat4(4285164287U));
          ImGui.Text("以下内容仅在使用默认起手时生效");
          ImGui.Separator();
          ImGui.PopStyleColor();
          if (战士设置.Instance.倒计时大减)
            ImGui.PushStyleColor((ImGuiCol) 0, ImGui.ColorConvertU32ToFloat4(2431553791U));
          if (ImGuiHelper.ToggleButton("倒计时使用大减", ref 战士设置.Instance.倒计时大减))
            战士设置.Instance.Save();
          if (战士设置.Instance.倒计时大减)
            ImGui.PopStyleColor();
          if (战士设置.Instance.倒计时大减 && ImGui.SliderInt("倒计时剩余多少秒时使用大减", ref 战士设置.Instance.倒计时使用大减时间, 1, 21))
            战士设置.Instance.Save();
          ImGui.Separator();
          if (战士设置.Instance.倒计时血气)
            ImGui.PushStyleColor((ImGuiCol) 0, ImGui.ColorConvertU32ToFloat4(2431553791U));
          if (ImGuiHelper.ToggleButton("倒计时使用血气", ref 战士设置.Instance.倒计时血气))
            战士设置.Instance.Save();
          if (战士设置.Instance.倒计时血气)
            ImGui.PopStyleColor();
          if (战士设置.Instance.倒计时血气 && ImGui.SliderInt("倒计时剩余多少秒时使用血气", ref 战士设置.Instance.倒计时使用血气时间, 1, 21))
            战士设置.Instance.Save();
          ImGui.Separator();
          if (战士设置.Instance.倒计时铁壁)
            ImGui.PushStyleColor((ImGuiCol) 0, ImGui.ColorConvertU32ToFloat4(2431553791U));
          if (ImGuiHelper.ToggleButton("倒计时使用铁壁", ref 战士设置.Instance.倒计时铁壁))
            战士设置.Instance.Save();
          if (战士设置.Instance.倒计时铁壁)
            ImGui.PopStyleColor();
          if (战士设置.Instance.倒计时铁壁 && ImGui.SliderInt("倒计时剩余多少秒时使用铁壁", ref 战士设置.Instance.倒计时使用铁壁时间, 1, 21))
            战士设置.Instance.Save();
          ImGui.Separator();
          if (战士设置.Instance.倒计时摆脱)
            ImGui.PushStyleColor((ImGuiCol) 0, ImGui.ColorConvertU32ToFloat4(2431553791U));
          if (ImGuiHelper.ToggleButton("倒计时使用摆脱", ref 战士设置.Instance.倒计时摆脱))
            战士设置.Instance.Save();
          if (战士设置.Instance.倒计时摆脱)
            ImGui.PopStyleColor();
          if (战士设置.Instance.倒计时摆脱 && ImGui.SliderInt("倒计时剩余多少秒时使用摆脱", ref 战士设置.Instance.倒计时使用摆脱时间, 1, 21))
            战士设置.Instance.Save();
          ImGui.Separator();
          if (战士设置.Instance.倒计时战栗)
            ImGui.PushStyleColor((ImGuiCol) 0, ImGui.ColorConvertU32ToFloat4(2431553791U));
          if (ImGuiHelper.ToggleButton("倒计时使用战栗", ref 战士设置.Instance.倒计时战栗))
            战士设置.Instance.Save();
          if (战士设置.Instance.倒计时战栗)
            ImGui.PopStyleColor();
          if (战士设置.Instance.倒计时战栗 && ImGui.SliderInt("倒计时剩余多少秒时使用战栗", ref 战士设置.Instance.倒计时使用战栗时间, 1, 21))
            战士设置.Instance.Save();
          ImGui.Separator();
        }
      }
      if (ImGui.CollapsingHeader("战斗设置"))
      {
        ref int local = ref 战士设置.Instance.爆发内留猛攻层数;
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
        interpolatedStringHandler.AppendFormatted<int>(战士设置.Instance.爆发内留猛攻层数);
        interpolatedStringHandler.AppendLiteral("层");
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        if (ImGui.SliderInt("保留猛攻层数", ref local, 0, 3, stringAndClear))
          战士设置.Instance.Save();
      }
      if (ImGui.Button("保存设置"))
        战士设置.Instance.Save();
      ImGui.SameLine();
      ImGui.Text("设置完记得保存！");
      try
      {
        if (ImGui.Button("重置设置"))
        {
          战士设置 instance = 战士设置.Instance;
          instance.Opener = 0;
          instance.起手选择 = 0;
          instance.自定义起手 = true;
          instance.倒计时大减 = false;
          instance.倒计时使用大减时间 = 4;
          instance.倒计时血气 = false;
          instance.倒计时使用血气时间 = 5;
          instance.倒计时铁壁 = false;
          instance.倒计时使用铁壁时间 = 10;
          instance.倒计时摆脱 = false;
          instance.倒计时使用摆脱时间 = 10;
          instance.倒计时战栗 = false;
          instance.倒计时使用战栗时间 = 12;
          instance.Save();
        }
        ImGui.SameLine();
        ImGui.Text("起手出问题了？点击这里重置");
      }
      catch (Exception ex)
      {
        Console.WriteLine("绘制UI按钮时出错：" + ex.Message);
      }
    }
  }
}

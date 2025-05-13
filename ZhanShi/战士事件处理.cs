// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.战士事件处理
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using System.Threading.Tasks;

#nullable enable
namespace QianChang.ZhanShi
{
    public class 战士事件处理 : IRotationEventHandler
    {
        public async 
#nullable disable
            Task OnPreCombat() => await Task.CompletedTask;

        public void OnResetBattle()
        {
        }

        public async Task OnNoTarget() => await Task.CompletedTask;

        public void OnSpellCastSuccess(Slot slot, Spell spell)
        {
        }

        public void AfterSpell(Slot slot, Spell spell)
        {
        }

        public void OnBattleUpdate(int currTimeInMs)
        {
        }

        public void OnEnterRotation()
        {
            LogHelper.Print("欢迎最尊贵的您使用Qianchang的战士ACR");
            LogHelper.Print("ACR中内置自定义起手设置，请打开悬浮窗自定义专属于您的起手");
            LogHelper.Print("当前版本：Beta-0.0.4-fix2");
            Core.Resolve<MemApiChatMessage>().Toast2("欢迎最尊贵的您使用Qianchang的战士ACR\nACR中内置自定义起手设置，请打开悬浮窗自定义专属于您的起手", 1, 4000);
        }

        public void OnExitRotation()
        {
        }

        public void OnTerritoryChanged()
        {
        }
    }
}
// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.能力技.战士能力技原初的怒震
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using QianChang.ZhanShi.依赖项;

#nullable disable
namespace QianChang.ZhanShi.能力技
{
    public class 战士能力技原初的怒震 : ISlotResolver
    {
        public int Check()
        {
            if (战士SpellHelper.目标是否在近战距离内())
                return -1;
            if (战士ACR入口.QT.GetQt("优先动乱") && SpellExtension.IsReadyWithCanCast(SpellHelper.GetSpell(7387U)))
                return -99;
            return SpellExtension.IsReadyWithCanCast(SpellHelper.GetSpell(36924U)) ? 0 : -2;
        }

        public void Build(Slot slot) => slot.Add(SpellHelper.GetSpell(36924U));
    }
}
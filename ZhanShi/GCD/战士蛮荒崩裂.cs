// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.GCD.战士蛮荒崩裂
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using QianChang.ZhanShi.依赖项;

#nullable disable
namespace QianChang.ZhanShi.GCD
{
    public class 战士蛮荒崩裂 : ISlotResolver
    {
        public int Check()
        {
            if (战士ACR入口.QT.GetQt("优先动乱") && SpellExtension.IsReadyWithCanCast(SpellHelper.GetSpell(7387U)))
                return -99;
            if (战士SpellHelper.目标是否在近战距离内())
                return -1;
            if (战士SpellHelper.自身是否在移动())
                return -2;
            if (!战士SpellHelper.自身存在Buff(2677U))
                return -3;
            return 战士ACR入口.QT.GetQt("位移") && !战士SpellHelper.自身存在Buff(1177U) && (战士SpellHelper.自身存在Buff(2624U) || 战士SpellHelper.自身存在Buff(3834U)) ? 2 : -4;
        }

        public void Build(Slot slot) => slot.Add(SpellHelper.GetSpell(25753U));
    }
}
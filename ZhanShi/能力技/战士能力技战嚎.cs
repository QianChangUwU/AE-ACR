// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.能力技.战士能力技战嚎
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using QianChang.ZhanShi.依赖项;
using System;

#nullable disable
namespace QianChang.ZhanShi.能力技
{
    public class 战士能力技战嚎 : ISlotResolver
    {
        public int Check()
        {
            if (战士ACR入口.QT.GetQt("最终爆发") && SpellExtension.IsReadyWithCanCast(SpellHelper.GetSpell(52U)) && 战士SpellHelper.兽魂 <= 50)
                return 99;
            if (战士ACR入口.QT.GetQt("优先动乱") && SpellExtension.IsReadyWithCanCast(SpellHelper.GetSpell(7387U)))
                return -99;
            if (战士ACR入口.QT.GetQt("优先解放连击") && 战士SpellHelper.自身存在Buff(1177U))
                return -50;
            if (战士ACR入口.QT.GetQt("战嚎"))
            {
                if (战士SpellHelper.目标是否在近战距离内())
                    return -1;
                if (战士SpellHelper.自身存在Buff(1897U))
                    return -2;
                if (!SpellExtension.IsReadyWithCanCast(SpellHelper.GetSpell(52U)))
                    return -3;
                if (战士SpellHelper.兽魂 > 50)
                    return -4;
                if ((战士SpellHelper.自身存在Buff(1177U) || 战士SpellHelper.自身存在Buff(49U)) && (double) 52U.充能层数() >= 1.0)
                    return 2;
                if (战士SpellHelper.自身存在Buff(2663U) && (double) 52U.充能层数() >= 1.0)
                    return 3;
                TimeSpan cooldown = SpellHelper.GetSpell(7389U).Cooldown;
                if (cooldown.TotalMilliseconds < 15000.0 && (double) 52U.充能层数() > 1.5)
                    return -6;
                cooldown = SpellHelper.GetSpell(7389U).Cooldown;
                if (cooldown.TotalMilliseconds > 30000.0 && (double) 52U.充能层数() >= 1.75)
                    return 4;
            }
            return -7;
        }

        public void Build(Slot slot) => slot.Add(SpellHelper.GetSpell(52U));
    }
}
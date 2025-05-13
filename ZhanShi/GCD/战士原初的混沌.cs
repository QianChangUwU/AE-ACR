// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.GCD.战士原初的混沌
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using Dalamud.Game.ClientState.Objects.Types;
using QianChang.ZhanShi.依赖项;

#nullable disable
namespace QianChang.ZhanShi.GCD
{
    public class 战士原初的混沌 : ISlotResolver
    {
        public int Check()
        {
            if (战士ACR入口.QT.GetQt("优先动乱") && SpellExtension.IsReadyWithCanCast(SpellHelper.GetSpell(7387U)))
                return -99;
            if (战士SpellHelper.目标是否在近战距离内())
                return -1;
            if (!战士SpellHelper.自身存在Buff(1897U))
                return -2;
            if (!战士SpellHelper.自身存在Buff(2677U))
                return -3;
            return 战士SpellHelper.自身存在Buff(1177U) ? -4 : 1;
        }

        private uint GetSpell()
        {
            if (战士ACR入口.QT.GetQt("AOE") && TargetHelper.GetNearbyEnemyCount((IBattleChara) Core.Me, 5, 5) >= 3 && 战士SpellHelper.自身存在Buff(2663U))
                return 16463;
            return 战士SpellHelper.自身存在Buff(2663U) ? 16465U : 0U;
        }

        public void Build(Slot slot)
        {
            Spell spell = SpellHelper.GetSpell(this.GetSpell());
            if (spell == null)
                return;
            slot.Add(spell);
        }
    }
}
// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.GCD.战士基础GCD
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using Dalamud.Game.ClientState.Objects.Types;
using QianChang.ZhanShi.依赖项;

#nullable disable
namespace QianChang.ZhanShi.GCD
{
    public class 战士基础GCD : ISlotResolver
    {
        public int Check() => !战士ACR入口.QT.GetQt("基础连招") || 战士SpellHelper.目标是否在近战距离内() ? -1 : 1;

        private uint GetSpell()
        {
            if (战士ACR入口.QT.GetQt("AOE") && TargetHelper.GetNearbyEnemyCount((IBattleChara) Core.Me, 5, 5) >= 3)
                return 战士SpellHelper.上一个连击技能() == 41U ? 16462U : 41U;
            if ((战士SpellHelper.自身存在Buff(1177U) || 战士SpellHelper.兽魂 >= 50) && 战士ACR入口.QT.GetQt("优先解放连击") || (战士SpellHelper.自身存在Buff(1177U) || 战士SpellHelper.兽魂 >= 50) && 战士SpellHelper.自身存在Buff(2677U))
                return 3549;
            if (Core.Resolve<MemApiSpell>().GetComboTimeLeft().TotalMilliseconds < 2500.0)
                return 31;
            if (战士SpellHelper.上一个连击技能() == 31U)
                return 37;
            if (战士SpellHelper.上一个连击技能() != 37U)
                return 31;
            return 战士SpellHelper.自身存在Buff时间大于(2677U, 15000) ? 42U : 45U;
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
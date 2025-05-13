using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.Helper;
using AEAssist.JobApi;
using QianChang.ZhanShi.依赖项;

namespace QianChang.ZhanShi.起手;

public class 绝神兵起手 : IOpener
{
    public Action CompeltedAction { get; set; }

    public List<Action<Slot>> Sequence { get; } = new()
    {
        Step0,
        Step1,
        Step2,
    };
    //一个Step代表当前GCD技能到下一个GCD技能之前

    private static void Step0(Slot slot)
    {
        slot.Add(new Spell(战士Data.技能.裂石飞环, SpellTargetType.Target));
        //slot.Add(Spell.CreatePotion());
        //上面这一条意思是在该Step中使用爆发药
    }
    private static void Step1(Slot slot)
    {
        slot.Add(new Spell(战士Data.技能.裂石飞环, SpellTargetType.Target));
    }
    private static void Step2(Slot slot)
    {
        slot.Add(new Spell(战士Data.技能.裂石飞环, SpellTargetType.Target));
    }
    //以上内容为倒计时结束后处理

    public void InitCountDown(CountDownHandler countDownHandler)
    {
        if (!战士SpellHelper.自身存在Buff(战士Data.Buff.盾姿))
        {
            countDownHandler.AddAction(15000, 战士Data.技能.守护);
        }
        //判断当前不存在盾姿Buff时，使用技能守护
        countDownHandler.AddAction(10000, 战士Data.技能.原初的解放);
        countDownHandler.AddAction(5000, 战士Data.技能.冲刺);
        countDownHandler.AddAction(3000, 战士Data.技能.复仇);
        countDownHandler.AddAction(500, 战士Data.技能.猛攻, SpellTargetType.Target);
        //以上内容为倒计时期间处理，15000指倒计时15s
    }
}
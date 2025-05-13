// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.设置.战士设置
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Helper;
using AEAssist.IO;
using System;
using System.IO;
using System.Numerics;

#nullable disable
namespace QianChang.ZhanShi.设置
{
    public class 战士设置
    {
        public static 战士设置 Instance;
        private static string path;
        public int Opener = 0;
        public int 起手选择 = 0;
        public bool 自定义起手 = true;
        public bool 倒计时大减 = false;
        public int 倒计时使用大减时间 = 4;
        public bool 倒计时血气 = false;
        public int 倒计时使用血气时间 = 5;
        public bool 倒计时铁壁 = false;
        public int 倒计时使用铁壁时间 = 10;
        public bool 倒计时摆脱 = false;
        public int 倒计时使用摆脱时间 = 10;
        public int 爆发内留猛攻层数 = 1;
        public bool 倒计时战栗 = false;
        public int 倒计时使用战栗时间 = 12;
        public bool 当前是否为8人小队 = false;
        public bool 起手爆发药 = false;
        public readonly JobViewSave JobViewSave = new JobViewSave()
        {
            MainColor = new Vector4(0.184f, 0.533f, 0.631f, 1f)
        };

        public static void Build(string settingPath)
        {
            战士设置.path = Path.Combine(settingPath, "ZhanShi.json");
            if (!File.Exists(战士设置.path))
            {
                战士设置.Instance = new 战士设置();
                战士设置.Instance.Save();
            }
            else
            {
                try
                {
                    战士设置.Instance = JsonHelper.FromJson<战士设置>(File.ReadAllText(战士设置.path));
                }
                catch (Exception ex)
                {
                    战士设置.Instance = new 战士设置();
                    LogHelper.Error(ex.ToString());
                }
            }
        }

        public void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(战士设置.path) ?? string.Empty);
            File.WriteAllText(战士设置.path, JsonHelper.ToJson((object) this));
        }
    }
}
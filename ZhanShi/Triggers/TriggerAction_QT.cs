// Decompiled with JetBrains decompiler
// Type: QianChang.ZhanShi.Triggers.TriggerAction_QT
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist.CombatRoutine.Trigger;
using AEAssist.GUI;
using Dalamud.Bindings.ImGui;
using System;
using System.Diagnostics;

#nullable disable
namespace QianChang.ZhanShi.Triggers
{
    public class TriggerAction_QT : ITriggerAction, ITriggerBase
    {
        public string Key = "";
        public bool Value;
        private int _selectIndex;
        private string[] _qtArray;
        
        public string DisplayName { get; } = "战士/QT";
        public string Remark { get; set; }

        public TriggerAction_QT() => this._qtArray = 战士ACR入口.QT.GetQtArray();

        public bool Draw()
        {
            this._selectIndex = Array.IndexOf<string>(this._qtArray, this.Key);
            if (this._selectIndex == -1)
                this._selectIndex = 0;
            ImGuiHelper.LeftCombo("选择Key", ref this._selectIndex, this._qtArray, 200);
            this.Key = this._qtArray[this._selectIndex];
            ImGui.SameLine();        
            using (new GroupWrapper())
            {
                ImGui.Checkbox("", ref this.Value);
            }
            return true;
        }

        public bool Handle()
        {
            战士ACR入口.QT.SetQt(this.Key, this.Value);
            return true;
        }
    }
}
// Decompiled with JetBrains decompiler
// Type: QianChang.FileVersionUpdater
// Assembly: QianChang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 09133D3D-A1A8-4B8A-96BB-E03FC4C512B3
// Assembly location: C:\Users\BHC\Desktop\1\AEAssistCNVersion\ACR\QianChang\QianChang.dll

using AEAssist;
using AEAssist.Helper;
using System;
using System.IO;
using System.Text.RegularExpressions;

#nullable enable
namespace QianChang
{
  public class FileVersionUpdater
  {
    public static void UpdateFiles()
    {
      string currentDirectory = Share.CurrentDirectory;
      if (string.IsNullOrEmpty(currentDirectory))
      {
        LogHelper.Print("无法获取当前目录");
      }
      else
      {
        string str1 = Path.Combine(new string[6]
        {
          currentDirectory,
          "..",
          "..",
          "ACR",
          "QianChang",
          "Timelines"
        });
        string str2 = Path.Combine(currentDirectory, "..", "..", "Triggerlines");
        string fullPath1 = Path.GetFullPath(str1);
        string fullPath2 = Path.GetFullPath(str2);
        if (!Directory.Exists(fullPath1))
          LogHelper.Print("Timelines 目录不存在: " + fullPath1);
        else if (!Directory.Exists(fullPath2))
        {
          LogHelper.Print("Triggerlines 目录不存在: " + fullPath2);
        }
        else
        {
          try
          {
            foreach (string file in Directory.GetFiles(fullPath1))
            {
              string fileName = Path.GetFileName(file);
              string prefix = FileVersionUpdater.GetPrefix(fileName);
              Decimal versionNumber1 = FileVersionUpdater.GetVersionNumber(fileName);
              string[] files = Directory.GetFiles(fullPath2, prefix + "*");
              if (files.Length == 0)
              {
                string str3 = Path.Combine(fullPath2, fileName);
                File.Copy(file, str3, true);
                LogHelper.Print("检测到您未安装我的时间轴，已自动为您下载安装时间轴: " + fileName);
              }
              else
              {
                bool flag = false;
                foreach (string str4 in files)
                {
                  Decimal versionNumber2 = FileVersionUpdater.GetVersionNumber(Path.GetFileName(str4));
                  if (versionNumber1 > versionNumber2)
                  {
                    foreach (string str5 in files)
                    {
                      try
                      {
                        File.Delete(str5);
                        LogHelper.Print("删除旧时间轴: " + Path.GetFileName(str5));
                      }
                      catch (Exception ex)
                      {
                        LogHelper.Print("删除文件 " + str5 + " 时发生异常: " + ex.Message);
                      }
                    }
                    string str6 = Path.Combine(fullPath2, fileName);
                    File.Copy(file, str6, true);
                    LogHelper.Print("检测到时间轴更新，已下载并更新时间轴: " + fileName);
                    flag = true;
                    break;
                  }
                }
                if (!flag)
                  LogHelper.Print("无需更新: " + prefix);
              }
            }
          }
          catch (Exception ex)
          {
            LogHelper.Print("发生错误: " + ex.Message);
          }
        }
      }
    }

    private static string GetPrefix(string fileName)
    {
      int length = fileName.IndexOf("_V", StringComparison.OrdinalIgnoreCase);
      return length >= 0 ? fileName.Substring(0, length) : Path.GetFileNameWithoutExtension(fileName);
    }

    private static Decimal GetVersionNumber(string fileName)
    {
      Match match = new Regex("_V(\\d+(\\.\\d+)?)", RegexOptions.IgnoreCase).Match(fileName);
      Decimal result;
      return !match.Success || !Decimal.TryParse(match.Groups[1].Value, out result) ? 0M : result;
    }
  }
}

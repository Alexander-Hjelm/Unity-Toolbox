using UnityEngine;
using System;
using System.IO;

public class Logger {

    private long id;
    private string logPath;

    public Logger(long id, string logPath) {
        this.id = id;
        this.logPath = logPath + id.ToString() + ".log";
    }

    public void debug(string inputStr) {
        inputStr = formatInputString(inputStr);
        Debug.Log(inputStr);
    }

    public void warn(string inputStr)
    {
        inputStr = formatInputString(inputStr);
        Debug.LogWarning(inputStr);
    }

    public void error(string inputStr)
    {
        inputStr = formatInputString(inputStr);
        Debug.LogError(inputStr);
    }

    public void log(string inputStr)
    {
        inputStr = formatInputString(inputStr);
        using (StreamWriter sw = File.AppendText(logPath))
        {
            sw.WriteLine(inputStr);
        }
    }

    private string formatInputString(string input) {
        return "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + input;
    }
}
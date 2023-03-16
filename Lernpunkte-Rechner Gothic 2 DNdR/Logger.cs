using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernpunkte_Rechner_Gothic_2_DNdR;

[Serializable]
public class Logger
{
    // messages that got already fetched via proper method call
    public List<String> OldMessages { get; private set; }
    // messages that did not already got fetched via proper method call
    public List<String> NewMessages { get; private set; }
    // will be set to true if message got append
    // will be set to false if new message got fetched via proper method-call
    public Boolean NewMessageArrived { get; private set; }
    public Boolean PrintToConsole { get; set; }

    public Logger(bool printToConsole = false)
    {
        OldMessages = new List<String>();
        NewMessages = new List<String>();
        NewMessageArrived = false;
        PrintToConsole = printToConsole;
    }

    public void Log(String message)
    {
        if (!String.IsNullOrEmpty(message))
        {
            NewMessages.Add(message);
            NewMessageArrived = true;
        }

        if (PrintToConsole)
        {
            Console.WriteLine(message);
        }
    }

    // returns null if latest message already got fetched
    public String FetchNewMessages()
    {
        StringBuilder sb = new StringBuilder();
        foreach (String message in NewMessages) sb.Append(message + "\n");
        OldMessages.AddRange(NewMessages);
        NewMessages.Clear();
        NewMessageArrived = false;
        return sb.ToString();
    }

    // TODO implement
    // creates a file with whole log in folder
    // name of file is time stamp
    public void WriteLogToFolder()
    {

    }

    // If it is needed to print them again
    public String FetchOldMessages()
    {
        StringBuilder sb = new StringBuilder();
        foreach (String message in OldMessages) sb.Append(message + "\n");
        return sb.ToString();
    }
}

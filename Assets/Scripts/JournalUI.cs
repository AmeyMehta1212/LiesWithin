using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class JournalManager : MonoBehaviour
{
    public TMP_Text journalText;
    private List<string> log = new();

    public void LogMessage(string message)
    {
        log.Add(message);
        journalText.text = string.Join("\n", log);
    }
}

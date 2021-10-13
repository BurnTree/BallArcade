using UnityEditor;
using UnityEngine;

public class DataManager : ScriptableSingleton<DataManager>
{
    [Header("some head")]
    public static int score = 0;

    private void InitializeManager()
    {
        
    }

    public static void increaseScore()
    {
        
    }
}

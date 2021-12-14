using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using SFB;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveMap(DataCollect CollectedData)
    {
        var ext = new[] {
        new ExtensionFilter("Vibri map", "vsf")
    };
        var path = StandaloneFileBrowser.SaveFilePanel("Save Map as", "/..", "VibMusic", ext);
        BinaryFormatter formatter = new BinaryFormatter();
            var fileInfo = new FileInfo(path);
            var fileMode = fileInfo.Exists ? FileMode.Truncate : FileMode.Create;
            FileStream stream = new FileStream(path, fileMode);

            SaveData data = new SaveData(CollectedData);
            Debug.Log(data);

            formatter.Serialize(stream, data);
            stream.Close();
    }

    public static SaveData LoadMap()
    {
        var ext = new[] {
        new ExtensionFilter("Vibri map", "vsf")
    };
        string[] path = StandaloneFileBrowser.OpenFilePanel("Open vsf", "/..", ext, false);
        if (path.Length >= 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path[0], FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }
}

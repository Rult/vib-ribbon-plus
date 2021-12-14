using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string path;
    public List<int> obstacles;
    public List<float> speed;
    public List<bool> flat;
    public List<bool> spin;
    public List<bool> slanted;
    public List<bool> hflip;
    public List<bool> vflip;

    public SaveData (DataCollect CollectedData)
    {
        path = CollectedData.path;
        obstacles = CollectedData.obstacles;
        speed = CollectedData.speed;
        flat = CollectedData.flat;
        spin = CollectedData.spin;
        slanted = CollectedData.slanted;
        hflip = CollectedData.hflip;
        vflip = CollectedData.vflip;
    }


}

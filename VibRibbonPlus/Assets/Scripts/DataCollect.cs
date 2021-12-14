using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataCollect : MonoBehaviour
{
    GridCheck gridy;
    int i;
    public int SaveSpace;
    public LevelV2 World;
    public GameObject Mover;
    public MusicSetup Sounds;

    public string path;
    public List<int> obstacles;
    public List<float> speed;
    public List<bool> flat;
    public List<bool> spin;
    public List<bool> slanted;
    public List<bool> hflip;
    public List<bool> vflip;


    public void SaveGame()
    {
        obstacles.Clear();
        speed.Clear();
        flat.Clear();
        spin.Clear();
        slanted.Clear();
        hflip.Clear();
        vflip.Clear();
        Sounds = GameObject.Find("SoundManager").GetComponent<MusicSetup>();
        World = GameObject.Find("WorldRoot").GetComponent<LevelV2>();
        Mover = GameObject.Find("WorldMove");
        World.Loading = true;
        int z = 0;
        while (z < Mover.transform.childCount)
        {
            Mover.transform.GetChild(z).gameObject.SetActive(true);
            z++;
        }
        i = 0;
        while (i <= World.GridAmount - 1)
        {
            gridy = GameObject.Find("Grid" + i).GetComponent<GridCheck>();
            gridy.savemap();
            path = Sounds.MusicPath;
            speed.Add(gridy.speed);
            obstacles.Add(gridy.Obstacle);
            flat.Add(gridy.flat);
            spin.Add(gridy.spin);
            slanted.Add(gridy.slanted);
            hflip.Add(gridy.hflip);
            vflip.Add(gridy.vflip);
            gridy.Obstacle = 0;
            gridy.flat = false;
            gridy.spin = false;
            gridy.slanted = false;
            gridy.hflip = false;
            gridy.vflip = false;
            i++;
        }
        World.Loading = false;
        if (path != null)
        SaveSystem.SaveMap(this);
    }

    public void LoadGame()
    {

        World = GameObject.Find("WorldRoot").GetComponent<LevelV2>();
        Mover = GameObject.Find("WorldMove");
        Sounds = GameObject.Find("SoundManager").GetComponent<MusicSetup>();
        SaveData data = SaveSystem.LoadMap();
        i = 0;
        if (data != null)
        {
            World.Loading = true;
            int z = 0;
            while (z != Mover.transform.childCount)
            {
                Mover.transform.GetChild(z).gameObject.SetActive(true);
                z++;
            }
            GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (GameObject Tile in Tiles)
            {
                Destroy(Tile);
            }
            while (i <= World.GridAmount - 1)
            {
                gridy = GameObject.Find("Grid" + i).GetComponent<GridCheck>();
                gridy.Obstacle = data.obstacles[i];
                gridy.speed = data.speed[i];
                gridy.flat = data.flat[i];
                gridy.spin = data.spin[i];
                gridy.slanted = data.slanted[i];
                gridy.hflip = data.hflip[i];
                gridy.vflip = data.vflip[i];
                gridy.loadmap();
                i++;
            }
            World.Loading = false;
            path = data.path;
            Sounds.MusicPath = data.path;
            Sounds.LoadMusicNoExploror();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EditorHudController : MonoBehaviour
{
    LevelV2 World;
    RectTransform BlockB;
    RectTransform PitB;
    RectTransform FloorB;
    RectTransform SpikesB;
    RectTransform LoopB;
    public int speed;
    public int CameraEffect;
    RectTransform Flat;
    RectTransform Spin;
    RectTransform Slanted;
    RectTransform HFlip;
    RectTransform VFlip;
    RectTransform None;
    RectTransform Save;
    RectTransform Load;
    RectTransform Music;
    public bool OClose;
    public bool CClose;
    public bool MClose;

    Vector2 O1;
    Vector2 O2;
    Vector2 O3;
    Vector2 O4;
    Vector2 O5;
    Vector2 OC;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        CameraEffect = 0;
        OClose = true;
        CClose = true;
        MClose = true;
        World = GameObject.Find("WorldRoot").GetComponent<LevelV2>();
        BlockB = GameObject.Find("Block").GetComponent<RectTransform>();
        PitB = GameObject.Find("Pit").GetComponent<RectTransform>();
        FloorB = GameObject.Find("Floor").GetComponent<RectTransform>();
        SpikesB = GameObject.Find("Spikes").GetComponent<RectTransform>();
        LoopB = GameObject.Find("Loop").GetComponent<RectTransform>();
        Flat = GameObject.Find("Flat").GetComponent<RectTransform>();
        Spin = GameObject.Find("Spin").GetComponent<RectTransform>();
        Slanted = GameObject.Find("Slanted").GetComponent<RectTransform>();
        HFlip = GameObject.Find("HFlip").GetComponent<RectTransform>();
        VFlip = GameObject.Find("VFlip").GetComponent<RectTransform>();
        None = GameObject.Find("None").GetComponent<RectTransform>();
        Save = GameObject.Find("Save Button").GetComponent<RectTransform>();
        Load = GameObject.Find("Load Button").GetComponent<RectTransform>();
        Music = GameObject.Find("LoadMusic").GetComponent<RectTransform>();



        O1 = new Vector2(-175, 35);
        O2 = new Vector2(0, 45);
        O3 = new Vector2(275, 25);
        O4 = new Vector2(0, -35);
        O5 = new Vector2(-195, 5);
        OC = new Vector2(275, -20);
    }

    // Update is called once per frame
    void Update()
    {
        if (!OClose)
        {
            if (World.Spawn == World.Block)
            {
                BlockB.anchoredPosition = Vector2.Lerp(BlockB.anchoredPosition, O1, speed * Time.deltaTime);
                PitB.anchoredPosition = Vector2.Lerp(PitB.anchoredPosition, O2, speed * Time.deltaTime);
                FloorB.anchoredPosition = Vector2.Lerp(FloorB.anchoredPosition, O3, speed * Time.deltaTime);
                SpikesB.anchoredPosition = Vector2.Lerp(SpikesB.anchoredPosition, O4, speed * Time.deltaTime);
                LoopB.anchoredPosition = Vector2.Lerp(LoopB.anchoredPosition, O5, speed * Time.deltaTime);
            }

            if (World.Spawn == World.Pit)
            {
                PitB.anchoredPosition = Vector2.Lerp(PitB.anchoredPosition, O1, speed * Time.deltaTime);
                FloorB.anchoredPosition = Vector2.Lerp(FloorB.anchoredPosition, O2, speed * Time.deltaTime);
                SpikesB.anchoredPosition = Vector2.Lerp(SpikesB.anchoredPosition, O3, speed * Time.deltaTime);
                LoopB.anchoredPosition = Vector2.Lerp(LoopB.anchoredPosition, O4, speed * Time.deltaTime);
                BlockB.anchoredPosition = Vector2.Lerp(BlockB.anchoredPosition, O5, speed * Time.deltaTime);
            }

            if (World.Spawn == World.Floor)
            {
                FloorB.anchoredPosition = Vector2.Lerp(FloorB.anchoredPosition, O1, speed * Time.deltaTime);
                SpikesB.anchoredPosition = Vector2.Lerp(SpikesB.anchoredPosition, O2, speed * Time.deltaTime);
                LoopB.anchoredPosition = Vector2.Lerp(LoopB.anchoredPosition, O3, speed * Time.deltaTime);
                BlockB.anchoredPosition = Vector2.Lerp(BlockB.anchoredPosition, O4, speed * Time.deltaTime);
                PitB.anchoredPosition = Vector2.Lerp(PitB.anchoredPosition, O5, speed * Time.deltaTime);
            }

            if (World.Spawn == World.Spikes)
            {
                SpikesB.anchoredPosition = Vector2.Lerp(SpikesB.anchoredPosition, O1, speed * Time.deltaTime);
                LoopB.anchoredPosition = Vector2.Lerp(LoopB.anchoredPosition, O2, speed * Time.deltaTime);
                BlockB.anchoredPosition = Vector2.Lerp(BlockB.anchoredPosition, O3, speed * Time.deltaTime);
                PitB.anchoredPosition = Vector2.Lerp(PitB.anchoredPosition, O4, speed * Time.deltaTime);
                FloorB.anchoredPosition = Vector2.Lerp(FloorB.anchoredPosition, O5, speed * Time.deltaTime);
            }

            if (World.Spawn == World.Loop)
            {
                LoopB.anchoredPosition = Vector2.Lerp(LoopB.anchoredPosition, O1, speed * Time.deltaTime);
                BlockB.anchoredPosition = Vector2.Lerp(BlockB.anchoredPosition, O2, speed * Time.deltaTime);
                PitB.anchoredPosition = Vector2.Lerp(PitB.anchoredPosition, O3, speed * Time.deltaTime);
                FloorB.anchoredPosition = Vector2.Lerp(FloorB.anchoredPosition, O4, speed * Time.deltaTime);
                SpikesB.anchoredPosition = Vector2.Lerp(SpikesB.anchoredPosition, O5, speed * Time.deltaTime);
            }
        }
        else
        {
            BlockB.anchoredPosition = Vector2.Lerp(BlockB.anchoredPosition, OC, speed * Time.deltaTime);
            PitB.anchoredPosition = Vector2.Lerp(PitB.anchoredPosition, OC, speed * Time.deltaTime);
            FloorB.anchoredPosition = Vector2.Lerp(FloorB.anchoredPosition, OC, speed * Time.deltaTime);
            SpikesB.anchoredPosition = Vector2.Lerp(SpikesB.anchoredPosition, OC, speed * Time.deltaTime);
            LoopB.anchoredPosition = Vector2.Lerp(LoopB.anchoredPosition, OC, speed * Time.deltaTime);
        }

        if (!CClose)
        {
            if (CameraEffect == 0)
            {
                //None.anchoredPosition = Vector2.Lerp(None.anchoredPosition, new Vector2(220, -285), speed * Time.deltaTime);
                Flat.anchoredPosition = Vector2.Lerp(Flat.anchoredPosition, new Vector2(220, -135), speed * Time.deltaTime);
                Spin.anchoredPosition = Vector2.Lerp(Spin.anchoredPosition, new Vector2(50, -35), speed * Time.deltaTime);
                Slanted.anchoredPosition = Vector2.Lerp(Slanted.anchoredPosition, new Vector2(-120, -135), speed * Time.deltaTime);
                HFlip.anchoredPosition = Vector2.Lerp(HFlip.anchoredPosition, new Vector2(-120, -285), speed * Time.deltaTime);
                VFlip.anchoredPosition = Vector2.Lerp(VFlip.anchoredPosition, new Vector2(50, -335), speed * Time.deltaTime);
            }

            if (CameraEffect == 1)
            {
                Flat.anchoredPosition = Vector2.Lerp(Flat.anchoredPosition, new Vector2(220, -285), speed * Time.deltaTime);
                Spin.anchoredPosition = Vector2.Lerp(Spin.anchoredPosition, new Vector2(220, -135), speed * Time.deltaTime);
                Slanted.anchoredPosition = Vector2.Lerp(Slanted.anchoredPosition, new Vector2(50, -35), speed * Time.deltaTime);
                HFlip.anchoredPosition = Vector2.Lerp(HFlip.anchoredPosition, new Vector2(-120, -135), speed * Time.deltaTime);
                VFlip.anchoredPosition = Vector2.Lerp(VFlip.anchoredPosition, new Vector2(-120, -285), speed * Time.deltaTime);
                //None.anchoredPosition = Vector2.Lerp(None.anchoredPosition, new Vector2(50, -335), speed * Time.deltaTime);
            }

            if (CameraEffect == 2)
            {
                Spin.anchoredPosition = Vector2.Lerp(Spin.anchoredPosition, new Vector2(220, -285), speed * Time.deltaTime);
                Slanted.anchoredPosition = Vector2.Lerp(Slanted.anchoredPosition, new Vector2(220, -135), speed * Time.deltaTime);
                HFlip.anchoredPosition = Vector2.Lerp(HFlip.anchoredPosition, new Vector2(50, -35), speed * Time.deltaTime);
                VFlip.anchoredPosition = Vector2.Lerp(VFlip.anchoredPosition, new Vector2(-120, -135), speed * Time.deltaTime);
                //None.anchoredPosition = Vector2.Lerp(None.anchoredPosition, new Vector2(-120, -285), speed * Time.deltaTime);
                Flat.anchoredPosition = Vector2.Lerp(Flat.anchoredPosition, new Vector2(50, -335), speed * Time.deltaTime);
            }

            if (CameraEffect == 3)
            {
                Slanted.anchoredPosition = Vector2.Lerp(Slanted.anchoredPosition, new Vector2(220, -285), speed * Time.deltaTime);
                HFlip.anchoredPosition = Vector2.Lerp(HFlip.anchoredPosition, new Vector2(220, -135), speed * Time.deltaTime);
                VFlip.anchoredPosition = Vector2.Lerp(VFlip.anchoredPosition, new Vector2(50, -35), speed * Time.deltaTime);
                //None.anchoredPosition = Vector2.Lerp(None.anchoredPosition, new Vector2(-120, -135), speed * Time.deltaTime);
                Flat.anchoredPosition = Vector2.Lerp(Flat.anchoredPosition, new Vector2(-120, -285), speed * Time.deltaTime);
                Spin.anchoredPosition = Vector2.Lerp(Spin.anchoredPosition, new Vector2(50, -335), speed * Time.deltaTime);
            }

            if (CameraEffect == 4)
            {
                HFlip.anchoredPosition = Vector2.Lerp(HFlip.anchoredPosition, new Vector2(220, -285), speed * Time.deltaTime);
                VFlip.anchoredPosition = Vector2.Lerp(VFlip.anchoredPosition, new Vector2(220, -135), speed * Time.deltaTime);
                //None.anchoredPosition = Vector2.Lerp(None.anchoredPosition, new Vector2(50, -35), speed * Time.deltaTime);
                Flat.anchoredPosition = Vector2.Lerp(Flat.anchoredPosition, new Vector2(-120, -135), speed * Time.deltaTime);
                Spin.anchoredPosition = Vector2.Lerp(Spin.anchoredPosition, new Vector2(-120, -285), speed * Time.deltaTime);
                Slanted.anchoredPosition = Vector2.Lerp(Slanted.anchoredPosition, new Vector2(50, -335), speed * Time.deltaTime);
            }

            if (CameraEffect == 5)
            {
                VFlip.anchoredPosition = Vector2.Lerp(VFlip.anchoredPosition, new Vector2(220, -285), speed * Time.deltaTime);
                //None.anchoredPosition = Vector2.Lerp(None.anchoredPosition, new Vector2(220, -135), speed * Time.deltaTime);
                Flat.anchoredPosition = Vector2.Lerp(Flat.anchoredPosition, new Vector2(50, -35), speed * Time.deltaTime);
                Spin.anchoredPosition = Vector2.Lerp(Spin.anchoredPosition, new Vector2(-120, -135), speed * Time.deltaTime);
                Slanted.anchoredPosition = Vector2.Lerp(Slanted.anchoredPosition, new Vector2(-120, -285), speed * Time.deltaTime);
                HFlip.anchoredPosition = Vector2.Lerp(HFlip.anchoredPosition, new Vector2(50, -335), speed * Time.deltaTime);
            }
        }
        else
        {
            None.anchoredPosition = Vector2.Lerp(None.anchoredPosition, new Vector2(-120, -135), speed * Time.deltaTime);
            Flat.anchoredPosition = Vector2.Lerp(Flat.anchoredPosition, new Vector2(-120, -135), speed * Time.deltaTime);
            Spin.anchoredPosition = Vector2.Lerp(Spin.anchoredPosition, new Vector2(-120, -135), speed * Time.deltaTime);
            Slanted.anchoredPosition = Vector2.Lerp(Slanted.anchoredPosition, new Vector2(-120, -135), speed * Time.deltaTime);
            HFlip.anchoredPosition = Vector2.Lerp(HFlip.anchoredPosition, new Vector2(-120, -135), speed * Time.deltaTime);
            VFlip.anchoredPosition = Vector2.Lerp(VFlip.anchoredPosition, new Vector2(-120, -135), speed * Time.deltaTime);
        }

        if(!MClose)
        {
            //Save.anchoredPosition = Vector2.Lerp(Save.anchoredPosition, new Vector2(0, 151), speed * Time.deltaTime);
            //Load.anchoredPosition = Vector2.Lerp(Load.anchoredPosition, new Vector2(175, 107), speed * Time.deltaTime);
            Music.anchoredPosition = Vector2.Lerp(Music.anchoredPosition, new Vector2(230, 0), speed * Time.deltaTime);
        }
        else
        {
            Save.anchoredPosition = Vector2.Lerp(Save.anchoredPosition, new Vector2(-200, -120), speed * Time.deltaTime);
            Load.anchoredPosition = Vector2.Lerp(Load.anchoredPosition, new Vector2(-200, -120), speed * Time.deltaTime);
            Music.anchoredPosition = Vector2.Lerp(Music.anchoredPosition, new Vector2(-200, -120), speed * Time.deltaTime);
        }
    }

    public void EffectSet(int set)
    {
        CameraEffect = set;
    }

    public void CloseObstacle()
    {
        if(OClose)
        {
            OClose = false;
            CClose = true;
        }
        else
        {
            OClose = true;
        }
    }

    public void CloseCamera()
    {
        if(CClose)
        {
            CClose = false;
            OClose = true;
        }
        else
        {
            CClose = true;
        }
    }

    public void CloseMap()
    {
        if(MClose)
        {
            MClose = false;
        }
        else
        {
            MClose = true;
        }
    }
}

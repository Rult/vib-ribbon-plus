using System.Collections;
using System.Collections.Generic;
using SFB;
using System.IO;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine;

public class MusicSetup : MonoBehaviour
{
    public AudioSource MiscSounds;
    private AudioSource EditorMusic;
    public AudioSource GameMusic;
    private AudioClip TileSounds;

    public string MusicPath;
    public AudioClip MusicClip;

    private LevelV2 World;
    private GameObject Mover;
    // Start is called before the first frame update
    void Start()
    {
        MiscSounds = GetComponent<AudioSource>();
        EditorMusic = GameObject.Find("Editor Music").GetComponent<AudioSource>();
        GameMusic = GameObject.Find("Game Music").GetComponent<AudioSource>();

        World = GameObject.Find("WorldRoot").GetComponent<LevelV2>();
        Mover = GameObject.Find("WorldMove");
    }

    // Update is called once per frame
    void Update()
    {
        if (World.Playing)
        {
            EditorMusic.Stop();

            if (Mover.transform.position.x <= 0)
            {
                if (!GameMusic.isPlaying)
                {
                    GameMusic.Play();
                }
            }
        }
        else
        {
            GameMusic.Stop();

            if (!EditorMusic.isPlaying)
            {
                EditorMusic.Play();
            }

        }

            string loaded = GameMusic.clip.loadState.ToString();

    }
    public void LoadMusic()
    {
        WWW request = GetMusic();
        if (request != null)
        {
            MusicClip = request.GetAudioClip();
            MusicClip.LoadAudioData();
            GameMusic.clip = MusicClip;
            GameMusic.clip.name = Path.GetFileName(MusicPath.Substring(0, MusicPath.Length - 4));
        }
        else
        {
            Debug.LogError("No Audio Found");
        }
    }

    public WWW GetMusic()
    {
        MusicPath = StandaloneFileBrowser.OpenFilePanel("Switch music with", "", "", false)[0];
        if (MusicPath != null)
        {
            string MusicToLoad = string.Format(MusicPath);
            MusicToLoad = MusicToLoad.Replace('"', ' ');
            WWW request = new WWW(MusicToLoad);
            return request;
        }
        else
        {
            Debug.LogError("No Music Path Found");

            return null;
        }
    }

    public void LoadMusicNoExploror()
    {
        WWW request = GetMusicNoExploror();

        if (request.error == null)
        {
            Debug.LogError("No Audio Found");
        }
        else
        {
            MusicClip = request.GetAudioClip();
            MusicClip.LoadAudioData();
            MusicClip.name = "VibMusic";
            GameMusic.clip.name = Path.GetFileName(MusicPath.Substring(0, MusicPath.Length - 4));
        }
    }
    private WWW GetMusicNoExploror()
    {
        MusicPath = GameObject.Find("SaveGame").GetComponent<DataCollect>().path;
        if (MusicPath == null)
        {
            Debug.LogError("No Music Path Found");

            return null;
        }
        else
        {
            string MusicToLoad = string.Format(MusicPath);
            MusicToLoad = MusicToLoad.Replace('"', ' ');
            WWW request = new WWW(MusicToLoad);
            return request;
        }
    }
}
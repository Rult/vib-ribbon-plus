using System.Collections;
using System.Collections.Generic;
using Discord;
using UnityEngine;

public class DiscordManager : MonoBehaviour
{
    public Discord.Discord discord;
    public Discord.Activity activity;
    public Discord.ActivityManager activityManager;

    public bool Menu;
    public bool Playing;

    private VibriController Vibri;
    private MusicSetup Music;
    private LevelV2 World;

    // Start is called before the first frame update
    public void Start()
    {
        discord = new Discord.Discord(895881457682251796, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);
        activityManager = discord.GetActivityManager();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (discord != null)
        {
            if (Menu)
            {
                activity = new Discord.Activity
                {
                    Details = "In Menus",
                    State = "Main Menu"
                };
            }
            else
            {
                if (GameObject.Find("WorldRoot"))
                {
                    World = GameObject.Find("WorldRoot").GetComponent<LevelV2>();
                    Playing = World.Playing;
                }
                if (Playing)
                {
                    Vibri = GameObject.Find("VibriRoot").GetComponent<VibriController>();
                    Music = GameObject.Find("SoundManager").GetComponent<MusicSetup>();
                    float time = ((Music.GameMusic.time) / Music.GameMusic.clip.length);
                    activity = new Discord.Activity
                    {
                        Details = Vibri.models[Vibri.Life - 1],
                        State = "Now Playing:" + Music.GameMusic.clip.name + " | " + Mathf.Round(time * 100) + "%",
                    };
                }
                else
                {
                    activity = new Discord.Activity
                    {
                        Details = "Generating Map",
                        State = "In Map Maker",
                    };
                }
            }
            activityManager.UpdateActivity(activity, (res) => { });

            discord.RunCallbacks();
        }
    }
}

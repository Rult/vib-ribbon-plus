using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{

    public Discord.Discord discord;
    public Discord.Activity activity;
    private VibriController Vibri;
    private MusicSetup Music;
    private LevelV2 World;
    public bool menu;

    void Start()
    {
        if (!menu)
        {
            Vibri = GameObject.Find("VibriRoot").GetComponent<VibriController>();
            Music = GameObject.Find("SoundManager").GetComponent<MusicSetup>();
            World = GameObject.Find("WorldRoot").GetComponent<LevelV2>();
        }
        discord = new Discord.Discord(872618471316402226, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);

        if (discord != null)
        {
            
           if (menu)
           {
                var activityManager = discord.GetActivityManager();
                activity = new Discord.Activity
                {
                        Details = "In Menus",
                        State = "Main Menu",
                        Timestamps =
                {
                    Start = 0
                }
                    };

                    activityManager.UpdateActivity(activity, (res) => { });
           }
        }
    }

        void Update()
        {
        if (discord != null) 
        {
            var activityManager = discord.GetActivityManager();
            if (World != null && World.Playing) 
            {
                float time = ((Music.GameMusic.time) / Music.GameMusic.clip.length);
                activity = new Discord.Activity
                {
                    Details = Vibri.models[Vibri.Life - 1],
                    State = "Now Playing:" + Music.GameMusic.clip.name + " | " + Mathf.Round(time * 100) + "%",
                    Timestamps =
                {
                    Start = 0
                }
                };
            }
            else
            {
                activity = new Discord.Activity
                {
                    Details = "Generating Map",
                    State = "In Map Maker",
                    Timestamps =
                {
                    Start = 0
                }
                };
            }
            activityManager.UpdateActivity(activity, (res) => { });

            discord.RunCallbacks();
        }
        }

        public void DiscordQuit()
        {
            discord?.Dispose();
        }
}

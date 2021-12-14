using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBar : MonoBehaviour
{
    private LineRenderer bar;
    public GradientColorKey[] gck = {new GradientColorKey(new Color(0,.2f,0),1), new GradientColorKey(Color.yellow,1) };
    public GradientAlphaKey[] gak = { new GradientAlphaKey(1, 1), new GradientAlphaKey(1, 1) };
    public AudioSource Music;
    Gradient grad = new Gradient();
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<LineRenderer>();
        gck[0].time = .9f;
        gck[1].time = 1.0f;
        Music = GameObject.Find("Game Music").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        grad.SetKeys(gck, gak);
        bar.colorGradient = grad;
        bar.colorGradient.colorKeys = gck;
        gck[0].time =  1 - Music.time / Music.clip.length;
        gck[1].time = 1 - Music.time / Music.clip.length + 0.001f;
    }
}

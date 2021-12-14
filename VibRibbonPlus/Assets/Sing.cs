using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sing : MonoBehaviour
{
    AudioSource Music;
    SkinnedMeshRenderer mesh;
    float[] samples;
    // Start is called before the first frame update
    void Start()
    {
        Music = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        mesh = GetComponent<SkinnedMeshRenderer>();
        samples = new float[Music.clip.samples * Music.clip.channels];
        Music.clip.GetData(samples, 0);
        for (int i = 0; i < samples.Length; ++i)
        {
            samples[i] = samples[i] * 0.5f;
        }

        Music.clip.SetData(samples, 0);
        Music.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mesh.SetBlendShapeWeight(0, Mathf.Abs(samples[(int)(Music.time * 10000)] * 300));
        Music.volume = Mathf.Lerp(Music.volume, 1, .5f *Time.deltaTime);
    }
}

using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TileAttribute : MonoBehaviour
{
    public bool Load;
    public float BPM;
    private GameObject World;
    public GameObject MainCamera;
    public GameObject Vibri;
    public AudioSource Audio;
    public AudioClip spawnclip;
    public BoxCollider Collider;
    public bool Beginning;

    // Start is called before the first frame update
    void Start()
    {
        Vibri = GameObject.Find("VibriRoot");
        World = GameObject.Find("WorldRoot");
        Audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        MainCamera = GameObject.Find("Main Camera");
        if(GameObject.Find("Canvas"))
        if (!Load)
        {
            transform.localScale = new Vector3(1, 0, 1);
            StartCoroutine(SpawnEffect());
            if(GameObject.Find("Speed Type"))
            BPM = float.Parse(GameObject.Find("Speed Type").GetComponent<TMP_InputField>().text);
            Audio.PlayOneShot(spawnclip);
            Audio.pitch = Random.Range(.8f, 1.2f);
        }
        if (!Beginning)
        {
            float size = BPM / 800;
            if (size < .15f)
                size = .15f;
            if (size > 1)
                size = 1;
            Collider.size = new Vector3(size, .5f, size);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Beginning && !World.GetComponent<LevelV2>().Playing)
        {
            BPM = GameObject.Find("Grid0").GetComponent<GridCheck>().speed;
            GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            float minDist = Mathf.Infinity;
            foreach (GameObject t in Obstacles)
            {
                float dist = Vector3.Distance(t.transform.position, transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    BPM = t.GetComponent<TileAttribute>().BPM;
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            World.GetComponent<LevelV2>().BPM = BPM;
        }
    }

    IEnumerator SpawnEffect()
    {
        while(transform.localScale != new Vector3(1,1,1))
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 1, 1), 10 * Time.deltaTime);
            yield return new WaitForSeconds(.01f);
        }
    }
}

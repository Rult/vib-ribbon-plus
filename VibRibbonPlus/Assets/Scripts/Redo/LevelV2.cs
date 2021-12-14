using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class LevelV2 : MonoBehaviour
{
    [Header("Obstacle Objects")]
    public GameObject Block;
    public GameObject Pit;
    public GameObject Floor;
    public GameObject Spikes;
    public GameObject Loop;
    public GameObject Spawn;
    public GameObject CamEffect;


    [Header("Other")]
    public GameObject MainCam;
    public GameObject EdiCam;
    public GameObject EdiCanvas;
    public Camera Cam;
    public GameObject Grid;
    public GameObject CamGrid;
    public int GridAmount;
    public float BPM;
    public float speed;
    public bool Playing = false;
    public bool Loading;
    public AudioClip spawnsound;
    public EditorHudController EHUD;
    public bool PlacingCamEnd;
    int Manager;

    public int score;
    TextMeshProUGUI ScoreText;

    public GameObject Mover;
    private GameObject Bar;
    private GameObject Vibri;
    private AudioSource SoundManager;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        GridAmount = 1000;
        Vibri = GameObject.Find("VibriRoot");
        Bar = GameObject.Find("RunningBar");
        Mover = GameObject.Find("WorldMove");
        EdiCanvas = GameObject.Find("Canvas");
        SoundManager = GameObject.Find("SoundManager").GetComponent<MusicSetup>().MiscSounds;
        ScoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        EHUD = GameObject.Find("Canvas").GetComponent<EditorHudController>();
        Loading = false;
        Manager = GameObject.Find("Game Manager").GetComponent<ChangeScene>().RenderDistance;
        int i = 0;
        while (i < GridAmount)
        {
            GameObject gridy;
            gridy = Instantiate(Grid, new Vector3(Mover.transform.position.x + (i * 2), transform.position.y, transform.position.z + 2), Quaternion.identity, Mover.transform);
            gridy.name = "Grid" + i;
            gridy = Instantiate(CamGrid, new Vector3(Mover.transform.position.x + (i * 2), transform.position.y + 5, transform.position.z + 2), Quaternion.identity, Mover.transform);
            gridy.name = "CamGrid" + i;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(quiting());
        }
        if (Playing)
        {
            ScoreText.text = score.ToString();
            MainCam.SetActive(true);
            EdiCam.SetActive(false);
            EdiCanvas.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Playing = false;
            }
            Mover.transform.position -= new Vector3((BPM / 60) * Time.deltaTime, 0, 0);
            Bar.transform.position = new Vector3(Vibri.transform.position.x + .3f, 0, 0);
            Bar.GetComponentInChildren<LineRenderer>().enabled = false;
            Player = Vibri;
        }
        else
        {
            Mover.transform.position = new Vector3(10, 0, 0);
            MainCam.SetActive(false);
            MainCam.GetComponentInParent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            MainCam.GetComponentInParent<Transform>().position = new Vector3(0, 0, 0);
            EdiCanvas.SetActive(true);
            EdiCam.SetActive(true);
            Bar.GetComponentInChildren<LineRenderer>().enabled = true;
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, hit.point, Color.yellow);
                if (!PlacingCamEnd)
                {
                    if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject() && hit.collider.tag == "Grid" && EHUD.CClose && !EHUD.OClose)
                    {
                        Instantiate(Spawn, new Vector3(hit.collider.transform.position.x, 0f, 0f), Quaternion.identity, Mover.transform);
                        score = 0;
                    }
                    if (Input.GetKey(KeyCode.Mouse1) && !EventSystem.current.IsPointerOverGameObject() && hit.collider.tag == "Obstacle" && EHUD.CClose && !EHUD.OClose)
                    {
                        SoundManager.pitch = Random.Range(.5f, .7f);
                        SoundManager.PlayOneShot(spawnsound);
                        Destroy(hit.collider.gameObject);
                        score = 0;
                    }

                    if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject() && hit.collider.tag == "GridCam" && EHUD.OClose && !EHUD.CClose)
                    {
                        Instantiate(CamEffect, new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, 0f), Quaternion.identity, Mover.transform);
                        score = 0;
                    }
                    if (Input.GetKey(KeyCode.Mouse1) && !EventSystem.current.IsPointerOverGameObject() && hit.collider.tag == "CamEffect" && EHUD.OClose && !EHUD.CClose)
                    {
                        SoundManager.pitch = Random.Range(.5f, .7f);
                        SoundManager.PlayOneShot(spawnsound);
                        Destroy(hit.collider.gameObject);
                        score = 0;
                    }
                }
            }
            Player = EdiCam;
        }
    }

    private void FixedUpdate()
    {
        if (!Loading)
        {
            int i = 0;
            while (i < Mover.transform.childCount)
            {
                if (Vector3.Distance(Mover.transform.GetChild(i).transform.position, Player.transform.position) >= Manager)
                {
                    Mover.transform.GetChild(i).gameObject.SetActive(false);
                    if (Mover.transform.GetChild(i).tag == "Obstacle")
                        if (!Mover.transform.GetChild(i).gameObject.GetComponent<TileAttribute>().Beginning)
                            Mover.transform.GetChild(i).gameObject.transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    Mover.transform.GetChild(i).gameObject.SetActive(true);
                }
                i++;
            }
        }
    }

    public void SpawnSet(int Set)
    {
        GameObject[] Obstacles = { Block, Pit, Floor, Spikes, Loop };
        Spawn = Obstacles[Set];
    }


    public void GameStart()
    {
        Playing = true;
        BPM = 120;
    }
    public void Clear()
    {
        EdiCam.transform.position = new Vector3(0, 1, -9);
        Loading = true;
        int i = 0;
        while (i < Mover.transform.childCount)
        {
            Mover.transform.GetChild(i).gameObject.SetActive(true);
            i++;
        }
        GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject Tile in Tiles)
        {
            Destroy(Tile);
        }
        Tiles = GameObject.FindGameObjectsWithTag("CamEffect");
        foreach (GameObject Tile in Tiles)
        {
            Destroy(Tile);
        }
        Loading = false;
    }

    IEnumerator quiting()
    {
        yield return new WaitForSeconds(1);
        if (Input.GetKey(KeyCode.Escape))
        {
            GameObject.Find("Game Manager").GetComponent<ChangeScene>().OpenMainMenu();
        }
    }
}

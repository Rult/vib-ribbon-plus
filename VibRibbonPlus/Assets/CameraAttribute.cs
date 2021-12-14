using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraAttribute : MonoBehaviour
{
    public bool flat;
    public bool flatgo;
    public bool spin;
    public bool spingo;
    public bool slanted;
    public bool slantedgo;
    public bool Hflip;
    public bool Hflipgo;
    public bool Vflip;
    public bool Vflipgo;
    public int zoom;
    public int CameraEffect;
    public bool End;
    public GameObject CameraSpring;
    public GameObject World;
    private bool PlaceEnd;
    public Camera Cam;
    public AudioSource Audio;
    public AudioClip spawnclip;
    public bool Load;
    // Start is called before the first frame update
    void Start()
    {
        CameraEffect = GameObject.Find("Canvas").GetComponent<EditorHudController>().CameraEffect;
        CameraSpring = GameObject.Find("CameraSpring");
        Cam = GameObject.Find("Editor Camera").GetComponent<Camera>();
        World = GameObject.Find("WorldRoot");
        World.GetComponent<LevelV2>().PlacingCamEnd = false;
        PlaceEnd = false;
        Audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        if (!Load)
        {
            if (GameObject.Find("Speed Type"))
            Audio.PlayOneShot(spawnclip);
            Audio.pitch = Random.Range(.8f, 1.2f);
        }

        if (!End)
        {
            if (CameraEffect == 1)
            {
                flat = true;
            }
            else
            {
                flat = false;
            }
            if (CameraEffect == 2)
            {
                spin = true;
            }
            else
            {
                spin = false;
            }
            if (CameraEffect == 3)
            {
                slanted = true;
            }
            else
            {
                slanted = false;
            }
            if (CameraEffect == 4)
            {
                Hflip = true;
            }
            else
            {
                Hflip = false;
            }
            if (CameraEffect == 5)
            {
                Vflip = true;
            }
            else
            {
                Vflip = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlaceEnd)
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject() && hit.collider.tag == "GridCam")
                {
                    transform.GetChild(1).position = hit.collider.transform.position;
                    World.GetComponent<LevelV2>().PlacingCamEnd = false;
                    PlaceEnd = false;
                }
                if (Input.GetKey(KeyCode.Mouse1) && !EventSystem.current.IsPointerOverGameObject())
                {
                    World.GetComponent<LevelV2>().PlacingCamEnd = false;
                    PlaceEnd = false;
                    Destroy(this);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (flat == true)
            {
                CameraSpring.GetComponent<CameraEffects>().flatgo = true;
            }
            if (spin == true)
            {
                CameraSpring.GetComponent<CameraEffects>().spingo = true;
                CameraSpring.GetComponent<CameraEffects>().i = 0;
                CameraSpring.GetComponent<CameraEffects>().i2 = 0;
            }
            if (slanted == true)
            {
                CameraSpring.GetComponent<CameraEffects>().slantedgo = true;
            }
            if (Hflip == true)
            {
                CameraSpring.GetComponent<CameraEffects>().Hflipgo = true;
            }
            if (Vflip == true)
            {
                CameraSpring.GetComponent<CameraEffects>().Vflipgo = true;
            }
        }
    }
}

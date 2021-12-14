using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCheck : MonoBehaviour
{
    private LevelV2 world;
    public GameObject Mover;
    public GameObject Vibri;
    public int SaveSpace;
    public int Obstacle;
    public float speed;
    public bool flat;
    public bool spin;
    public bool slanted;
    public bool hflip;
    public bool vflip;
    public bool cam;

    public GameObject Block;
    public GameObject Pit;
    public GameObject Floor;
    public GameObject Spikes;
    public GameObject Loop;
    public BoxCollider Box;

    public Sprite Flat;
    public Sprite Spin;
    public Sprite Slanted;
    public Sprite HFlip;
    public Sprite VFlip;
    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.Find("WorldRoot").GetComponent<LevelV2>();
        Mover = GameObject.Find("WorldMove");
        SaveSpace -= 5;
        Obstacle = 0;
        speed = 120;
    }

    private void Awake()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(world.Playing)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            //GetComponentInChildren<SpriteRenderer>().enabled = false;
            Vibri = GameObject.Find("VibrRoot");
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            GetComponentInChildren<SpriteRenderer>().enabled = true;
            Vibri = GameObject.Find("Editor Camera");
            if (!cam)
            {
                RaycastHit Hitem;
                if (Physics.Raycast(new Vector3(transform.position.x + 1, transform.position.y , transform.position.z), -transform.TransformDirection(Vector3.forward), out Hitem, 10))
                {
                    if (Hitem.point != null && Hitem.collider.tag == "Obstacle")
                    {
                        Box.enabled = false;
                        Debug.DrawRay(new Vector3(transform.position.x + 1, transform.position.y , transform.position.z), -transform.TransformDirection(Vector3.forward) * Hitem.distance, Color.yellow);
                        GetComponentInChildren<TMPro.TextMeshPro>().text = Hitem.collider.GetComponent<TileAttribute>().BPM.ToString();
                        
                    }
                }
                else
                {
                    Box.enabled = true;
                    GetComponentInChildren<TMPro.TextMeshPro>().text = null;
                }
            }
            else
            {
                RaycastHit Hitem;
                if (Physics.Raycast(new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), -transform.TransformDirection(Vector3.forward), out Hitem, 10))
                {
                    if (Hitem.point != null && Hitem.collider.tag == "CamEffect")
                    {
                        Box.enabled = false;
                        Debug.DrawRay(new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), -transform.TransformDirection(Vector3.forward) * Hitem.distance, Color.yellow);
                        if (Hitem.collider.GetComponent<CameraAttribute>().flat)
                        {
                            GetComponentInChildren<SpriteRenderer>().sprite = Flat;
                        }
                        else
                        if (Hitem.collider.GetComponent<CameraAttribute>().spin)
                        {
                            GetComponentInChildren<SpriteRenderer>().sprite = Spin;
                        }
                        else
                        if (Hitem.collider.GetComponent<CameraAttribute>().slanted)
                        {
                            GetComponentInChildren<SpriteRenderer>().sprite = Slanted;
                        }
                        else
                        if (Hitem.collider.GetComponent<CameraAttribute>().Hflip)
                        {
                            GetComponentInChildren<SpriteRenderer>().sprite = HFlip;
                        }
                        else
                        if (Hitem.collider.GetComponent<CameraAttribute>().Vflip)
                        {
                            GetComponentInChildren<SpriteRenderer>().sprite = VFlip;
                        }
                        else
                            GetComponentInChildren<SpriteRenderer>().sprite = null;
                    }
                }
                else
                {
                    Box.enabled = true;
                    GetComponentInChildren<SpriteRenderer>().sprite = null;
                }
            }
        }
    }

    public void savemap()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.forward), out Hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, -transform.TransformDirection(Vector3.forward) * Hit.distance, Color.yellow);
            if(Hit.distance == Mathf.Infinity)
            {
                Obstacle = 0;
            }
            if(Hit.collider.gameObject.name.Contains("Block"))
            {
                Obstacle = 1;
            }
            if (Hit.collider.gameObject.name.Contains("Pit"))
            {
                Obstacle = 2;
            }
            if (Hit.collider.gameObject.name.Contains("Floor"))
            {
                Obstacle = 3;
            }
            if (Hit.collider.gameObject.name.Contains("Spikes"))
            {
                Obstacle = 4;
            }
            if (Hit.collider.gameObject.name.Contains("Loop"))
            {
                Obstacle = 5;
            }
            speed = Hit.collider.GetComponent<TileAttribute>().BPM;
            flat = Hit.collider.GetComponent<CameraAttribute>().flat;
            spin = Hit.collider.GetComponent<CameraAttribute>().spin;
            slanted = Hit.collider.GetComponent<CameraAttribute>().slanted;
            hflip = Hit.collider.GetComponent<CameraAttribute>().Hflip;
            vflip = Hit.collider.GetComponent<CameraAttribute>().Vflip;
        }
    }

    public void loadmap()
    {
        Mover = GameObject.Find("WorldMove");
        GameObject[] loadedobstacle = { null, Block, Pit, Floor, Spikes, Loop};
        GameObject Loaded;
        if (loadedobstacle[Obstacle] != null)
        {
            Loaded = Instantiate(loadedobstacle[Obstacle], new Vector3(gameObject.transform.position.x, 0f, 0f), Quaternion.identity, Mover.transform);
            Loaded.GetComponent<TileAttribute>().Load = true;
            Loaded.GetComponent<TileAttribute>().BPM = speed;
            Loaded.GetComponent<CameraAttribute>().flat = flat;
            Loaded.GetComponent<CameraAttribute>().spin = spin;
            Loaded.GetComponent<CameraAttribute>().slanted = slanted;
            Loaded.GetComponent<CameraAttribute>().Hflip = hflip;
            Loaded.GetComponent<CameraAttribute>().Vflip = vflip;
        }
        //resets the tile
        Obstacle = 0;
        speed = 120;
        flat = false;
        spin = false;
        slanted = false;
        hflip = false;
        vflip = false;
    }
}

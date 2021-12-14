using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class VibriController : MonoBehaviour
{
    private GameObject VibriModel;
    public string[] models = { "Worm", "Frog", "Vibri", "Queen"};
    private GameObject Worm;
    private GameObject Frog;
    private GameObject Vibri;
    private GameObject Queen;
    private AudioSource VibriSound;
    private bool AnimPlay;
    private GameObject Col;
    public bool shake;
    public bool Touching;
    public bool safe;
    private bool once;

    private GameObject world;
    private int scorecounter;

    public GameObject OBlock;
    public GameObject OPit;
    public GameObject OSpikes;
    public GameObject OLoop;
    public bool SpawnO;

    public int Health;
    public int Life;
    public int XP;

    public AudioClip VibriScream;
    public AudioClip Block;
    public AudioClip Pit;
    public AudioClip Spikes;
    public AudioClip Loop;
    public AudioClip NoObstacle;
    public GameObject Maincam;
    public GameObject EditCam;
    public Material WireFrame;

    private GameObject one;
    private GameObject two;
    private GameObject three;
    private GameObject four;
    private GameObject five;
    private GameObject six;
    private GameObject seven;
    private GameObject eight;
    private GameObject nine;
    private GameObject ten;
    private GameObject eleven;
    private GameObject twelve;
    private GameObject thirteen;
    private GameObject fourteen;
    private GameObject fifthteen;
    private GameObject sixteen;
    private GameObject seventeen;

    // Start is called before the first frame update
    void Start()
    {
        VibriModel = GameObject.FindGameObjectWithTag("Player");
        VibriSound = GameObject.Find("VibriSounds").GetComponent<AudioSource>();
        Worm = GameObject.Find("Worm");
        Frog = GameObject.Find("Frog");
        Vibri = GameObject.Find("Vibri");
        Queen = GameObject.Find("Queen");
        world = GameObject.Find("WorldRoot");
        Maincam = GameObject.Find("Main Camera");
        EditCam = GameObject.Find("Editor Camera");
        Life = 3;
        Health = 10;
        XP = 0;
        shake = false;
        once = true;
        one = GameObject.Find("1");
        two = GameObject.Find("2");
        three = GameObject.Find("3");
        four = GameObject.Find("4");
        five = GameObject.Find("5");
        six = GameObject.Find("6");
        seven = GameObject.Find("7");
        eight = GameObject.Find("8");
        nine = GameObject.Find("9");
        ten = GameObject.Find("10");
        eleven = GameObject.Find("11");
        twelve = GameObject.Find("12");
        thirteen = GameObject.Find("13");
        fourteen = GameObject.Find("14");
        fifthteen = GameObject.Find("15");
        sixteen = GameObject.Find("16");
        seventeen = GameObject.Find("17");
    }

    // Update is called once per frame
    void Update()
    {
            if (Life == 4)
            {
                Queen.SetActive(true);
                Vibri.SetActive(false);
                Frog.SetActive(false);
                Worm.SetActive(false);
            }
            if (Life == 3)
            {
                Queen.SetActive(false);
                Vibri.SetActive(true);
                Frog.SetActive(false);
                Worm.SetActive(false);
            }
            if (Life == 2)
            {
                Queen.SetActive(false);
                Vibri.SetActive(false);
                Frog.SetActive(true);
                Worm.SetActive(false);
            }
            if (Life == 1)
            {
                Queen.SetActive(false);
                Vibri.SetActive(false);
                Frog.SetActive(false);
                Worm.SetActive(true);
            }

        VibriModel = GameObject.Find(models[Life - 1]);


        if (world.GetComponent<LevelV2>().Playing && !SpawnO)
        {


            VibriModel.GetComponent<Animator>().speed = (GameObject.Find("WorldRoot").GetComponent<LevelV2>().BPM / 60) / 2.5f;
            //resets animation
            if (AnimPlay && once)
            {
                once = false;
                StartCoroutine(Delay());
            }

            //Inputs
            if (AnimPlay == false)
            {
                //Block
                if (Input.GetKeyDown(KeyCode.Q) && !AnimPlay)
                {
                    if (Touching == true)
                    {
                        if (Col.name == "Block(Clone)")
                        {
                            safe = true;
                            AnimPlay = true;
                            VibriModel.GetComponent<Animator>().Play("Block");
                            VibriSound.pitch = 1;
                            VibriSound.PlayOneShot(Block);
                        }
                    }
                    else
                    {
                        AnimPlay = true;
                        VibriModel.GetComponent<Animator>().Play("NoBlock");
                        VibriSound.pitch = 1;
                        VibriSound.PlayOneShot(NoObstacle);
                    }
                }
                //Pit
                if (Input.GetKeyDown(KeyCode.W) && !AnimPlay)
                {
                    if (Touching == true)
                    {
                        if (Col.name == "Pit(Clone)")
                        {
                            safe = true;
                            AnimPlay = true;
                            VibriModel.GetComponent<Animator>().Play("Pit");
                            VibriSound.pitch = 1;
                            VibriSound.PlayOneShot(Pit);
                        }
                    }
                    else
                    {
                        AnimPlay = true;
                        VibriModel.GetComponent<Animator>().Play("Pit");
                        VibriSound.pitch = 1;
                        VibriSound.PlayOneShot(NoObstacle);
                    }
                }
                //Spikes
                if (Input.GetKeyDown(KeyCode.O) && !AnimPlay)
                {
                    if (Touching == true)
                    {
                        if (Col.name == "Spikes(Clone)")
                        {
                            safe = true;
                            AnimPlay = true;
                            VibriModel.GetComponent<Animator>().Play("Spikes");
                            VibriSound.pitch = 1;
                            VibriSound.PlayOneShot(Spikes);
                        }
                    }
                    else
                    {
                        AnimPlay = true;
                        VibriModel.GetComponent<Animator>().Play("Spikes");
                        VibriSound.pitch = 1;
                        VibriSound.PlayOneShot(NoObstacle);
                    }
                }
                //Loop
                if (Input.GetKeyDown(KeyCode.P) && !AnimPlay)
                {
                    if (Touching == true)
                    {
                        if (Col.name == "Loop(Clone)")
                        {
                            safe = true;
                            AnimPlay = true;
                            VibriModel.GetComponent<Animator>().Play("Loop");
                            VibriSound.pitch = 1;
                            VibriSound.PlayOneShot(Loop);
                        }
                    }
                    else
                    {
                        AnimPlay = true;
                        VibriModel.GetComponent<Animator>().Play("NoLoop");
                        VibriSound.pitch = 1;
                        VibriSound.PlayOneShot(NoObstacle);
                    }
                }
            }
        }
        //Spawn Obstacles
        if (world.GetComponent<LevelV2>().Playing && SpawnO)
        {
            safe = true;
            VibriModel.GetComponent<Animator>().speed = (GameObject.Find("WorldRoot").GetComponent<LevelV2>().BPM / 60) / 2.5f;
            //resets animation
            if (AnimPlay && once)
            {
                once = false;
                StartCoroutine(Delay());
            }
            //Inputs
            if (!AnimPlay)
            {
                //Block
                if (Input.GetKeyDown(KeyCode.Q) && !AnimPlay)
                {
                    Instantiate(OBlock, new Vector3(transform.position.x + .4f, transform.position.y, transform.position.z), Quaternion.identity, world.GetComponent<LevelV2>().Mover.transform);
                    safe = true;
                    AnimPlay = true;
                    VibriModel.GetComponent<Animator>().Play("Block");
                    VibriSound.pitch = 1;
                    VibriSound.PlayOneShot(Block);
                }
                //Pit
                if (Input.GetKeyDown(KeyCode.W) && !AnimPlay)
                {
                            safe = true;
                            AnimPlay = true;
                    Instantiate(OPit, new Vector3(transform.position.x + .4f, transform.position.y, transform.position.z), Quaternion.identity, world.GetComponent<LevelV2>().Mover.transform);
                    VibriModel.GetComponent<Animator>().Play("Pit");
                            VibriSound.pitch = 1;
                            VibriSound.PlayOneShot(Pit);
                }
                //Spikes
                if (Input.GetKeyDown(KeyCode.O) && !AnimPlay)
                {
                    Instantiate(OSpikes, new Vector3(transform.position.x + .4f, transform.position.y, transform.position.z), Quaternion.identity, world.GetComponent<LevelV2>().Mover.transform);
                    safe = true;
                            AnimPlay = true;
                    VibriModel.GetComponent<Animator>().Play("Spikes");
                            VibriSound.pitch = 1;
                            VibriSound.PlayOneShot(Spikes);
                }
                //Loop
                if (Input.GetKeyDown(KeyCode.P) && !AnimPlay)
                {
                    Instantiate(OLoop, new Vector3(transform.position.x + .4f, transform.position.y, transform.position.z), Quaternion.identity, world.GetComponent<LevelV2>().Mover.transform);
                    safe = true;
                            AnimPlay = true;
                    VibriModel.GetComponent<Animator>().Play("Loop");
                            VibriSound.pitch = 1;
                            VibriSound.PlayOneShot(Loop);
                }
            }
        }
        

        if(!world.GetComponent<LevelV2>().Playing)
        {
            Health = 10;
            Life = 3;
            XP = 0;
            scorecounter = 3;
            world.GetComponent<LevelV2>().score = 0;
            if (GameObject.Find("Toggle"))
            {
                SpawnO = GameObject.Find("Toggle").GetComponent<Toggle>().isOn;
            }
        }

        if (!world.GetComponent<LevelV2>().Playing)
        {
            float distance = Vector3.Distance(EditCam.transform.position, gameObject.transform.position) / 29.1f;
            WireFrame.SetFloat("_WireframeVal", distance / 2);
        }
        else
        {
            float distance = Vector3.Distance(Maincam.transform.position, gameObject.transform.position) / 29.1f;
            WireFrame.SetFloat("_WireframeVal", distance / 2);
        }

        if (XP >= 1)
        {
            one.SetActive(true);
        }
        else
        {
            one.SetActive(false);
        }
        if (XP >= 2)
        {
            two.SetActive(true);
        }
        else
        {
            two.SetActive(false);
        }
        if (XP >= 3)
        {
            three.SetActive(true);
        }
        else
        {
            three.SetActive(false);
        }
        if (XP >= 4)
        {
            four.SetActive(true);
        }
        else
        {
            four.SetActive(false);
        }
        if (XP >= 5)
        {
            five.SetActive(true);
        }
        else
        {
            five.SetActive(false);
        }
        if (XP >= 6)
        {
            six.SetActive(true);
        }
        else
        {
            six.SetActive(false);
        }
        if (XP >= 7)
        {
            seven.SetActive(true);
        }
        else
        {
            seven.SetActive(false);
        }
        if (XP >= 8)
        {
            eight.SetActive(true);
        }
        else
        {
            eight.SetActive(false);
        }
        if (XP >= 9)
        {
            nine.SetActive(true);
        }
        else
        {
            nine.SetActive(false);
        }
        if (XP >= 10)
        {
            ten.SetActive(true);
        }
        else
        {
            ten.SetActive(false);
        }
        if (XP >= 11)
        {
            eleven.SetActive(true);
        }
        else
        {
            eleven.SetActive(false);
        }
        if (XP >= 12)
        {
            twelve.SetActive(true);
        }
        else
        {
            twelve.SetActive(false);
        }
        if (XP >= 13)
        {
            thirteen.SetActive(true);
        }
        else
        {
            thirteen.SetActive(false);
        }
        if (XP >= 14)
        {
            fourteen.SetActive(true);
        }
        else
        {
            fourteen.SetActive(false);
        }
        if (XP >= 15)
        {
            fifthteen.SetActive(true);
        }
        else
        {
            fifthteen.SetActive(false);
        }
        if (XP >= 16)
        {
            sixteen.SetActive(true);
        }
        else
        {
            sixteen.SetActive(false);
        }
        if (XP >= 17)
        {
            seventeen.SetActive(true);
        }
        else
        {
            seventeen.SetActive(false);
        }
    }

    private void Hurt()
    {
        //Do Damage
        Health -= 1;
        XP = 0;
        scorecounter = 1;
        shake = true;
        VibriSound.pitch = Random.Range(1f, 1.2f);
        VibriSound.PlayOneShot(VibriScream);
        //Check if form should change
        if (Health <= 0)
        {
            Life--;
            Health = 10;
            XP = 0;
        }
        //Is Killed?
        if(Life <= 0)
        {
            GameObject.Find("WorldRoot").GetComponent<LevelV2>().Playing = false;
            Life = 3;
            Health = 10;
            XP = 0;
        }
    }

    private void Didit()
    {
        XP += 1;
        world.GetComponent<LevelV2>().score += scorecounter;
        scorecounter++;

        if (Life >= 4)
        {
            Life = 4;
            Health = 1;
            XP = 0;
        }

        if (XP >= 18)
        {
            Life++;
            if (Life >= 4)
            {
                Life = 4;
                Health = 1;
                XP = 0;
            }
            else
            {
                Health = 10;
                XP = 0;
            }
        }
    }

    //Gets collided object
    private void OnTriggerEnter(Collider other)
    {
        Col = other.gameObject;
        if (!Col.name.Contains("Floor") && Col.tag == "Obstacle")
        {
            Touching = true;
            safe = false;
        }
    }

    //Checks if did obstacle
    private void OnTriggerExit(Collider other)
    {
        if (Touching == true)
        {
            Touching = false;
            if (safe == false)
            {
                Hurt();
            }
            else
            {
                Didit();
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(.5f / (GameObject.Find("WorldRoot").GetComponent<LevelV2>().BPM / 60));
        AnimPlay = false;
        once = true;
    }

}

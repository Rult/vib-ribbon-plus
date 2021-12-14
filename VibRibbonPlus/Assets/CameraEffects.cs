using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public bool flat;
    public bool flatgo;
    public bool spin;
    public bool spingo;
    public Vector3[] rot = { new Vector3(0, 0, 0), new Vector3(35, 90, 0), new Vector3(35, 150, 0), new Vector3(20, 270, 0) };
    public Vector3[] dest = { new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(0, 2, 2), new Vector3(0, 0, 0) };
    public bool slanted;
    public bool slantedgo;
    public bool Hflip;
    public bool Hflipgo;
    public bool Vflip;
    public bool Vflipgo;
    public int zoom;
    public Vector3 prevrot;
    public Vector3 prevdest;
    public int i = 0;
    public int i2 = 0;
    public float Spincount = 0;
    public float Flipcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flatgo == true)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, 0), 1 * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, zoom), 1 * Time.deltaTime);
        }
        if (transform.eulerAngles == new Vector3(0, 0, 0))
        {
            flatgo = false;
        }

        if (spingo == true)
        {
            if (i == 0)
            {
                prevrot = transform.eulerAngles;
                prevdest = transform.position;
                i = 1;
            }
            if (i2 <= dest.Length && i2 <= rot.Length)
            {
                transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
                if (Spincount < 240)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), 3 * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, prevdest, 3 * Time.deltaTime);
                }
                Spincount += 60f * Time.deltaTime;
            }
            if (Spincount >= 360)
            {
                spingo = false;
                Spincount = 0;
            }
        }
        if (slantedgo == true)
        {
            transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, new Vector3(0, 40, 0), 20 * Time.deltaTime);
        }
        if (transform.eulerAngles == new Vector3(0, 40, 0))
        {
            slantedgo = false;
        }
        if (Hflipgo == true)
        {
            transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z), 60 * Time.deltaTime);
            Flipcount += 60f * Time.deltaTime;
        }
        if (Flipcount >= 180f)
        {
            Hflipgo = false;
            Flipcount = 0;
        }
        if (Vflipgo == true)
        {
            transform.Rotate(new Vector3(180, 0, 0), 60 * Time.deltaTime);
            Flipcount += 60f * Time.deltaTime;
        }
        if (Flipcount >= 180f)
        {
            Vflipgo = false;
            Flipcount = 0;
        }
    }
}

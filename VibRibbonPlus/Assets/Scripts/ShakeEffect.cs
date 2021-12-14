using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public GameObject Maincam;
    public GameObject EditCam;
    public float shake;
    public Vector3[] ogpoints;
    public int points;
    public LineRenderer Line;
    private VibriController vibri;
    public Material WireFrame;
    public bool useHealth;
    int i = 0;
    public bool go;
    // Start is called before the first frame update
    void Start()
    {
        vibri = GameObject.Find("VibriRoot").GetComponent<VibriController>();
        points = GetComponent<LineRenderer>().positionCount;
        i = 0;
        go = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (go)
        {
            if (useHealth)
            {
                if (vibri.Life >= 4)
                {
                    shake = 0;
                }
                else
                {
                    shake = 10.7f - vibri.Health;
                    shake /= 100;
                }
            }
            if (i == Random.Range(0, points + 1))
            {
                Line.SetPositions(ogpoints);
            }
        }
            Line.SetPosition(i, new Vector3(Line.GetPosition(i).x + shake * Random.Range(-1, 2), Line.GetPosition(i).y + shake * Random.Range(-1, 2), Line.GetPosition(i).z + shake * Random.Range(-1, 2)));
            i++;
            if (i >= points)
            {
                i = 0;
            }
        if(vibri.shake)
        {
            if (useHealth)
            {
                go = false;
                StartCoroutine(Spark());
            }
        }
        if(!GameObject.Find("WorldRoot").GetComponent<LevelV2>().Playing)
        {
            EditCam = GameObject.Find("Editor Camera");
            go = true;
            if (EditCam != null)
            {
                float distance = Vector3.Distance(EditCam.transform.position, transform.position) / 29.1f;
                Line.SetWidth(distance / 10, distance / 10);
            }
        }
        else
        {
            Maincam = GameObject.Find("Main Camera");
            if (Maincam != null)
            {
                float distance = Vector3.Distance(Maincam.transform.position, transform.position) / 29.1f;
                Line.SetWidth(distance / 10, distance / 10);
            }
        }
    }

    private IEnumerator Spark()
    {
        go = false;
            shake = .2f;
        yield return new WaitForEndOfFrame();
        vibri.shake = false;
        Line.SetPositions(ogpoints);
        yield return new WaitForSeconds(1 / (GameObject.Find("WorldRoot").GetComponent<LevelV2>().BPM / 60));
        go = true;
    }

}

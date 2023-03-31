using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionWayPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Image img;
    public Transform target;
    public Text meter;
    public GameObject portal;
    public int checker;

    // Update is called once per frame
    void Start()
    {
        //portal =  GameObject.FindGameObjectWithTag("portal").GetComponent<Button>();
    }
    void Update()
    {
        float minX = img.GetPixelAdjustedRect().width /2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height /2;
        float maxY = Screen.width - minY;
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

        if(Vector3.Dot((target.position - transform.position), transform.forward)<0)
        {
            //Target is behind the player
            if(pos.x < Screen.width/2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x,minX,maxX);
        pos.y = Mathf.Clamp(pos.y,minY,maxY);

        img.transform.position = pos;
        checker= ((int)Vector3.Distance(target.position , transform.position));
        if(checker<5)
        {
           portal.SetActive(true);
        }
        else
        {
            portal.SetActive(false);
        }
        // if(Input.GetKeyDown(KeyCode.D))
        // {
        //     portal.SetActive(false);
        // }
        meter.text = ((int)Vector3.Distance(target.position , transform.position)).ToString() + "m";
    }
}

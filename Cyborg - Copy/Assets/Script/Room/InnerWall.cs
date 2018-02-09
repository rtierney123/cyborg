using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerWall : MonoBehaviour {
    public GameObject innerwall;
    public string wallname;
    public Vector2 pt1;
    public Vector2 pt2;
    public Vector2 doorpt1;
    public Vector2 doorpt2;
    private Vector2 pos;
    private float doorpos1;
    private float doorpos2;
	// Use this for initialization
	void Start () {
        Transform wallholder= new GameObject(wallname).transform;
      
        if (pt1.x == pt2.x)
        {
            doorpos1 = doorpt1.y;
            doorpos2 = doorpt2.y;
            for (float i = pt1.y; i < pt2.y - pt1.y; i++)
            {
                print("i:" + i);
                print("pos1: " + doorpos1);
                print("pos2: " + doorpos2);
                if (!((i > doorpos1) && (i < doorpos2)))
                {
                    print(i);
                    GameObject instancex = Instantiate(innerwall, new Vector3(pt1.x, i, 0f), Quaternion.identity);
                    instancex.transform.SetParent(wallholder);
                }
            }
        }
        if (pt1.y == pt2.y)
        {
            doorpos1 = doorpt1.x;
            doorpos2 = doorpt2.x;
            for (float n = pt1.x; n < pt2.x - pt1.x; n++)
            {
                GameObject instancey = Instantiate(innerwall, new Vector3(pt1.y, n, 0f), Quaternion.identity);
                instancey.transform.SetParent(wallholder);
            }
        }
    }
   
	
	
}

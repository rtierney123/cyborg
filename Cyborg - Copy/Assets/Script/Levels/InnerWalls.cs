using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerWalls : MonoBehaviour {
    public GameObject[] wallsprites;
    public Vector2 point1;
    public Vector2 point2;
    public void MakeInnerWalls()
    {
        GameObject wallsprite = wallsprites[0];
        if (point1.x == point2.x)
        {
            float x = point1.x;
            for (float y = point1.y; y < point2.y; y++)
            {
                GameObject create = Instantiate(wallsprite, new Vector3(x, y, 0f), Quaternion.identity);
            }
        }
        if (point1.y == point2.y)
        {
            float y = point1.y;
            for (float x = point1.x; x < point2.x; x++)
            {
                GameObject create = Instantiate(wallsprite, new Vector3(x, y, 0f), Quaternion.identity);
            }
        }

    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Room : MonoBehaviour {

    public int leftx;
    public int rightx;
    public int topy;
    public int bottomy;
    public bool spawnPoint;
    public string roomName;
    public int roomNum;
    
    private DoorContainer[] doors;
    private int incX;
    private int incY;

    public GameObject[] floorTiles;
    public GameObject[] outerTiles;
    public GameObject player;
    public GameObject tech_basicEnemy;
    private Transform boardHolder;

    private struct Wall
    {
        public readonly string side;
        public readonly int n;

        public Wall(string side, int n)
        {
            this.side = side;
            this.n = n;
        }
    }

    //creates arrays to set up board
    public void BoardSetup()
    {
        incX = Math.Sign(rightx - leftx);
        incY = Math.Sign(topy - bottomy);
        // print(GetComponents<GameObject>());  // Caution: breaks shit
        //run through doorContainers and place doorcontainer objects from each door gameobject into doors
        doors = transform.GetComponentsInChildren<DoorContainer>();

        if (incX == 0 || incY == 0)
        {
            throw new Exception(string.Format("rightx({0}) == leftx({1}) or topy({2}) == bottomy({3})", rightx, leftx, topy, bottomy));
        }

        /*
        side = new string[1];
        side[0] = "rt";
        doorRanges = new int[1][];
        doorRanges[0] = new int[2];
        doorRanges[0][0] = 0;
        doorRanges[0][1] = 30;
        */

        boardHolder = new GameObject("Board" + roomNum).transform;

        //make blank board with just floor
        for (int x = leftx; x <= rightx; x += incX)
        {
            for (int y = bottomy; y <= topy; y += incY)
            {
                //just have the one tile, opens up possibility for different tiles (use random.range if want to randomize)
                GameObject toInstantiate = floorTiles[0];

                //now take chosen gameobject and instantiate
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                //set parent to boardHolder
                instance.transform.SetParent(boardHolder);
            }
        }

        DrawWalls();

        //put player in bottom corner
        if (spawnPoint)
        {
            GameObject playerinstance = Instantiate(player, new Vector3(5, 5, 0f), Quaternion.identity) as GameObject;
        }



    }

    private void DrawWall(int x, int y, bool door)
    {
        if (door)
        {
            // TODO: Draw cool stuff
            return;
        }
        
        GameObject wall = outerTiles[0];
        GameObject create = Instantiate(wall, new Vector3(x, y, 0f), Quaternion.identity);
        create.transform.SetParent(boardHolder);
    }

    delegate void DrawWallPairCallback(int n1, int n2, bool door);

    private void DrawWallPair(Wall[] sides, int start, int end, DrawWallPairCallback callback)
    {
        int incN = Math.Sign(end - start);
        for (int n = start; n <= end; n += incN)
        {
            IList<DoorContainer> doorsInRange =
                (from d in doors
                 where n >= d.range[0] && n <= d.range[1]
                 select d).ToArray();

            foreach (var side in sides)
            {
                bool door = doorsInRange.Any(d => d.side == side.side);
                callback(n, side.n, door);
            }
        }
    }

    private void DrawWalls()
    {
        Wall[] sidesH = new[]
        {
            new Wall("rt", rightx),
            new Wall("lt", leftx),
        };

        Wall[] sidesV = new[]
        {
            new Wall("tp", topy),
            new Wall("bm", bottomy),
        };

        DrawWallPair(sidesV, leftx, rightx, (x, y, door) => DrawWall(x, y, door));
        DrawWallPair(sidesH, bottomy, topy, (y, x, door) => DrawWall(x, y, door));
    }
}

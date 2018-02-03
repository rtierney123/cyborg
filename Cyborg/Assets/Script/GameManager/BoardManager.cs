using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    public int col;
    public int row;

    private List<Vector3> gridPositions = new List<Vector3>();
    private Transform boardHolder;
    private Level currentLevel;
  

    //clears gridPositions and prepares to generate new board
    private void InitialiseList(Level level)
    {
        gridPositions.Clear();
        
        for (int x = 0; x < 80; x++)
        {
            for (int y = -100; y < 50; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }
 



    public void SetupScene(Level level)
    {
        currentLevel = level;

        level.RoomSetup();

        //reset gridpositions
        InitialiseList(level);
    }


}

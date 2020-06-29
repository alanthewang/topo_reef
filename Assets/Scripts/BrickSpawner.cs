using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BrickSpawner : MonoBehaviour
{
    public Transform st;
    public GameObject brick;
    public List<GameObject> bricks;
    Vector3 sPos;

    // Start is called before the first frame update
    void Start()
    {
        GameMaster gm = GameMaster.Instance;
        sPos = st.position; //find starting location from transform
        Spawn5(); //run spawn function
        gm.target = bricks[0]; //assuming brick list is set, sets the game master to disable camera follow
        gm.ToggleRigidBody();
        gm.ToggleBuoyancy();
        Camera.main.GetComponent<SmoothFollow>().target = bricks[0].transform; //Set camera to follow the first brick spawned
    }

    void Spawn1()
    {
        bricks = new List<GameObject>();
        for (int x = 0; x < 10; x++)
        {
            bricks.Add(Instantiate(brick, new Vector3(sPos.x + 10 * x, sPos.y, sPos.z), Quaternion.identity));
        }
    }

    void Spawn2()
    {
        bricks = new List<GameObject>();
        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                bricks.Add(Instantiate(brick, new Vector3(sPos.x + 10 * x, sPos.y, sPos.z + 10 * z), Quaternion.identity));
            }
        }
    }

    void Spawn3()
    {
        float offset = 2;
        bricks = new List<GameObject>();
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int z = 0; z < 10; z++)
                {                    
                    if (x < y || z < y || x > 10 -y || z > 10 -y)
                    {

                    }
                    else
                    {
                        bricks.Add(Instantiate(brick, new Vector3(sPos.x + offset * x, sPos.y + offset * y, sPos.z + offset * z), Quaternion.identity));
                    }                  
                }
            }
        }
    }

    void Spawn4()
    {
        float offset = 1.8f;
        bricks = new List<GameObject>();
        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                bricks.Add(Instantiate(brick, new Vector3(sPos.x + offset * x, sPos.y, sPos.z + offset * z), Quaternion.Euler(0, 0, 36)));                
            }
        }
    }

    void Spawn5()
    {
        float offset = 1.75f;
        bricks = new List<GameObject>();
        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (x < y || z < y || x > 10 - y || z > 10 - y)
                    {

                    }
                    else
                    {
                        brick = Instantiate(brick, new Vector3(sPos.x + offset * x, sPos.y + offset * y, sPos.z + offset * z), Quaternion.Euler(0, y * 36, z*72));
                        bricks.Add(brick);

                    }
                }
            }
        }
    }
}

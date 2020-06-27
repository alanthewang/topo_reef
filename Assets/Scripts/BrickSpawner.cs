using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BrickSpawner : MonoBehaviour
{
    public Transform st;
    public GameObject brick;
    public List<GameObject> bricks;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 sPos = st.position;
        bricks = new List<GameObject>();
        for (int n = 0; n < 10; n++)
        {
            bricks.Add(Instantiate(brick, new Vector3(sPos.x+ 10*n, sPos.y, sPos.z), Quaternion.identity));
        }
        GameMaster.Instance.target = bricks[0];
        Camera.main.GetComponent<SmoothFollow>().target = bricks[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.UNetWeaver;
using UnityEngine;

public class JsonSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        String datapath = Application.dataPath + "/JSON/reefValleyExportTest.json";
        Debug.Log(System.IO.File.Exists(datapath));
        List<BrickInfo>lbi = JsonConvert.DeserializeObject<List<BrickInfo>>(File.ReadAllText(datapath));

        foreach (BrickInfo brickInfo in lbi) {
            Debug.Log(brickInfo);
            Debug.Log(brickInfo.getPosition());
            //What do you do with these?
        }
    }
}

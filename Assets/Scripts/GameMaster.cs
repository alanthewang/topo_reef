using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{ 
    public Text ForceIndicatorText;
    public Slider ForceSlider;
    public Button FindGeoButton;
    public float minTargetDist = 10;
    public float riseSpeed = 0.1f;
    [HideInInspector]
    public GameObject target = null;
    public BrickSpawner bs;

    private static GameMaster _instance;
    public static GameMaster Instance
    {
        get
        {
            return _instance;
        }

    }

    private void Start()
    {
        _instance = this;
        FindGeo(true);
    }

    private void FixedUpdate()
    {
        ForceIndicatorText.text = string.Format("Applied force magnitude {0:0}" , ForceSlider.value);
        if (Input.anyKey)
        {
            FindGeo(false);
        }

        if (Vector3.Distance(Camera.main.transform.position, target.transform.position) < minTargetDist)
        {
            FindGeo(false);
        }

        if (Input.GetKey(KeyCode.Space))
            transform.position += Vector3.up * riseSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.LeftControl))
            transform.position += -Vector3.up * riseSpeed * Time.deltaTime;

    }

    public void FindGeo(bool enable)
    {
        if (target != null)
        {
            FindGeoButton.interactable = !enable;
            //Camera.main.GetComponent<LerpCam>().enabled = enable;
            Camera.main.GetComponent<SmoothFollow>().enabled = enable;
        }
    }

    public void ApplyForce()
    {
        foreach (GameObject go in bs.bricks) {
            go.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward.normalized * ForceSlider.value);
        }
    }


}

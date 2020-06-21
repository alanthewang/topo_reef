using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{ 
    public Text ForceIndicatorText;
    public Slider xslider;
    public Slider yslider;
    public Slider zslider;
    public Button FindGeoButton;
    public float minTargetDist = 50;
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
        ForceIndicatorText.text = string.Format("Applied force {0:0},{1:0},{2:0}", xslider.value, yslider.value, zslider.value);
        if (Input.anyKey)
        {
            FindGeo(false);
        }
    }

    public void FindGeo(bool enable)
    {
        FindGeoButton.interactable = !enable;
        Camera.main.GetComponent<LerpCam>().enabled = enable;
    }

    public void AddForce(Vector3 force)
    {

    }
}

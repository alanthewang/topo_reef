using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{ 
    public Text ForceIndicatorText;
    public Slider xslider;
    public Slider yslider;
    public Slider zslider;
    public Button FindGeoButton;
    public float minTargetDist = 10;
    public float riseSpeed = 0.1f;
    public GameObject target;

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
        FindGeoButton.interactable = !enable;
        Camera.main.GetComponent<LerpCam>().enabled = enable;
    }

    public void ApplyForce()
    {
        target.GetComponent<Rigidbody>().AddForce(new Vector3(xslider.value, yslider.value, zslider.value));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(target.transform.position, target.transform.position + new Vector3(xslider.value, yslider.value, zslider.value));        
    }
}

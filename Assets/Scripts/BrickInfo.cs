using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;
public class BrickInfo {
    public string Centroid { get; set; }
    public float Angle { get; set; }
    public Vector3 position;
    bool parsed = false;

    public float s_to_f(string s)
    {
        //Debug.Log(s);
        return float.Parse(s, CultureInfo.InvariantCulture.NumberFormat);
    }
    public Vector3 getPosition()
    {
        if (parsed)
        {
            return position;
        }
        else
        {
            string tempS = Centroid.Substring(1, Centroid.Length - 2);
            List<string> l = tempS.Split(',').ToList();
            position= new Vector3(s_to_f(l[0]), s_to_f(l[1]), s_to_f(l[2]));
            parsed = true;
        }
        return position;
    }

    public override string ToString()
    {
        return Centroid + " angle: " + Angle;
    }
}

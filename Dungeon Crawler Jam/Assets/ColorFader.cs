using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFader : MonoBehaviour
{
    public Color colorIni = Color.white;
    public Color colorFin = Color.green;
    public float duration = 3f;
    Color lerpedColor = Color.white;

    private float t = 0;
    private bool flag;

    Renderer _renderer;
    // Use this for initialization
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        lerpedColor = Color.Lerp(colorIni, colorFin, Mathf.PingPong(Time.time, 1));
        _renderer.material.color = lerpedColor;

        if (flag == true)
        {
            t -= Time.deltaTime / duration;
            if (t < 0.01f)
                flag = false;
        }
        else
        {
            t += Time.deltaTime / duration;
            if (t > 0.99f)
                flag = true;
        }
    }
}

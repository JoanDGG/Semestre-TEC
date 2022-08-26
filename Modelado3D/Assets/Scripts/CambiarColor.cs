using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        cambiarColor();
    }

    // Update is called once per frame
    private void cambiarColor()
    {
        float cx = Random.Range(0.0f, 1.0f);
        float cy = Random.Range(0.0f, 1.0f);
        float cz = Random.Range(0.0f, 1.0f);
        Color c = new Color(cx, cy, cz);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.SetColor("_Color", c);
    }
}

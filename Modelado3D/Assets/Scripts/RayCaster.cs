using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Sphere
{
    public Vector3 center;
    public float radius;
    public Vector3 kd;
    public Vector3 ks;
    public Vector3 ka;
    public Sphere(Vector3 _center, float _radius)
    {
        center = _center;
        radius = _radius;
    }
}
public class RayCaster : MonoBehaviour
{
    public Renderer plane;
    public Texture2D background;
    public Vector3 CAMERA;
    public Vector3 LIGHT;
    public Vector3 Ia;
    public Vector3 Id;
    public Vector3 Is;
    public Vector2[] kdValues;
    public Vector2 ALPHA;
    public int spheresCount;
    public Vector2 SR;
    public Vector2[] SC;
    public Vector3 n;
    private Vector3 topLeft;
    private Camera mainCam;
    private List<Sphere> spheres;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        spheres = new List<Sphere>();
        topLeft = FindTopLeftFrusrtumNear();

        for (int i = 0; i < spheresCount; i++)
        {
            Vector3 center = new Vector3(   Random.Range(SC[0].x, SC[0].y), 
                                            Random.Range(SC[1].x, SC[1].y), 
                                            Random.Range(SC[2].x, SC[2].y));
            // Create sphere
            Sphere sphere = new Sphere(center, Random.Range(SR.x, SR.y));
            sphere.kd = new Vector3(    Random.Range(kdValues[0].x, kdValues[0].y),
                                        Random.Range(kdValues[1].x, kdValues[1].y),
                                        Random.Range(kdValues[2].x, kdValues[2].y));
            sphere.ka = new Vector3(sphere.kd.x / 5.0f, sphere.kd.y / 5.0f, sphere.kd.z / 5.0f);
            sphere.ks = new Vector3(sphere.kd.x / 3.0f, sphere.kd.y / 3.0f, sphere.kd.z / 3.0f);
            spheres.Add(sphere);
            GameObject sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sph.transform.position = center;
            sph.transform.localScale = new Vector3(sphere.radius * 2f, sphere.radius * 2f, sphere.radius * 2f);
            Renderer rend = sph.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_Color", new Color(sphere.kd.x, sphere.kd.y, sphere.kd.z));
            rend.material.SetColor("_SpecColor", new Color(sphere.ks.x, sphere.ks.y, sphere.ks.z));
        }
        mainCam.transform.position = CAMERA;

        spheres.Sort((s1, s2) =>
        {
            return s1.center.z.CompareTo(s2.center.z);
        });

        // Create pointLight
        GameObject pointLight = new GameObject("ThePointLight");
        Light lightComp = pointLight.AddComponent<Light>();
        lightComp.type = LightType.Point;
        lightComp.color = new Color(Id.x, Id.y, Id.z);
        lightComp.intensity = 20;

        float frusttumHeight = 2.0f * mainCam.nearClipPlane * Mathf.Tan(mainCam.fieldOfView * Mathf.Deg2Rad);
        float frustumWidth = frusttumHeight * mainCam.aspect;
        float pixelWidth = frustumWidth / 640f;
        float pixelHeight = frusttumHeight / 480f;
        var texture = new Texture2D((int)640f, (int)480f, TextureFormat.ARGB32, false);
    
        for (int x = 0; x < 640; x++)
        {
            for (int y = 0; y < 480; y++)
            {
                float u = x / 640f;
                float v = (480f - y) / 480f;
                Color bg = background.GetPixelBilinear(u, v);
                texture.SetPixel(x, y, bg);
            }
        }
        texture.Apply();
        
        for (int x = 0; x < 640; x++)
        {
            for (int y = 0; y < 480; y++)
            {
                foreach (Sphere s in spheres)
                {
                    Color color = GetPixel(x, y, s);
                    if(color != Color.black)
                    {
                        texture.SetPixel(x, 479 - y, color);
                        break;
                    }
                }
            }
            texture.Apply();
        }

        texture.filterMode = FilterMode.Point;
        Shader shader = Shader.Find("Unlit/Texture");
        plane.material.shader = shader;
        plane.material.mainTexture = texture;
        
        //then Save To Disk as PNG
        byte[] bytes = texture.EncodeToPNG();
        
        var dirPath = Application.dataPath + "/../SaveImages/";
        if(!Directory.Exists(dirPath)) {
            Directory.CreateDirectory(dirPath);
        }
        File.WriteAllBytes(dirPath + "render" + ".png", bytes);
    }

    Vector3 Illumination(Vector3 PoI, Sphere sphere)
    {
        Vector3 A = new Vector3(sphere.ka.x * Ia.x, sphere.ka.y * Ia.y, sphere.ka.z * Ia.z);
        Vector3 D = new Vector3(sphere.kd.x * Id.x, sphere.kd.y * Id.y, sphere.kd.z * Id.z);
        Vector3 S = new Vector3(sphere.ks.x * Is.x, sphere.ks.y * Is.y, sphere.ks.z * Is.z);

        Vector3 l = LIGHT - PoI;
        Vector3 v = CAMERA - PoI;
        Vector3 n = PoI - sphere.center;
        float dotNuLu = Vector3.Dot(n.normalized, l.normalized);
        float dotNuL = Vector3.Dot(n.normalized, l);

        Vector3 lp = n * dotNuL;
        Vector3 lo = l - lp;
        Vector3 r = lp - lo;
        D *= dotNuLu;
        float VuRu = Mathf.Pow(Vector3.Dot(v.normalized, r.normalized), Random.Range(ALPHA.x, ALPHA.y));
        S *= (float.IsNaN(VuRu) ? 0f : VuRu);

        return A + D + S;
    }

    Vector3 FindTopLeftFrusrtumNear()
    {
        //localizar camara
        Vector3 o = mainCam.transform.position;
        //mover hacia adelante
        Vector3 p = o + mainCam.transform.forward * mainCam.nearClipPlane;
        //obtener dimenciones del frustum
        float frusttumHeight = 2.0f * mainCam.nearClipPlane * Mathf.Tan(mainCam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float frustumWidth = frusttumHeight * mainCam.aspect;
        //mover hacia arriba, media altura
        p += mainCam.transform.up * frusttumHeight / 2.0f;
        //mover a la izquierda, medio ancho
        p -= mainCam.transform.right * frustumWidth / 2.0f;
        return p;

    }
    
    Color GetPixel(int xCoord, int yCoord, Sphere sphere)
    {
        float frusttumHeight = 2.0f * mainCam.nearClipPlane * Mathf.Tan(mainCam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float frustumWidth = frusttumHeight * mainCam.aspect;
        float pixelWidth = frustumWidth / 640f;
        float pixelHeight = frusttumHeight / 480f;
        // Vector3 center = topLeft;
        Vector3 center = FindTopLeftFrusrtumNear();
        center += (pixelWidth / 2f) * mainCam.transform.right;
        center += mainCam.transform.right * xCoord * pixelWidth;
        center -= (pixelHeight / 2f) * mainCam.transform.up;
        center -= mainCam.transform.up * yCoord * pixelHeight;

        Vector3 u = (center - mainCam.transform.position).normalized;
        Vector3 oc = mainCam.transform.position - sphere.center;

        float delta = (Mathf.Pow(Vector3.Dot(u, oc), 2.0f) - (Mathf.Pow(oc.magnitude, 2.0f) - Mathf.Pow(sphere.radius, 2.0f)));
        
        float d_mas = -(Vector3.Dot(u, oc)) + Mathf.Sqrt(delta);
        float d_menos = -(Vector3.Dot(u, oc)) - Mathf.Sqrt(delta);

        float d;
        if(delta > 0)
        {
            if(Mathf.Abs(d_mas) < Mathf.Abs(d_menos))
               d = d_mas;
            else
               d = d_menos;
        }
        else if (delta == 0)
            d = d_mas;
        else
            return Color.black;
        
        Vector3 color = Illumination(CAMERA + d * u, sphere);
        return new Color(color.x, color.y, color.z);
    }
}
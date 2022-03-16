using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthtControl : MonoBehaviour
{
    [SerializeField] private Light light;
    private float transitionTime = 0.00f;
    private bool inCave;
    private float minLightIntensity = 0.00f;
    private float maxLightIntensity = 1.50f;
    private int playerInt;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.ambientLight = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if(inCave && transitionTime > 0)
        {
            light.intensity = Mathf.Lerp(minLightIntensity, maxLightIntensity, transitionTime);
        }
        if (!inCave && transitionTime > 0)
        {
            light.intensity = Mathf.Lerp(maxLightIntensity, minLightIntensity, transitionTime);
        }
        transitionTime -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Arrow" && collision.gameObject.tag != "Weapon" && collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Boss")
        {
            inCave = true;
            transitionTime = 1.00f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Arrow" && collision.gameObject.tag != "Weapon" && collision.gameObject.tag != "Enemy"&& collision.gameObject.tag != "Boss")
        {
            inCave = false;
            transitionTime = 1.00f;
        }
    }
}

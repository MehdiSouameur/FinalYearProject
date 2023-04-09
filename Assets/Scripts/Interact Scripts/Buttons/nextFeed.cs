using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class nextFeed : MonoBehaviour
{
    [SerializeField] GameObject screen;

    private const string SecurityTag = "SecurityCam";
    private RenderTexture feed;
    private GameObject[] cameras;

    screenCount countScript;

    private void Awake()
    {
        cameras = GameObject.FindGameObjectsWithTag(SecurityTag);
        cameras = cameras.OrderBy(camera => camera.name).ToArray();
        countScript = screen.GetComponent<screenCount>();
    }

    public void followingFeed()
    {
        countScript.addCount();
        if(countScript.screenIndex > cameras.Length - 1)
        {
            countScript.screenIndex = 0;
        }
        changeFeed();
    }

    public void previousFeed()
    {
        countScript.removeCount();
        if (countScript.screenIndex < 0)
        {
            countScript.screenIndex = cameras.Length - 1;
        }
        changeFeed();
    }

    private void changeFeed()
    {
        GameObject camChange = cameras[countScript.screenIndex];

        feed = camChange.GetComponent<Camera>().targetTexture;
        Material material = new Material(Shader.Find("Unlit/Texture"));
        material.SetTexture("_MainTex", feed);

        MeshRenderer renderer = screen.GetComponent<MeshRenderer>();
        renderer.material = material;

        Debug.Log("Feed changed");
    }
}

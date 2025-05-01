using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounderController : MonoBehaviour
{
    //this will make your screen adaptable with any kind of screen

    Camera mainCamera;

    [SerializeField] GameObject bottom, left, right, top;

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; //must be orthor
        }
    }

    private void Start()
    {
        SetupBoundary();
    }

    //should move bounder down, around 20% ? or we need some design ? 

    void SetupBoundary()
    {
        float height = 2f * mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;

        Debug.Log($"Check : {height} + {width}");

        bottom.transform.localScale = new Vector3(width, 1, 1);
        bottom.transform.localPosition = new Vector3(0,-height / 2, 0);

        top.transform.localScale = new Vector3(width, 1, 1);
        top.transform.localPosition = new Vector3(0, height / 2, 0);

        left.transform.localScale = new Vector3(1, height, 1);
        left.transform.localPosition = new Vector3(-width/2, 0, 0);

        right.transform.localScale = new Vector3(1, height, 1);
        right.transform.localPosition = new Vector3(width / 2, 0, 0);
    }
}

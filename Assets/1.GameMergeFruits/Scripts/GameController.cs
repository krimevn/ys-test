using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance
    {
        get;
        private set;
    }

    public bool canDropNextFruit = false;
    

    private void Awake()
    {
        instance = this;    
    }

    private void Start()
    {
        canDropNextFruit = true; //allow game start
    }

    void RandomNextFruit()
    {
        int r = Random.Range(0, 4);
        
    }
    void ShowNextDropFruit()
    { 
        
    }

    private void FixedUpdate()
    {
        //if (Input.touchCount > 0) //forgot, this only valid in mobile
        //{
        //}
        
        //raycast check touch wall or not ... 
        if (Input.GetMouseButtonUp(0) && canDropNextFruit)
        {
            var mousePos = Input.mousePosition;
            var dropPos = Camera.main.ScreenToWorldPoint(mousePos);
            var f = FruitPoolingController.instance.GetFruitFromPool();

            f.gameObject.SetActive(true);
            f.transform.localPosition = new Vector2(dropPos.x, Camera.main.orthographicSize-1);
            canDropNextFruit = false;

        }
    }
    

}

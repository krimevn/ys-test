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
    [SerializeField] SpriteRenderer nextFruitShow;
    [SerializeField] FruitData nextFruitData;

    private void Awake()
    {
        instance = this;    
    }

    private void Start()
    {
        canDropNextFruit = true; //allow game start
        RandomNextFruit();
    }

    public void RandomNextFruit()
    {
        //can do controllable ratio spawn too, but no time.
        int r = Random.Range(0, FruitPoolingController.instance.fruitConfig.MaxFruitIndexCanDrop);
        nextFruitData = FruitPoolingController.instance.GetFruitData(r);
        if (nextFruitData == null)
        {
            nextFruitData = FruitPoolingController.instance.GetFruitData(0);
        }
        ShowNextDropFruit(nextFruitData);
    }
    void ShowNextDropFruit(FruitData data)
    {
        nextFruitShow.gameObject.SetActive(true);
        nextFruitShow.sprite = data.FruitSprite;
        nextFruitShow.transform.localScale = new Vector2(data.Scale,data.Scale);
    }

    void HideNextDropFruit()
    {
        nextFruitShow.gameObject.SetActive(false);
    }

    private void Update()
    {
        //if (Input.touchCount > 0) //forgot, this only valid in mobile device
        //{
        //}

        if (Input.GetMouseButtonDown(0) && canDropNextFruit)
        {
            var mousePos = Input.mousePosition;
            var dropPos = Camera.main.ScreenToWorldPoint(mousePos);
            var f = FruitPoolingController.instance.GetFruitFromPool();

            f.ChangeFruit(nextFruitData);
            f.EnableFruit();
            
            f.transform.localPosition = new Vector2(dropPos.x, Camera.main.orthographicSize-1);
            //HideNextDropFruit();
            RandomNextFruit();
            canDropNextFruit = false;
        }
    }
}

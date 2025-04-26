using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPoolingController : MonoBehaviour
{
    //pooling actually is overthinking for this case

    public static FruitPoolingController instance { get; private set; }

    [SerializeField] Fruit fruitPrefab;
    [HideInInspector] public FruitConfig fruitConfig;
    [SerializeField] int initPoolSize = 10; //default 10 fruits, if need more, will generate
    [SerializeField] Transform FruitPoolRoot;
    [SerializeField] List<Fruit> FruitPooled;

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            FruitPooled = new();
            InitPool();
        }
        else
        {
            Destroy(this.gameObject);
        }

        fruitConfig = FruitConfig.instance;
    }

    void InitPool()
    {
        for (int i = 0; i < initPoolSize; i++)
        {
            CreateNewFruit();
        }
    }

    Fruit CreateNewFruit()
    {
        Fruit f = Instantiate(fruitPrefab, FruitPoolRoot);
        f.gameObject.SetActive(false);
        FruitPooled.Add(f);
        return f;
    }

    public Fruit GetFruitFromPool()
    {
        for (int i = 0; i < FruitPooled.Count; i++)
        {
            if (!FruitPooled[i].gameObject.activeInHierarchy)
                return FruitPooled[i];
        }
        return CreateNewFruit();
    }

    public void ReturnFruit(Fruit f)
    {
        f.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollisionResolver : MonoBehaviour
{
    public static FruitCollisionResolver instance;

    public List<Fruit> fruitTriggerList;

    private void Awake()
    {
        instance = this;    
        fruitTriggerList = new();
    }

    public void MergeReceiver(Fruit self, Fruit contactFruit, Vector2 contactPos)
    {
        if (fruitTriggerList.Count > 0)
        {
            foreach (var f in fruitTriggerList)
            {
                if (f == contactFruit)
                {
                    //got same type of fruit ? this could be wrong
                    Debug.Log($"Got same type of fruit ... {f.name} - {contactFruit.name}");
                    var fd = FruitPoolingController.instance.GetNextFruitData(self.fruitData.FruitIndex);
                    if (fd != null) //=> can do next fruit
                    {
                        Debug.Log($"Can do next fruit: {self.fruitData.FruitIndex}");
                        fruitTriggerList.Remove(f);
                        f.ReturnFruit();
                        self.ReturnFruit();
                        //spawn next fruit...
                        Fruit fr = FruitPoolingController.instance.GetFruitFromPool();
                        fr.transform.position = contactPos;
                        fr.ChangeFruit(fd);
                        fr.EnableFruit();
                    }
                    else
                    {
                        //should announce win here
                        //or just take out that fruit and add score
                        //in this case i just take it out for player can keep play
                        Debug.Log("Got highest index");
                        fruitTriggerList.Remove(f);
                        self.ReturnFruit();
                        f.ReturnFruit();
                    }
                    break;
                }
            }
        }
        else
        {
            fruitTriggerList.Add(self);
        }
    }
}

//[System.Serializable]
//public class FruitWaitMerge
//{
//    public Fruit fruit;
//    public Fruit contactedFruit;
//    Vector2 contactPos;
//}
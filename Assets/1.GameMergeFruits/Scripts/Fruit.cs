using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    //due limited time and no specific requirement, so i won't do shape exact 2d collider of fruits. That will cost a lot of time and uncontrollable problems ahead.
    [SerializeField] Collider2D coll;
    [SerializeField] Rigidbody2D rig;
    [SerializeField] SpriteRenderer spriteRend;
    public FruitData fruitData; 

    bool _hasCollided = false;
    bool _isMerging = false;

    public void ChangeFruit(FruitData data)
    {
        fruitData = data;
        spriteRend.sprite = data.FruitSprite;
        this.transform.localScale = new Vector2(data.Scale, data.Scale);
        rig.mass = data.Weight;
        this.gameObject.name = data.FruitIndex + data.FruitName;
    }

    public void EnableFruit()
    {
        coll.enabled = true;
        _hasCollided = false;
        _isMerging = false;
        this.transform.localEulerAngles = Vector3.zero;
        this.gameObject.SetActive(true);
    }

    public void ReturnFruit()
    {
        coll.enabled = false;
        _hasCollided = false;
        _isMerging = false;
        this.gameObject.SetActive(false);
    }

    void ColliderInformer()
    {
        //need to inform that fruit had been touched something and not merging
        if (!_hasCollided && !_isMerging)
        {
            //can drop next fruit
            Debug.Log("ColliderInformer");
            _hasCollided = true;
            GameController.instance.canDropNextFruit = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //need save data to compare
        //on collide with same type -> disable check collision -> send to resolver, don't self resolve.
        if (collision.gameObject.layer != LayerMask.NameToLayer("Bounder"))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Fruit"))
            {
                //check is same level or not
                if (collision.gameObject.TryGetComponent(out Fruit f))
                {
                    if (f.fruitData.FruitName == fruitData.FruitName)
                    {
                        //same type, merge
                        //actually i don't think i need to check contact, just need middle position of 2 fruits, due same size
                        Vector2 contactPos = (this.transform.position + collision.transform.position) / 2;
                        _isMerging = true;
                        FruitCollisionResolver.instance.MergeReceiver(this, f, contactPos);
                        ColliderInformer();
                        return;
                    }
                }
            }

            ColliderInformer();
        }
    }


}


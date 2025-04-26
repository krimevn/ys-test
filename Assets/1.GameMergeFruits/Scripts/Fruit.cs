using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    //due limited time and no specific requirement, so i won't do shape exact 2d collider of fruits. That will cost a lot of time and uncontrollable problems ahead.
    [SerializeField] Collider2D coll;
    [SerializeField] Rigidbody2D rig;
    [SerializeField] SpriteRenderer spriteRend;

    bool _hasCollided = false;
    bool _isMerging = false;

    public void ChangeFruit(FruitData data)
    {
        spriteRend.sprite = data.FruitSprite;
        this.transform.localScale = new Vector2(data.Scale, data.Scale);
        rig.mass = data.Weight;
    }

    void ColliderInformer()
    {
        //need to inform that fruit had been touched something and not merging
        if (!_hasCollided && !_isMerging)
        {
            //can drop next fruit
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
            ColliderInformer();
        }
    }


}


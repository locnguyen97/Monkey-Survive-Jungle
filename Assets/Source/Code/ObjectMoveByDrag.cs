using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectMoveByDrag : MonoBehaviour
{
    [SerializeField] List<GameObject> particleVFXs;

    private Vector3 startPos;

    private void OnEnable()
    {
        startPos = transform.position;
    }

    public void PickUp()
    {
        //transform.rotation = new Quaternion(0,0,0,0);
    }

    public void CheckOnMouseUp()
    {
        GameManager.Instance.CheckLevelUp();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
            Destroy(explosion, .75f);
            GameManager.Instance.GetCurrentLevel().RemoveObject(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}

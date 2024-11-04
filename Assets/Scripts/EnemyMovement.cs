using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move the enemy backwards
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        //If the enemy is out of bounds, return it to the pool
        if (transform.position.z < -5)
        {
            ObjectPool.Instance.ReturnObjectToPool(this.gameObject);
        }
        //If the game is over, stop moving
        if (GameManager.Instance.GameOver)
        {
            return;
        }
    }
    //If the enemy collides with the player, end the game
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver = true;
        }
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemy_rotation_speed = 31f; 
    public float enemy_speed = 4f; 
    
    void Update()
    {
        EnemyMove();
        Destroy();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null) player.LoseLife();
            Destroy(gameObject); 
        }
    }

    void EnemyMove()
    {
        transform.Rotate(Vector3.forward * enemy_rotation_speed * Time.deltaTime);
        transform.Translate(Vector3.down * enemy_speed * Time.deltaTime, Space.World);
    }

    void Destroy()
    {
        if (transform.position.y < -6f)
        {
            Player player = FindObjectOfType<Player>();
            if (player != null) player.LoseLife();
            Destroy(gameObject); 
        }
    }

}

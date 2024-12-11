using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f; 

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
            UIManager_sc uiManager = FindObjectOfType<UIManager_sc>();
            if (uiManager != null)
            {
                uiManager.UpdateScore(1); 
            }
        }
    }

}

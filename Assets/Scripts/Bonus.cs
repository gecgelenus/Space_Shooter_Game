using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float bonus_speed = 4f; 
    public float rotation_speed = 41f;
    public enum BonusType { TripleShot, SpeedBoost } 
    public BonusType bonus_type; 


    void UseBonus()
    {
        Player player = FindObjectOfType<Player>();
        if (player == null) return; 
        switch (bonus_type)
        {
            case BonusType.TripleShot:
                player.ActivateTripleShot(); 
                break;
            case BonusType.SpeedBoost:
                player.ActivateSpeedBoost(); 
                break;
            default:
                Debug.LogWarning("Unknown bonus type: " + bonus_type);
                break;
        }
    } 

    void OnTriggerEnter2D(Collider2D collision)
    {if (collision.CompareTag("Laser"))
        {UseBonus(); Destroy(collision.gameObject); Destroy(gameObject);}}

    void Update()
    {
        transform.Translate(Vector3.down * bonus_speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward * rotation_speed * Time.deltaTime);
        if (transform.position.y < -6f){Destroy(gameObject);}
    }

    

    
}

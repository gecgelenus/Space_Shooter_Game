using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy_prefab; 
    public GameObject triple_prefab; 
    public GameObject speed_b_prefab;
    public float init_interval = 4f;  
    public float spwn_interval = 3f; 
    public float bonus_spwn_chance = 0.3f; 
    public float min_size = 0.3f; 
    public float max_size = 2.6f; 
    public float min_rot_speed = 10f; 
    public float max_rot_speed = 50f; 

    void Start()=> InvokeRepeating("Choose", init_interval, spwn_interval);

    void Choose()
    {
        float chance = Random.Range(0f, 1f); 
        if (chance < bonus_spwn_chance)
        {
        float xPosition = Random.Range(-8f, 8f);
        Vector3 spawnPosition = new Vector3(xPosition, 6f, 0f);
        GameObject selectedBonusPrefab = Random.value > 0.5f ? triple_prefab : speed_b_prefab;
        GameObject newBonus = Instantiate(selectedBonusPrefab, spawnPosition, Quaternion.identity);
        Bonus bonus = newBonus.GetComponent<Bonus>();
        if (selectedBonusPrefab == triple_prefab)
        {
            bonus.bonus_type = Bonus.BonusType.TripleShot;
        }
        else if (selectedBonusPrefab == speed_b_prefab)
        {
            bonus.bonus_type = Bonus.BonusType.SpeedBoost;
        }
        float rotationSpeed = Random.Range(min_rot_speed, max_rot_speed);
        bonus.rotation_speed = rotationSpeed;
        }
        else
        {
        float xPosition = Random.Range(-8f, 8f);
        Vector3 spawnPosition = new Vector3(xPosition, 6f, 0f);
        GameObject newEnemy = Instantiate(enemy_prefab, spawnPosition, Quaternion.identity);
        float randomScale = Random.Range(min_size, max_size);
        newEnemy.transform.localScale = new Vector3(randomScale, randomScale, 1);
        float rotationSpeed = Random.Range(min_rot_speed, max_rot_speed);
        newEnemy.GetComponent<Enemy>().enemy_rotation_speed = rotationSpeed;
        }
    }
}

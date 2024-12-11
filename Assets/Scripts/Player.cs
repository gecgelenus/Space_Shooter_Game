using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; 
    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;

    public Transform laserSpawnPoint; 
    public GameObject laserPrefab;    
    public float laserSpeed = 10f;    

    private bool isTripleShotActive = false; 
    private float tripleShotDuration = 10f; 

    private bool isSpeedBoostActive = false; 
    private float speedBoostDuration = 5f; 
    private float defaultSpeed; 

    private int lives = 3; 
    private UIManager_sc uiManager; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultSpeed = speed; 
        uiManager = FindObjectOfType<UIManager_sc>(); 
        uiManager.UpdateLivesUI(lives); 
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical"); 
        if (Input.GetKeyDown(KeyCode.Space)) FireLaser();
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed;
        rb.velocity = movement;
    }

    void FireLaser()
    {
        if (isTripleShotActive)
        {
            TripleLaserSpawn();
        } 
        else{
            Instantiate(laserPrefab, laserSpawnPoint.position, Quaternion.identity); 
        } 
    }

    public void ActivateTripleShot()
    {
        if (isTripleShotActive) return; 
        isTripleShotActive = true;
        StartCoroutine(TripleShotTimer());
    }

    private IEnumerator TripleShotTimer()
    {
        yield return new WaitForSeconds(tripleShotDuration);
        isTripleShotActive = false;
    }

    public void ActivateSpeedBoost()
    {
        if (isSpeedBoostActive) return; 
        isSpeedBoostActive = true;
        speed *= 2; 
        StartCoroutine(SpeedBoostTimer());
    }

    private IEnumerator SpeedBoostTimer()
    {
        yield return new WaitForSeconds(speedBoostDuration);
        speed = defaultSpeed; 
        isSpeedBoostActive = false;

    }

    public void LoseLife()
    {
        lives--;
        if (lives <= 0) lives = 0; 
        if (uiManager != null) uiManager.UpdateLivesUI(lives);
    }

    private void TripleLaserSpawn()
    {
            Vector3 leftLaserPosition = laserSpawnPoint.position + new Vector3(-0.5f, 0, 0);
            Vector3 rightLaserPosition = laserSpawnPoint.position + new Vector3(0.5f, 0, 0);
            Instantiate(laserPrefab, laserSpawnPoint.position, Quaternion.identity);
            Instantiate(laserPrefab, leftLaserPosition, Quaternion.identity);
            Instantiate(laserPrefab, rightLaserPosition, Quaternion.identity);
    }

}
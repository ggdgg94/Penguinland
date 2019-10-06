using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    public float speed = 5f;
    public float rotateSpeed = 50f;
    
    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;
    
    public float boundX = -11f;
    public Transform attackPoint;
    public GameObject bulletPrefab;
    
    private Animator anim;
    private AudioSource explosionSound;
    
    
    // Start is called before the first frame update
    
    void Start(){
        if(canRotate){
            if(Random.Range(0, 2) > 0){
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
        }
    }
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnemy();
        
    }
    
    void Move(){
        if(canMove){
            Vector3 tmp = transform.position;
            tmp.x -= speed * Time.deltaTime;
            transform.position = tmp;
            
            if(tmp.x < boundX)
                gameObject.SetActive(false);
        }
    }
    
    void RotateEnemy(){
        if(canRotate){
            transform.Rotate(new Vector3(0f,0f,rotateSpeed * Time.deltaTime), Space.World);
        }
    }
}

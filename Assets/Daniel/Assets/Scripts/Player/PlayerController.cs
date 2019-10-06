using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 5f;
    public float maxX, maxY, minX, minY;
    private int dirX, dirY;
    private Vector2 tmpPos;
    public float attackTimer = 0.35f;
    private float currentAttackTimer;
    private bool canAttack;
    
    [SerializeField]
    private GameObject playerBullet;
    [SerializeField]
    private Transform attackPoint;
    // Start is called before the first frame update
    void Start()
    {
        currentAttackTimer = attackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }
    
    void MovePlayer(){

        dirX = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        dirY = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        tmpPos = transform.position;
        tmpPos.x += dirX * speed * Time.deltaTime;
        tmpPos.y += dirY * speed * Time.deltaTime;

        if (tmpPos.x > maxX)
            tmpPos.x = maxX;

        if (tmpPos.x < minX)
            tmpPos.x = minX;

        if (tmpPos.y > maxY)
            tmpPos.y = maxY;

        if (tmpPos.y < minY)
            tmpPos.y = minY;

        transform.position = tmpPos;

        //Change hardcoded values
        /*
        if(Input.GetAxisRaw("Vertical") > 0f){
            Vector3 tmp = transform.position;
            tmp.y += speed * Time.deltaTime;
            
            if(tmp.y > maxY)
                tmp.y = maxY;
            
            transform.position = tmp;
        }else if(Input.GetAxisRaw("Vertical") < 0f){
            Vector3 tmp = transform.position;
            tmp.y -= speed * Time.deltaTime;
            if(tmp.y < minY)
                tmp.y = minY;
            transform.position = tmp;
        }
        */
    }
    
    
    //Control bullet amount
    void Attack(){
        attackTimer += Time.deltaTime;
        if(attackTimer > currentAttackTimer){
            canAttack = true;
        }
        if(Input.GetKeyDown(KeyCode.K)){
            if(canAttack){
                canAttack = false;
                attackTimer = 0f;
                Instantiate(playerBullet, attackPoint.position, Quaternion.identity);
            }
        }
        
    }
    /* Wrong way?
    void Attack(){
        if(Input.GetKeyDown(KeyCode.K)){
            Instantiate(playerBullet, attackPoint.position, Quaternion.identity);
        }
    }
    */
}

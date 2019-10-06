using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 100;
    public float deactivateTimer = 3f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateGameObject", deactivateTimer);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    void Move(){
        Vector3 tmp = transform.position;
        tmp.x += speed * Time.deltaTime;
        transform.position = tmp;
    }
    
    void DeactivateGameObject(){
        gameObject.SetActive(false);
    }
}

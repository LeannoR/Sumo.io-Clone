using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator animator;

    public static EnemyController instance;
    public ShurikenSpawner shurikenSpawner;
    public Vector3 min;
    public PlayerMovement playerMovement;
    public float movementSpeed = 5f;
    public int shurikenCount = 0;
    public int force = 5;
    public int enemyForce = 0;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        ChasingTarget();
    }


    public Vector3 TargetPos()                      //finding shuriken position
    {
        min = shurikenSpawner.shurikens[0].transform.position;
        var distanceToShuriken = Vector3.Distance(min, transform.position);

        for (int i = 0; i <= shurikenSpawner.shurikens.Count - 1; i++)
        {
            if(Vector3.Distance(shurikenSpawner.shurikens[i].transform.position,transform.position) <= distanceToShuriken)
            {
                min = shurikenSpawner.shurikens[i].transform.position;
            }
        }
        return min;
    }


    public void ChasingTarget()                 //chasing target position
    {
        transform.LookAt(TargetPos());
        transform.position = transform.position + transform.forward * movementSpeed * Time.deltaTime;
        animator.SetBool("isRunning", true);
    }

    private void OnTriggerEnter(Collider collider)          //collecting shuriken
    {
        if (collider.gameObject.tag == "Shuriken")
        {
            int index = shurikenSpawner.shurikens.IndexOf(collider.gameObject);
            Destroy(collider.gameObject);
            shurikenSpawner.shurikens.RemoveAt(index);
            shurikenCount++;
            force++;
        }
    }
}

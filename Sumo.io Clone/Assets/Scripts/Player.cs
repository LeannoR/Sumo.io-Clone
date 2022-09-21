using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody enemyRigidBody;
    private Rigidbody rigidBody;
    public EnemyController enemyController;
    public PlayerMovement playerMovement;
    public ShurikenSpawner shurikenSpawner;
    public int shurikenCount = 0;
    public int playerScore = 0;
    public int forceBetweenPlayers = 0;
    public int force = 10;
    public int enemyForce = 0;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        enemyForce = enemyController.force;
    }

    public void PlayerScore()
    {
        playerScore = shurikenCount * 100;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy");
        {
            enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();

            if (enemyForce > force)
            {
                forceBetweenPlayers = enemyForce - force + 5;
                rigidBody.AddForce(forceBetweenPlayers * -Vector3.forward, ForceMode.Impulse);
                enemyRigidBody.AddForce(force * Vector3.forward, ForceMode.Impulse);
            }
            else if(force >= enemyForce)
            {
                forceBetweenPlayers = force - enemyForce + 5;
                rigidBody.AddForce(force: enemyForce * -Vector3.forward, mode: ForceMode.Impulse);
                enemyRigidBody.AddForce(forceBetweenPlayers * Vector3.forward, ForceMode.Impulse);
            }
            if(forceBetweenPlayers <= 5)
            {
                forceBetweenPlayers = 5;
                rigidBody.AddForce(force: forceBetweenPlayers * -Vector3.forward, ForceMode.Impulse);
                enemyRigidBody.AddForce(forceBetweenPlayers * Vector3.forward, ForceMode.Impulse);
            }
        }
        Debug.Log("Player collider");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Shuriken")
        {
            int index = shurikenSpawner.shurikens.IndexOf(collider.gameObject);
            Destroy(collider.gameObject);
            shurikenSpawner.shurikens.RemoveAt(index);
            shurikenCount++;
            force++;
            PlayerScore();
        }
    }
}

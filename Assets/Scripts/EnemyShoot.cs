using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyShoot : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform Player;

    [SerializeField] private float timer = 5;
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Enemy.SetDestination(Player.position);
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bullettRig = bulletObj.GetComponent<Rigidbody>();
        bullettRig.AddForce(bullettRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 5f);
    }
}

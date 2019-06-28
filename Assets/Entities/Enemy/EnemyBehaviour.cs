using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{ 
    public GameObject projectile;
    public float health = 150f;
    public float projectileSpeed = 5f ;
    public float shootPerSeconds = 0.5f;
    public int scoreValue = 150;
    private ScoreKeeper scoreKeeper;
    public AudioClip fireSound;
    public AudioClip deathSound;

    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }
   void Fire()
   {
       Vector3 startPosistion = transform.position + new Vector3(0, -1f, 0);
       GameObject missile = Instantiate(projectile, startPosistion, Quaternion.identity);
       missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
   }
   public void Update()
   {
        float probability = Time.deltaTime * shootPerSeconds;
        if (Random.value < probability)
        {
            Fire();
        }
   }
   void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if(missile)
        {
           health -= missile.GetDamage();
            if(health <= 0)
            {
                Die();
            }
            missile.Hit();
        }
    }
    void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
    }
}

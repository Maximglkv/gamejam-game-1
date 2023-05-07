using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private EnemyData data;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        SetEnemyValues1();
    }

    // Update is called once per frame
    void Update1()
    {
        Cannon();
    }

    private void SetEnemyValues1()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    private void Cannon()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Target"))
        {
            if(collider.GetComponent<Health>() != null)
            {
                collider.GetComponent<Health>().Damage(damage);
                this.GetComponent<Health>().Damage(10000);
            }
        }
    }
}

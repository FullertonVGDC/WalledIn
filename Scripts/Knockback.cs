using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    public float thrust;

    private float difference;

    public float start_knockback_time;
    private float knockback_time;


	// Use this for initialization
	void Start () {
        knockback_time = start_knockback_time;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;

                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockBackCounter(enemy));
            }
        }
    }

    private IEnumerator KnockBackCounter(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockback_time);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = false;
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

	bool collided = false;

	public GameObject explosionPrefab;

	public float explosionWaitTime = 3.0f;

	public float explosionTime = 5.0f;

    Cat cat;
    new Rigidbody rigidbody;

    private void Awake()
    {
        cat = GameObject.FindGameObjectWithTag(Tags.CAT).GetComponent<Cat>();
        rigidbody = GetComponent<Rigidbody>();
    }

    IEnumerator WaitThenExplode ()
	{
		yield return new WaitForSeconds (explosionWaitTime);

		var explosionInstance = Instantiate (explosionPrefab, transform.position, Quaternion.identity, transform.parent);

		Destroy (explosionInstance, explosionTime);

		Destroy (gameObject);
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collided) {
			return;
		}
		for (int i = 0; i < collision.contacts.Length; i++) {
			var contact = collision.contacts [i];
			Debug.DrawRay (contact.point, contact.normal, Color.white);

			if (contact.otherCollider.CompareTag (Tags.SURFACE)) {
				collided = true;
                ScoreManager.score --;

                StartCoroutine(WaitThenExplode ());
				break;
			}

            if (contact.otherCollider.CompareTag(Tags.CATCHER))
            {
                collided = true;
                ScoreManager.score++;

                StartCoroutine(WaitThenJumpUp());
                break;
            }
        }

//		if (collision.relativeVelocity.magnitude > 2)
//			audioSource.Play ();
	}

    private void PopUp()
    {
        rigidbody.AddForce(Vector3.up * 900.0f, ForceMode.Force);
    }

    private IEnumerator WaitThenJumpUp()
    {
        yield return new WaitForSeconds(explosionWaitTime);

        Debug.Log("POPPING DAWG");
        PopUp();

        yield return new WaitForSeconds(explosionWaitTime);

        StartCoroutine(cat.JumpToward(transform));
    }

    void Update()
    {
        if( transform.position.y < -9999)
        {
            Destroy(gameObject);
        }
    }

}

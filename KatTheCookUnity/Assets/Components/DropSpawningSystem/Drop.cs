using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

	bool collided = false;

	public GameObject explosionPrefab;

	public float explosionWaitTime = 3.0f;

	public float explosionTime = 5.0f;

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
				StartCoroutine (WaitThenExplode ());
				break;
			}
		}

//		if (collision.relativeVelocity.magnitude > 2)
//			audioSource.Play ();
	}

}

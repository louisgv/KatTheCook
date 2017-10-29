using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour
{

    public Transform leftAnchor;

    public Transform rightAnchor;

    bool isLeftAnchor = true;

    public IEnumerator JumpToward(Transform dropTransform)
    {
        yield return new WaitForEndOfFrame();

        transform.position = dropTransform.position;

        Destroy(dropTransform.gameObject);

        ScoreManager.score++;

        yield return new WaitForSeconds(5f);

        if (isLeftAnchor)
        {
            transform.position = leftAnchor.position;
        }
        else
        {
            transform.position = rightAnchor.position;
        }
    }
}

using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour
{

    public Transform leftAnchor;

    public Transform rightAnchor;

    public Avatar jumpAvatar;

    public Avatar stayAvatar;

    Animator animator;

    bool isLeftAnchor = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public IEnumerator JumpToward(Transform dropTransform)
    {
        yield return new WaitForEndOfFrame();

        transform.position = dropTransform.position;

        Destroy(dropTransform.gameObject);

        ScoreManager.score++;

        animator.avatar = jumpAvatar;

        yield return new WaitForSeconds(5f);

        if (isLeftAnchor)
        {
            transform.position = leftAnchor.position;
        }
        else
        {
            transform.position = rightAnchor.position;
        }

        animator.avatar = stayAvatar;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour {

    Cat cat;

    public GameObject sizzlingEffect;

    void OnCollisionEnter(Collision collision)
    {
        if (!sizzlingEffect.activeSelf)
        {
            sizzlingEffect.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (sizzlingEffect.activeSelf)
        {
            sizzlingEffect.SetActive(false);
        }
    }
}

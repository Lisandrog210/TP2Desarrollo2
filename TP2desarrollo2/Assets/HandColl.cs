using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandColl : MonoBehaviour {

    [SerializeField] string nextLevel;
    //public int vida = 10;
    public LayerMask layer;
    Animator AnimatorPlayer;

    private void Awake()
    {
        AnimatorPlayer = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (GetComponentInParent<EnemyMove>().IsAtacking == true)
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Die");
        }

    }
}

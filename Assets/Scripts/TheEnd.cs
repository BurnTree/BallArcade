using System;
using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Player))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

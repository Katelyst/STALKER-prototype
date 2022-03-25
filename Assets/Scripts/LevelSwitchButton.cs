using System;
using UnityEngine;
using Unity;
using UnityEditor;
using UnityEngine.SceneManagement;

public class LevelSwitchButton : MonoBehaviour
{
    public void LoadLevel(int index)
    {
        //LevelLoader.Instance.SwitchLevel(m_LevelToLoad);
        SceneManager.LoadScene(index);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            LoadLevel(0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LoadLevel(0);
        }
    }
}
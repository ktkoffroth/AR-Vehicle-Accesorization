using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMover : MonoBehaviour
{
    public GameObject box;

    private GameObject _box;
    void Start()
    {
        _box = Instantiate(box, new Vector3(0,1,0), Quaternion.Euler(0, 0, 0));
        _box.SetActive(false);
    }

    public void Position()
    {
        _box.transform.position += new Vector3(0,0.0625f,0);
    }
    
    public void Rotation()
    {
        _box.transform.position += new Vector3(0,-0.0625f,0);
    }

    public void Touch()
    {
        _box.transform.position = new Vector3(0, 1.1f, 0);
        _box.transform.rotation = Quaternion.Euler(0,90,0);
        _box.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{
    public GameObject State1;
    public GameObject State2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SwitchStates");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SwitchStates()
    {
        for (; ; )
        {
            State1.SetActive(!State1.activeInHierarchy);
            State2.SetActive(!State2.activeInHierarchy);
            yield return new WaitForSeconds(.5f);
        }
    }
}

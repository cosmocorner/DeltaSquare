using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public GameObject State1;
    public GameObject State2;
    public GameObject State3;
    public GameObject State4;

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
            if (State1.activeInHierarchy)
            {
                State1.SetActive(false);
                State2.SetActive(true);
                yield return new WaitForSeconds(.25f);
            }
            else if (State2.activeInHierarchy)
            {
                State2.SetActive(false);
                State3.SetActive(true);
                yield return new WaitForSeconds(.25f);
            }
            else if (State3.activeInHierarchy)
            {
                State3.SetActive(false);
                State4.SetActive(true);
                yield return new WaitForSeconds(.25f);
            }
            else
            {
                State4.SetActive(false);
                State1.SetActive(true);
                yield return new WaitForSeconds(.25f);
            }
        }
    }
}

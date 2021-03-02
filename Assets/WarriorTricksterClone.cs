using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorTricksterClone : MonoBehaviour
{
    WarriorTrickster wtScript;

    private void Start()
    {
        wtScript = GameObject.FindGameObjectWithTag("Player").GetComponent<WarriorTrickster>();
    }

    void Update()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3);
        wtScript.inInvisMode = false;
        Destroy(gameObject);
    }
}

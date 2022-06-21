using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandOverTime : MonoBehaviour
{

    //Is changing size?
    bool isChangingSize = false;
    //How long object expands over
    public float expandDuration = 1;

    public void ExpandObject()
    {
        StartCoroutine(Expand());
    }

    IEnumerator Expand()
    {

        Vector3 temp = transform.localScale;

        //Don't run if cloud is changing size
        if (isChangingSize)
            yield break;

        //Mark cloud as changing size
        isChangingSize = true;
        //How much time has elapsed
        float elapsedTime = 0;

        //Lerp the size from 0 to original size
        while (elapsedTime < expandDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(temp, Vector3.zero, elapsedTime / expandDuration);
            yield return null;
        }

        transform.position = new Vector3(-10, transform.position.y, transform.position.z);

        elapsedTime = 0;

        //Lerp the size from 0 to original size
        while (elapsedTime < expandDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, temp, elapsedTime / expandDuration);
            yield return null;
        }

        //Mark cloud as not changing size
        isChangingSize = false;
        yield break;
    }
}

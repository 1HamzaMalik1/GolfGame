using System.Collections;
using UnityEngine;

public class SmileToggler : MonoBehaviour
{
    public GameObject[] smileObjects;
    public float toggleDelay = 0.03f;

    private void Start()
    {
        StartCoroutine(ToggleSmiles());
    }

    private IEnumerator ToggleSmiles()
    {
        while (true)
        {
            for (int i = 0; i < smileObjects.Length; i++)
            {
                for (int j = 0; j < smileObjects.Length; j++)
                {
                    smileObjects[j].SetActive(false);
                }

                smileObjects[i].SetActive(true);
                yield return new WaitForSeconds(toggleDelay);
            }
        }
    }
}

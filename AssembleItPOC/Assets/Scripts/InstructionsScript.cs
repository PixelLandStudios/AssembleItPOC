using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InstructionsScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Steps;

    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnNext()
    {
        if (currentIndex + 1 == Steps.Count)
            return;

        //disable current video
        Steps[currentIndex].SetActive(false);

        Steps[currentIndex + 1].SetActive(true);
        Steps[currentIndex + 1].GetComponent<VideoPlayer>().Play();

        currentIndex++;
    }

    public void OnPrevious()
    {
        if (currentIndex == 0)
            return;

        //disable current video
        Steps[currentIndex].SetActive(false);

        Steps[currentIndex - 1].SetActive(true);
        Steps[currentIndex - 1].GetComponent<VideoPlayer>().Play();

        currentIndex--;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SliderHorizontal : MonoBehaviour
{
    [SerializeField] Transform fillarea;
    [SerializeField] float beginning;
    [SerializeField] float maxWidth;
    [SerializeField] float minWidth;

    private void Start()
    {
        fillarea.transform.localScale = new Vector3(beginning, fillarea.localScale.y, fillarea.localScale.z);
    }

    public void SetSlider(float percent)
    {
        float newBarWidth = (percent * maxWidth * 0.01f) + minWidth;
        fillarea.transform.localScale = new Vector3(newBarWidth, fillarea.localScale.y, fillarea.localScale.z);
    }
}

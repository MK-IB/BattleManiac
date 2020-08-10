using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpController : MonoBehaviour
{
    public GameObject largeGroundCanv;
    public GameObject circGroundCanv;
    public GameObject polyGroundCanv;
    public GameObject largeBarrierCanv;
    public GameObject greenEnvCanv;
    public GameObject desertEnvCanv;
    public GameObject snowEnvCanv;

    public void ShowLargeGroundCanv()
    {
        largeGroundCanv.SetActive(true);
    }

    public void ShowCircGroundCanv()
    {
        circGroundCanv.SetActive(true);
    }

    public void ShowPolyGroundCanv()
    {
        polyGroundCanv.SetActive(true);
    }

    public void ShowLargeBarrierCanv()
    {
        largeBarrierCanv.SetActive(true);
    }

    public void ShowGreenEnvCanv()
    {
        greenEnvCanv.SetActive(true);
    }

    public void ShowDesertEnvCanv()
    {
        desertEnvCanv.SetActive(true);
    }

    public void ShowSnowEnvCanv()
    {
        snowEnvCanv.SetActive(true);
    }
}

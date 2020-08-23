using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class NoAdsManager : MonoBehaviour
{

    public GameObject noAdsButton;
    public void OnAdsPurchaseComplete(Product product)
    {
        #if UNITY_EDITOR
            StartCoroutine(DisableIapButton());
        #else   
            noAdsButton.SetActive(false);
        #endif
        FindObjectOfType<MyUIManager>().HideNoAdsPanel();
    }

    public void OnAdsPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase failed due to" + reason);
    }

    IEnumerator DisableIapButton()
    {
        yield return new WaitForEndOfFrame();
        noAdsButton.SetActive(false);
    }
}

using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Category_Panel : MonoBehaviour
{
    public GameObject weaponSubCategory;
    public ContentSizeFitter fitter;
    public StoneTrigger stoneTrigger;

    public GameObject xRayIntersectorLeft;
    public GameObject xRayIntersectorRight;

    private void OnEnable()
    {
        xRayIntersectorLeft.SetActive(true);
        xRayIntersectorRight.SetActive(true);
    }

    private void OnDisable()
    {
        xRayIntersectorLeft.SetActive(false);
        xRayIntersectorRight.SetActive(false);
    }

    public void WeaponsClick()
    {
        weaponSubCategory.SetActive(!weaponSubCategory.activeInHierarchy);

        StartCoroutine(Fitter());

        IEnumerator Fitter()
        {
            yield return new WaitForSeconds(0.05f);

            fitter.enabled = false;

            yield return new WaitForSeconds(0.05f);

            fitter.enabled = true;
        }
    }

    public void PointsClick()
    {
    }

    public void InstrumentsClick()
    {
        gameObject.SetActive(false);
    }

    public async void GrabSphere()
    {
        if(!stoneTrigger.isGrab)
        {
            await Task.Delay(1000);

            if (gameObject.activeInHierarchy)
                stoneTrigger.GrabSphere();
            else
                stoneTrigger.ClearGrab();

            gameObject.SetActive(!gameObject.activeInHierarchy);

            stoneTrigger.isGrab = true;
        }
    }

    public void RestartClick()
    {
        SceneManager.LoadScene("Main");
    }
}
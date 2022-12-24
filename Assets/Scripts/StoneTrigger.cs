using DG.Tweening;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StoneTrigger : MonoBehaviour
{
    public ActionBasedContinuousMoveProvider moveProvider;
    public ActionBasedContinuousTurnProvider turnProvider;
    public LocomotionSystem locomotion;
    public XROrigin xROrigin;

    public Vector3 firstPosition;

    public XRInteractionManager interactionManager;
    public XRBaseInteractor baseInteractor;
    public XRBaseInteractable selectInteractable;

    public Category_Panel category_Panel;

    public bool isGrab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Equals("Box_A") && locomotion.enabled)
        {
            ActivePlayer(false);

            collision.transform.GetChild(0).gameObject.SetActive(true);
            collision.transform.GetChild(1).gameObject.SetActive(true);

            category_Panel.xRayIntersectorLeft.SetActive(true);
            category_Panel.xRayIntersectorRight.SetActive(true);

            SoundManager.Manager.victorySound.Play();
        }
        else if (collision.transform.name.Equals("Box_B") && locomotion.enabled)
        {
            ActivePlayer(false);

            collision.transform.GetChild(0).gameObject.SetActive(true);
            collision.transform.GetChild(1).gameObject.SetActive(true);

            category_Panel.xRayIntersectorLeft.SetActive(true);
            category_Panel.xRayIntersectorRight.SetActive(true);

            SoundManager.Manager.victorySound.Play();
        }
        else if (collision.transform.name.Equals("Box_C") && locomotion.enabled)
        {
            ActivePlayer(false);

            xROrigin.transform.DOMove(firstPosition, 1).OnComplete(OnCompleteTween).SetDelay(1);
        }
    }

    public void ClearGrab()
    {
        interactionManager.SelectExit(baseInteractor, (IXRSelectInteractable)selectInteractable);

        gameObject.SetActive(false);
    }

    public void GrabSphere()
    {
        gameObject.SetActive(true);

        interactionManager.SelectEnter(baseInteractor, (IXRSelectInteractable)selectInteractable);

        Debug.Log("AutoGrab");
    }

    void OnCompleteTween()
    {
        ActivePlayer(true);

        isGrab = false;

        interactionManager.SelectEnter(baseInteractor, (IXRSelectInteractable)selectInteractable);

        Debug.Log("AutoGrab");
    }

    void ActivePlayer(bool value)
    {
        moveProvider.enabled = value;
        turnProvider.enabled = value;
        locomotion.enabled = value;
        xROrigin.enabled = value;
    }
}
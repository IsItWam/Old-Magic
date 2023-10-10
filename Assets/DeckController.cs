using UnityEngine;
using System.Collections;

public class DeckController : MonoBehaviour
{
    public GameObject cardDrawer; 
    public Vector3 hiddenPosition; 
    public Vector3 visiblePosition; 
    public float transitionSpeed = 2.0f; 

    private bool isDrawerOpen = false; 

    private void OnMouseDown()
    {
        if (!isDrawerOpen)
        {
            OpenDrawer();
        }
        else
        {
            CloseDrawer();
        }
    }

    private void OpenDrawer()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDrawer(visiblePosition));
        isDrawerOpen = true;
    }

    private void CloseDrawer()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDrawer(hiddenPosition));
        isDrawerOpen = false;
    }

    private IEnumerator MoveDrawer(Vector3 targetPosition)
    {
        while (Vector3.Distance(cardDrawer.transform.position, targetPosition) > 0.01f)
        {
            cardDrawer.transform.position = Vector3.Lerp(cardDrawer.transform.position, targetPosition, transitionSpeed * Time.deltaTime);
            yield return null;
        }
        cardDrawer.transform.position = targetPosition;
    }
    
    private void Update()
    {
        if (isDrawerOpen && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit) || (hit.transform != cardDrawer.transform && hit.transform != this.transform))
            {
                CloseDrawer();
            }
        }
    }

}

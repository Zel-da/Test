using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    //움직이는 시간
    public float moveDuration = 1f;
    //움직이는 기준
    public Transform doorHinge;

    //닫힐 각도= 0
    private Quaternion closedRotation;
    //열릴 각도= 60
    private Quaternion openRotation;

    private void Start()
    {
        closedRotation = doorHinge.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, 60f, 0);
    }

    public System.Collections.IEnumerator DoorMoveOpen()
    {
        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            doorHinge.rotation = Quaternion.Lerp(closedRotation, openRotation, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        doorHinge.rotation = openRotation;
    }


    public System.Collections.IEnumerator DoorMoveClose()
    {
        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            doorHinge.rotation = Quaternion.Lerp(openRotation,closedRotation,  elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        doorHinge.rotation = closedRotation;
    }
}

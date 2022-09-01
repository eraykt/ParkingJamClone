using System.Collections;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
   private void OnTriggerExit(Collider other)
   {
      if (other.CompareTag("Car"))
      {
         Debug.Log("success");
         StartCoroutine(DeleteCar(other.gameObject));
      }
   }

   IEnumerator DeleteCar(GameObject car)
   {
      yield return new WaitForSeconds(1f);
      Destroy(car);
      yield return null;
   }
}

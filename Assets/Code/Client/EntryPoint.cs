using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Code
{
    public class EntryPoint : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(CreateLobby());
        }

        private IEnumerator CreateLobby()
        {
            using (var request = UnityWebRequest.Get("http://localhost:5211/create/"))
            {
                yield return request.SendWebRequest();
                
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
}

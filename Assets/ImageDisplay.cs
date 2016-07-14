using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ImageDisplay : MonoBehaviour {


	private string _imageURL;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadImage (string imageURL) {

		if ( string.IsNullOrEmpty( imageURL ) ) {
			Debug.Log ("No image url provided");
			return;
		}
		_imageURL = imageURL;
		StartCoroutine ("DownloadImage");
	}

	IEnumerator DownloadImage () {
		Debug.Log ( "Time to download the image:" + _imageURL );
		string url = "https://voyage-monsieur-19397.herokuapp.com/image?url=" + WWW.EscapeURL (_imageURL);
		Debug.Log ("Proxying request: " + url);
		UnityWebRequest request = UnityWebRequest.GetTexture (url);
		yield return request.Send ();

		if (request.isError) {
			Debug.Log ("Request error: " + request.error);
			return false;
		}
		Texture imageTexture = DownloadHandlerTexture.GetContent (request);
		Debug.Log ("Received texture?: " + imageTexture);

		Transform transform = GetComponent<Transform> ();
		float aspect = (float)imageTexture.width / (float)imageTexture.height;

		Debug.Log ("Image aspect ratio: " + aspect);
		Renderer renderer = GetComponent<Renderer> ();
		renderer.material.mainTexture = imageTexture;
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using SimpleJSON;

public class WordPressClient : MonoBehaviour {

	const string URL = "https://public-api.wordpress.com/rest/v1.1/sites/en.blog.wordpress.com/posts?number=5";
	// Use this for initialization
	void Start () {
		StartCoroutine ("GetPosts");
	}

	IEnumerator GetPosts() {
		UnityWebRequest request = UnityWebRequest.Get (URL);
		Debug.Log ("Requesting data from" + URL);
		yield return request.Send ();

		if (request.isError) {
			Debug.Log (request.error);
		} else {
			// TODO: do this in a coroutine
			Debug.Log ("Response received?" + request.responseCode);

			JSONNode node = JSON.Parse (request.downloadHandler.text);
			int found = node ["found"].AsInt;
			JSONArray posts = node ["posts"].AsArray;
			Debug.Log ("Found: " + found);

			GameObject obj = GameObject.FindWithTag ("Image");
			ImageDisplay image = obj.GetComponent<ImageDisplay> ();
			image.LoadImage ((string) posts[0]["featured_image"]);

			foreach (JSONNode postNode in posts) {
				string featured_image = (string) postNode ["featured_image"];
				Debug.Log ("An Image: " + featured_image);
			}
			/***
			 * SitePostList postList = JsonUtility.FromJson<SitePostList> (request.downloadHandler.text);
			Debug.Log (postList.found);

			GameObject obj = GameObject.FindWithTag ("Image");
			ImageDisplay image = obj.GetComponent<ImageDisplay> ();
			Post mainPost = postList.posts [0];
			Debug.Log ("Post id: " + mainPost.ID);
			Debug.Log ("Post image: " + mainPost.featured_image);
			image.LoadImage (mainPost.featured_image);
			foreach (Post post in postList.posts) {
				Debug.Log ("Featured image: " + post.featured_image);
			}
			**/
		}
	}

}

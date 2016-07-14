using System;
using System.Collections.Generic;

[Serializable]
public class Post {
	public string ID;
	public string site_ID;
	public string title;
	public string URL;
	public string short_URL;
	public string content;
	public string excerpt;
	public string slug;
	public string guid;
	public string status;
	public bool sticky;
	public string type;
	public string featured_image;

	public PostThumbnail post_thumbnail;
	public PostAuthor author;
	public Dictionary<string, PostAttachment> attachments;

	public int attachment_count;
}

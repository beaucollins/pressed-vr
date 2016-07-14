using System;
using System.Collections.Generic;

[Serializable]
public class PostAttachment
{
	public string ID;
	public string URL;
	public string guid;
	public string date;
	public string post_ID;
	public string author_ID;
	public string file;
	public string mime_type;
	public string extension;
	public string title;
	public string caption;
	public string description;
	public string alt;
	public Dictionary<string, string> thumbnails;
	public int height;
	public int width;
	public Dictionary<string, string> exif;
}


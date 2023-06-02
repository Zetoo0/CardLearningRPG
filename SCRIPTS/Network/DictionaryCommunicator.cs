using Godot;
using System;
using System.Text;
using Godot.Collections;
using Godot;

public partial class DictionaryCommunicator : Node
{

	public override void _Ready()
	{
		// Create an HTTP request node and connect its completion signal.
		var httpRequest = new HttpRequest();
		AddChild(httpRequest);
		httpRequest.RequestCompleted += HttpRequestCompleted;

		bool fas = false;
		/*Dictionary<object, object> data = new Dictionary<object, object>();
		data.Add("query", "takai");
		data.Add("language", "English");
		data.Add("no_english", fas);
		*/GD.Print("diksz");
		// Perform a GET request. The URL below returns JSON as of writing.
		//Error error = httpRequest.Request("https://httpbin.org/get");
		//if (error != Error.Ok)
		//{
		//	GD.PushError("An error occurred in the HTTP request.");
		//}

		// Perform a POST request. The URL below returns JSON as of writing.
		// Note: Don't make simultaneous requests using a single HTTPRequest node.
		// The snippet below is provided for reference only.
		Json jason = new Json();

		var dict = new Dictionary(){ { "query", "takai" }, { "language", "English" }, { "no_english", false } };
		string body = Json.Stringify(dict);

	string[] head = {"accept: application/json", "content-type: application/json"};
		GD.Print("diksz");
		Error error = httpRequest.Request("https://jotoba.de/api/search/words", head, HttpClient.Method.Post, body);
		if (error != Error.Ok)
		{
			GD.PushError("An error occurred in the HTTP request.");
		}
		GD.Print("diksz");
	}

// Called when the HTTP request is completed.
	private void HttpRequestCompleted(long result, long responseCode, string[] headers, byte[] body)
	{
		GD.Print("dikszcompl");
		var json = new Json();
		json.Parse(body.GetStringFromUtf8());
		var response = json.Data.AsGodotDictionary();
		var kanjiDic = response["kanji"];
		var _KanjiLiteral = kanjiDic.AsGodotArray()[0].AsGodotDictionary()["literal"];
		// Will print the user agent string used by the HTTPRequest node (as recognized by httpbin.org).
		
		
		GD.Print(_KanjiLiteral);
	}

/*	public override void _Ready()
	{
		
		



		string[] dataToSend = {"takai", "English","false"};
		string json = Json.Stringify(dataToSend);
		string url = "https://jotoba.de/api/search/words";
		string[] headers = new string[] { "content-type: application/json", "accept: application/json" };
		HttpRequest httpRequest = GetNode<HttpRequest>("HTTPRequest");
		httpRequest.Request(url, headers, HttpClient.Method.Post, json);
*/	}		

	

	
	



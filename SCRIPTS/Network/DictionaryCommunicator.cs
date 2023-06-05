using Godot;
using System;
using System.Text;
using Godot.Collections;
using Godot;

public partial class DictionaryCommunicator : Node
{
	private string kanjiForReturn;
	private Label lb;

	public void SetLabel(Label lb)
	{
		this.lb = lb;
	}

	/// <summary>
	/// Get the kanji form from the API
	/// </summary>
	/// <param name="romaji"></param>
	/// <returns></returns>
	public void GetKanjiByRomaji(string romaji) {
		
	//	*/GD.Print(romaji);
	
		HttpRequest httpRequest = new HttpRequest();
		//GD.Print(httpRequest.ToString());
		AddChild(httpRequest);
		httpRequest.RequestCompleted += HttpRequestCompleted;
		
		
		var dict = new Dictionary(){ { "query", romaji }, { "language", "English" }, { "no_english", false } };
		
		string body = Json.Stringify(dict);
		
		string[] head = {"accept: application/json", "content-type: application/json"};
		
		Error error = httpRequest.Request("https://jotoba.de/api/search/words", head, HttpClient.Method.Post, body);
		
		if (error != Error.Ok)
		{
			GD.PushError("An error occurred in the HTTP request.");
		}

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
		string[] meanings = kanjiDic.AsGodotArray()[0].AsGodotDictionary()["meanings"].AsStringArray();

		CardLabelDataSetter.actualKanji = _KanjiLiteral.ToString();
		lb.Text = CardLabelDataSetter.actualKanji;
		CardRes.CreateAndAddCardToDaDeck(CardLabelDataSetter.actualKanji,CardLabelDataSetter.actualRomaji,meanings);
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

	

	
	



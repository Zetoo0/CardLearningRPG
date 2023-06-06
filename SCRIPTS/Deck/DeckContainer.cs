using Godot;
using System;

public partial class DeckContainer : VFlowContainer
{
	public void _On_Add_Press()
	{
		Label lb = new Label();
		lb.Text = CardLabelDataSetter.actualRomaji;	
		GD.Print("asd");
		AddChild(lb);
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Label lb = new Label();
		lb.Text = "apd";
		Label lb1 = new Label();
		lb1.Text = "aynd";
		AddChild(lb);
		AddChild(lb1);
		//DeckHandle();
		DeckHandle.CreateDeckResource();
	}

	



}

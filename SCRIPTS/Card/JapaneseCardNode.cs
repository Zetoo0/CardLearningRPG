using Godot;
using System;

public partial class JapaneseCardNode : Label
{
	private Label _label;
	private JapaneseCard JP_Card;
	/*public override void _Ready()
	{
		JP_Card = CardBuilder.createJapaneseCard();
		GD.Print(JP_Card.GetCardName());
		//_label = this.GetNode<Label>("CardNameLb");
		this.Text = JP_Card.GetCardName();

	}*/
}

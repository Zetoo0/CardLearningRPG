using Godot;
using System;

public interface IItemListItem
{
	void _SetSelectedItemText(string text);

	static String _GetSelectedItemText() {
		return "";
	}

}

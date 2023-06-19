using Godot;
using System;

public interface IAnswerChecker
{
	private bool IsAnswerOK(string task, string solution, string userAnswer) {
		return true;
	}
}

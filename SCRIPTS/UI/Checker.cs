namespace learningERpig.SCRIPTS.UI;

public abstract class Checker {
    private string solution;
    private string userAnswer;
    private static CardRes currentCard;
    

    public static void SetCurrentCard(CardRes currCard) {
        currentCard = currCard;
    }
	
	
    public bool IsAnswerOK(string solution,string userAnswer)
    {
        bool isOk = userAnswer == solution ? true : false;
        return isOk;
    }
    
}
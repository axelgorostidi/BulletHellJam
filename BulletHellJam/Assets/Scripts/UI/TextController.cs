

public static class TextController
{
    
    public static string GameOverUIGameTime()
    {
        if(GameController.instance.textLanguage == GameController.TextLanguage.Spanish)
            return "TIEMPO SOBREVIVIDO: " + FormatTimeToText(GameController.instance.GetCurrentGameTime());
        else
            return "TIME SURVIVED: " + FormatTimeToText(GameController.instance.GetCurrentGameTime());
    }

    public static string GameOverUIEnemiesDestroyed()
    {
        if(GameController.instance.textLanguage == GameController.TextLanguage.Spanish)
            return "ENEMIGOS DESTRUIDOS: " + GameController.instance.GetEnemiesDestroyed();
        else
            return "ENEMIES DESTOYED: " + GameController.instance.GetEnemiesDestroyed();
    }


    public static string FormatTimeToText(float currentTime)
    {
        int minutes = (int)(currentTime/60);
        int seconds = (int)(currentTime%60);
        
        string minutesText = minutes.ToString();
        if(minutes<10)
            minutesText = "0"+minutes.ToString();

        string secondsText = seconds.ToString();
        if(seconds<10)
            secondsText = "0"+seconds.ToString();

        return minutesText+":"+secondsText;
    }

    public static string UserNameError()
    {
        if(GameController.instance.textLanguage == GameController.TextLanguage.Spanish)
        {
            return "El nombre de usuario no puede estar vacío ni contener * o tener más de 10 caracteres";
        }
        else
        {
            return "The user name can't be empty, contain * or more than 10 characters";
        }
    }

    public static string GameOverScoreText()
    {
        if(GameController.instance.textLanguage == GameController.TextLanguage.Spanish)
        {
            return "Puntaje: " + GameController.instance.GetFinalScore();
        }
        else
        {
            return "Score: " + GameController.instance.GetFinalScore();
        }
    }

    public static string HighScoreText(int score)
    {
        if(GameController.instance.textLanguage == GameController.TextLanguage.Spanish)
        {
            return "Puntaje máximo: " + score;
        }
        else
        {
            return "High score: " + score;
        }
        
    }
}

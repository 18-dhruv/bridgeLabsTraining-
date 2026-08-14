using System.Text.RegularExpressions;


namespace Regres;

public class EmailVerifier:IStringCleaner
{
    public bool IsStringCorrect(string s)
    {
       
        string d = s.Trim();
        bool bro=Regex.IsMatch(d, @"^[\w\.-]+@[\w\.-]+\.[A-Za-z]{2,}$");
        return bro;
    }
}
namespace Bankkonsoll_applikation_inlämningsuppgift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User Richard = new User();
            Richard.savingsAccount = new SavingsAccount(1111, "Richards Sparkonto");
            Richard.personalAccount = new personalAccount(2222,"Richards Personkonto");
            Richard.investingsAccount = new InvestingsAccount(3333,"Richards investeringskonto");


            MainMenu mainMenu = new MainMenu();
            mainMenu.mainMenu(Richard);
            
        }
    }
}

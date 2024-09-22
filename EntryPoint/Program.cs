using EntryPoint.Utils;

namespace EntryPoint
{
    class EntryPoint
    {
        public static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            
            mainMenu.Run();
        }
    }
}
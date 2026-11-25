namespace ZooDirector;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new ГлавнаяФорма());
    }
}


/* В нашей консольной версии Program.cs отвечает за интерфейс и порядок действий:
1. Просит ввести имя директора.
2. Создаёт зоопарк и директора.
3. Показывает меню.
4. Считывает выбор пользователя.
5. Вызывает нужный метод */

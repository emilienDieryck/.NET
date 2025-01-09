using System;

class Logger
{

    public delegate void LogHandler(string message);

    public LogHandler Log;

    public void LogMessage(string message)
    {
        Log?.Invoke(message);
    }

}

class ConsoleLogger
{
    public void HandleLog(string message)
    {
        Console.WriteLine($"[ConsoleLogger]: {message}");
    }
}


class FileLogger
{
    private readonly string filePath;

    public FileLogger(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("Le chemin du fichier ne peut pas etre vide.", nameof(filePath));
        }

        this.filePath = filePath;

        // création du fichier s'il n'existe pas
        if (!File.Exists(filePath))
        {
            using (var stream = File.Create(filePath)) { }
        }

    }

    public void HandleLog(string message) 
    {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine($"{DateTime.Now:G}: {message}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"erreur lors de l'écriture dans le fichier : {ex.Message}");
            }
    }
}

class Test
{
    public static void Main(string[] args)
    {
        // Initialisation des loggers
        Logger logger = new Logger();
        ConsoleLogger consoleLogger = new ConsoleLogger();
        FileLogger fileLogger = new FileLogger("log.txt");

        // Enregistrement des loggers
        logger.Log += consoleLogger.HandleLog; // Logger dans la console
        logger.Log += fileLogger.HandleLog;    // Logger dans un fichier

        // Test des logs
        logger.LogMessage("Ceci est un message de test.");
        logger.LogMessage("Un autre message à logger.");

        Console.WriteLine("Les logs ont été écrits avec succès.");
    }
}
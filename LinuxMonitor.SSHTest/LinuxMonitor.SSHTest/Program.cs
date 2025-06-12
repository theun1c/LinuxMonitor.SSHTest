using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace LinuxMonitor.SSHTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // нужно указать параметры 
            using (var client = new SshClient("ip", "username", "password"))
            {
                client.Connect(); // <-- подключаемся

                Console.WriteLine("подключение установлено");

                var cmd = client.CreateCommand("cd /media/sf_main-astra/LinuxMonitor/LinuxMonitor/LinuxMonitor && dotnet run"); // <-- по этому пути на виртуалке находится проект
                var execute = cmd.Execute(); // <-- получение строки после выполнения
                Console.WriteLine(execute); // <-- тут может быть обработка
                
                client.Disconnect(); // <-- завершение подключения
            }
        }
    }
}

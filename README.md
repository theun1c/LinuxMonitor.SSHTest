# Тестовый проект для подключения к серверу по ssh
### Описание (кратко)
На сервере (astra linux) лежит проект [LinuxMonitor](https://github.com/theun1c/LinuxMonitor) <br> 
Хранится он по следующему пути: <br>
``` bash
/media/sf_main-astra/LinuxMonitor/LinuxMonitor/LinuxMonitor
```
<br>
Необходимо средствами ssh подключения собрать и запустить проект с удаленного сервера, при этом получить данные из консоли. 
<br>

Пример подключения и получения данных консоли с использованием [SSH.NET](https://www.nuget.org/packages/SSH.NET/2025.0.0?_src=template)
``` csharp
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
```

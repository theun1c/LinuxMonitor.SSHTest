# Тестовый проект для подключения к серверу по ssh

на сервере (astra linux) лежит проект [LinuxMonitor](https://github.com/theun1c/LinuxMonitor). <br> 
хранится он по следующему пути: <br>
``` bash
/media/sf_main-astra/LinuxMonitor/LinuxMonitor/LinuxMonitor
```
<br>
необходимо средствами ssh подключения собрать и запустить проект с удаленного сервера, при этом получить данные из консоли. 

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

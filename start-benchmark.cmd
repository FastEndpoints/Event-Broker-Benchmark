start cmd.exe /C "cd Broker & title Broker & dotnet run"
start cmd.exe /C "cd Subscriber & title Subscriber & dotnet run"
start cmd.exe /C "cd Publisher & title Publisher & dotnet run"
start http://localhost:5000
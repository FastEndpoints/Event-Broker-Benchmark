start cmd.exe /C "cd Broker & title Broker & dotnet run -c Release"
start cmd.exe /C "cd Subscriber & title Subscriber & dotnet run -c Release"
start cmd.exe /C "cd Publisher & title Publisher & dotnet run -c Release"
start http://localhost:5000
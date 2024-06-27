# tareasapp
desafio tareas app


![.NET](https://img.shields.io/badge/.NET-7.0.0-green)
![Vuetify Cli](https://img.shields.io/badge/Vuetify/cli-3.0.4-green)
![Vue](https://img.shields.io/badge/Vue-3.2.45-green)
![TypeScript](https://img.shields.io/badge/TypeScript-4.1.2-green)

## Instalacion wn windows

+ bajar el codigo y compilar
  ```PowerShell
  cd C:\
  wget -Uri https://github.com/GabrielLadino/tareasapp/archive/refs/heads/main.zip  -OutFile main.zip
  Expand-Archive -Path C:\main.zip -DestinationPath C:\
  ```
  + Instalar .NET SDK y NodeJS
  ```CMD
  wget -Uri https://download.visualstudio.microsoft.com/download/pr/35660869-0942-4c5d-8692-6e0d4040137a/4921a36b578d8358dac4c27598519832/dotnet-sdk-7.0.101-win-x64.exe  -OutFile dotnet-sdk-7.0.101-win-x64.exe
  .\dotnet-sdk-7.0.101-win-x64.exe /install /quiet /norestart
  wget -Uri https://nodejs.org/dist/v16.13.1/node-v16.13.1-x64.msi  -OutFile node-v16.13.1-x64.msi
  msiexec /i .\node-v16.13.1-x64.msi /passive /norestart
  npm install -g yarn
  ```
+ Compilar el back y el front
      ```
  md C:\tareasapp\frontend\
  md C:\tareasapp\backend\
  cd C:\tareasapp-main\backend
  dotnet publish 
  copy-item -path "C:\tareasapp-main\backend\tarea\bin\Release\net8.0\publish\*" -destination "C:\tareasapp\backend\" -recurse
  cd C:\tareasapp-main\tareaApp  
  yarn
  yarn build 
  copy-item -path "C:\tareasapp-main\tareaApp\dist\*" -destination "C:\tareasapp\frontend\" -recurse
  ```
  + instalar Nginx
   ```
  cd C:\
  wget -Uri http://nginx.org/download/nginx-1.16.1.zip -OutFile nginx-1.16.1.zip
  Expand-Archive -Path C:\nginx-1.16.1.zip -DestinationPath C:\
  copy-item -path "C:\tareasapp\frontend\*" -destination "C:\nginx-1.16.1\html\" -recurse
  cd C:\nginx-1.16.1\
  start nginx.exe
  cd C:\tareasapp\backend\
  dotnet TareaApp.dll --urls http://0.0.0.0:20011
  ```

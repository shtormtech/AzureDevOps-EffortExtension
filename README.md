# Effort extension project

Проект для создания расширения Azure DevOps server, позволящего исполнителю работ указывать не только винальные трудозатраты, но и временные интервалы.
### Prerequisites
VisualStudio
Docker Desktop for Windows or Docker Toolbox.

### Stack
.NetCore 2.2  
TypeScript  
ReactJS  
PostgreSQL  

## Getting Started
Получить исходники
```powershell
git clone https://github.com/Iloer/effort-extension.git
cd effort-extension
```

Собрать и запустить проекты
```powershell
docker build -f .\LocalDB\dockerfile.postgres -t effortdb .
docker build -f .\EffortAPIService\Dockerfile -t effortapiservice .
docker-compose up
```

Запустить только базу данных
```powershell
docker run -p 5432:5432 --name effortdb --hostname effortdb -e "POSTGRES_PASSWORD=postgres" -d effortdb
```

Запустить только API сервис
```powershell
docker run -p 31501:80 --name effortapiservice-dev --rm effortapiservice -e "ConnectionStrings:DefaultConnection=Host=effortdb;Port=5432;Database=postgres;Username=postgres;Password=postgres"
```
Сервис будет доступен по адресу: http://localhost:31501/index.html

> !!!ВАЖНО: В случае запуска по отдельности базы данных и сервиса, БД не будет доступна по HostName, нужно определить локальный IP адрес машины с БД и подставить его в DefaultConnection. Например командой "docker inspect effortdb"


## Effort API service
Сервис для записи и чтения данных в БД храненения списаний.

## Effort-extension
TypeScript React приложение для отображения информации о списаниях и форма списания времени.
Работает как в браузере, так и упаковывается в в расширение для Azure DevOps server

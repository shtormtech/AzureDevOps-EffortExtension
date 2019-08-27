# Effort extension project

ѕроект дл€ создани€ расширени€ Azure DevOps server, позвол€щего исполнителю работ указывать не только винальные трудозатраты, но и временные интервалы.
### Prerequisites

Docker Desktop for Windows or Docker Toolbox.

## Getting Started

```powershell
git clone https://github.com/Iloer/effort-extension.git
cd effort-extension
```

### Run Effort DB
```powershell
docker build -f .\LocalDB\dockerfile.postgres -t effortdb .
docker run -p 5432:5432 --name effortdb --hostname effortdb -e "POSTGRES_PASSWORD=postgres" -d effortdb
```

### Run Effort API service
```powershell
docker build -f .\EffortAPIService\Dockerfile -t effortapiservice .
docker run -p 31501:80 --name effortapiservice-dev --rm effortapiservice -e "ConnectionStrings:DefaultConnection=Host=effortdb;Port=5432;Database=postgres;Username=postgres;Password=postgres"
```
—ервис будет доступен по адресу: http://localhost:31501/index.html

## Effort API service
—ервис дл€ записи и чтени€ данных в Ѕƒ храненени€ списаний.

## Effort-extension
TypeScript React приложение дл€ отображени€ информации о списани€х и форма списани€ времени.
–аботает как в браузере, так и упаковываетс€ в в расширение дл€ Azure DevOps server

# Effort extension project

ѕроект дл€ создани€ расширени€ Azure DevOps server, позвол€щего исполнителю работ указывать не только винальные трудозатраты, но и временные интервалы.
### Prerequisites

Docker Desktop for Windows or Docker Toolbox.

## Getting Started

```bash
git clone https://github.com/Iloer/effort-extension.git
cd effort-extension
docker build -f .\EffortAPIService\Dockerfile -t effortapiservice .
docker run -p 31501:80 --name effortapiservice-dev --rm effortapiservice
```
—ервис будет доступен по адресу: http://localhost:31501/index.html

## Effort API service
—ервис дл€ записи и чтени€ данных в Ѕƒ храненени€ списаний.

## Effort-extension
TypeScript React приложение дл€ отображени€ информации о списани€х и форма списани€ времени.
–аботает как в браузере, так и упаковываетс€ в в расширение дл€ Azure DevOps server

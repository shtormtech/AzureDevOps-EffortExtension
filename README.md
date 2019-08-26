# Effort extension project

Проект для создания расширения Azure DevOps server, позволящего исполнителю работ указывать не только винальные трудозатраты, но и временные интервалы.

## Getting Started

```bash
git clone https://github.com/Iloer/effort-extension.git
cd effort-extension
docker build -f .\EffortAPIService\Dockerfile -t effortapiservice .
docker run -p 31501:80 --name effortapiservice-dev --rm effortapiservice
```
Сервис будет доступен по адресу: http://localhost:31501/index.html

### Prerequisites

Docker Desktop for Windows or Docker Toolbox.

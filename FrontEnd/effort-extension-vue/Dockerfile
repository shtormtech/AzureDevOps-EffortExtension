# Базовый образ node
FROM node AS build
# Устанавливаем рабочую дирректорию
WORKDIR /app
USER 0
COPY package*.json ./
RUN npm install
COPY ./ .
RUN npm run build
# Получаем базовый образ nginx
FROM nginx
RUN mkdir /app
# Копируем полученные после сборки файлы в образ nginx
COPY --from=build /app/dist /app
COPY nginx.conf /etc/nginx/nginx.conf
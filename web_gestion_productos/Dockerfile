FROM node:22.18.0-bullseye as build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build -- --configuration production

FROM nginx:alpine
COPY ./config/default.conf /etc/nginx/conf.d/default.conf
COPY --from=build /app/dist/web_gestion_productos/browser /var/www/app/
EXPOSE 80
CMD ["nginx","-g","daemon off;"]
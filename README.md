# API-Gateway-Hub
Простой шлюз предназначенный для межсервисного общения, с подключенным identity.

Основная логика расположена по пути: [path](https://github.com/Alexandrjob/API-Gateway-Hub/tree/master/GatewayWebApp/src/Infrastructure/Infrastructure/Configuration/Middlewares)

А именно в двух middleware RequestRedirectIdentityMiddleware.cs RequestRedirectPersonalityMiddleware.cs

Они служат шлюзом и производят общение с сервисами WebApplicationAPI WebApplicationIdentityAPI

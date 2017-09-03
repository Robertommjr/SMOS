var app = angular.module('app', [
    'ngRoute'
]);

app.config(function ($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $locationProvider.html5Mode(false);

    $routeProvider
        .when("/Sobre", {
            templateUrl: "Home/Sobre",
            controller: 'ContatoCtrl'
        })
        .when("/Contato", {
            templateUrl: "Home/Contato",
            controller: 'SobreCtrl'
        })
        .when("/Auth", {
            templateUrl: "auth/logIn",
            controller: 'AuthCtrl'
        })


        .otherwise({redirectTo: '/'})
});
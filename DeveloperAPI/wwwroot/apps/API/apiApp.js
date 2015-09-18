window.apiApp = angular.module('apiApp', [
        // Angular modules 
        'ngRoute'

        // Custom modules 

        // 3rd Party Modules

])
.config(function ($routeProvider, $locationProvider) {
    //configure angular routing here
    $routeProvider.when('/api/register', { templateUrl: '/apps/API/View/registration.html', controller: 'registrationViewModel' })
        .when('/api/update', { templateUrl: '/apps/API/View/registration.html', controller: 'registrationViewModel' })
        .otherwise({ redirectTo: '/' });
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
});
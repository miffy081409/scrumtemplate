window.searchApp = angular.module('searchApp', [
        // Angular modules 
        'ngRoute'

        // Custom modules 

        // 3rd Party Modules

])
.config(function ($routeProvider, $locationProvider) {
    //configure angular routing here
    $routeProvider.when('/', { templateUrl: '/apps/Search/View/default.html', controller: 'defaultViewModel' })
        .when('/api-documentation', { templateUrl: '/apps/Search/View/apiPageDocumentation.html', controller: 'apiPageDocumentationViewModel' })
        .when('/search', { templateUrl: '/apps/Search/View/searchResults.html' })
        .otherwise({ redirectTo: '/' });
    //$locationProvider.hashPrefix('!').html5Mode(true);
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
});


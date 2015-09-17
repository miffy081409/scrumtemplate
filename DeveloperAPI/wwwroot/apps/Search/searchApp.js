﻿//(function () {
//    'use strict';

//    angular.module('indexApp', [
//        // Angular modules 
//        'ngRoute'

//        // Custom modules 

//        // 3rd Party Modules
        
//    ]).config(function ($routeProvider, $locationProvider) {
//        //configure angular routing here
//        $routeProvider.when('/', {templateUrl:'/View/default.html'})
//        $locationProvider.html5Mode(true);
//    });
//})();


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
        .otherwise({ redirectTo: '/' });
    //$locationProvider.hashPrefix('!').html5Mode(true);
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
});


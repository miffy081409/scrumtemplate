//(function () {
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
    $routeProvider.when('/', { templateUrl: '/apps/Search/View/default.html', controller: 'defaultViewModel' });
    $routeProvider.when('/documentation/api', { templateUrl: '/apps/Search/View/apiPageDocumentation.html', controller: 'apiPageDocumentationViewModel' });
    $routeProvider.otherwise({ redirectTo:'/'});
    //$locationProvider.html5Mode(true);
});


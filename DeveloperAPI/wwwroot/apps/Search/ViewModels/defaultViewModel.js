var searchAppModule = window.searchApp;

searchAppModule.controller("defaultViewModel", function ($scope, $http, apiModel) {
    
    $scope.topAPIs = new Array();
    $scope.pageHeading = "Top 10 Most Used API";
    
    $scope.topAPIs = apiModel.getData();//this is from services
});
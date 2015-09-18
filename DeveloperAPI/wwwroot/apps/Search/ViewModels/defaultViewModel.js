var searchAppModule = window.searchApp;

searchAppModule.controller("defaultViewModel", function ($rootScope, $scope, $http, apiModel) {
    
    //reset search keyword once go back to home page
    $rootScope.$broadcast('resetKeywordPlease', {});

    $scope.topAPIs = new Array();
    $scope.pageHeading = "Top 10 Most Used API";
    
    $scope.topAPIs = apiModel.getData();//this is from services
});
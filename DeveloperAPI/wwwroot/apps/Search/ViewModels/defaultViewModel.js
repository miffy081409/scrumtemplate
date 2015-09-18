var searchAppModule = window.searchApp;

searchAppModule.controller("defaultViewModel", function ($rootScope, $scope, $http, apiModel) {
    
    //reset search keyword once go back to home page
    $scope.topAPIs = new Array();
    $scope.pageHeading = '';
    
    initVM();

    function initVM() {
        $rootScope.$broadcast('resetKeywordPlease', {});
        loadTop10();
    }

    function loadTop10() {
        $scope.pageHeading = "Top 10 Most Used API";
        $scope.topAPIs = apiModel.getData();//this is from services
    }
});
var searchAppModule = window.searchApp;

searchAppModule.controller("defaultViewModel", function ($rootScope, $scope, apiModel) {
    
    //reset search keyword once go back to home page
    $scope.topAPIs = new Array();
    $scope.pageHeading = '';
    
    initVM();

    function initVM() {
        $rootScope.$broadcast('resetKeywordPlease', {});
        loadTop10();
    }

    function loadTop10() {
        //start loading gif here
        $scope.pageHeading = "Yo! Welcome to Developer API documentation page. Unfortunately we can't give you any documentation right now co'z we are still developing our api. You are also allowed to save your api documentation here. Just click the Register Your API at the bottom of this page.";
        //first param is a flag whether to hardcoded test data or not
        apiModel.getData(false, function (data) {
            $scope.topAPIs = data;
            if ($scope.length > 0)
            {
                $scope.pageHeading = "Top 10 Most Used API";
            }
            //stop loading gif here
        });//this is from services

    }
});
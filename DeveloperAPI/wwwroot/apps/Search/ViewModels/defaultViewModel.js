var searchAppModule = window.searchApp;

searchAppModule.controller("defaultViewModel", function ($rootScope, $scope, apiModel) {
    
    //reset search keyword once go back to home page
    $scope.topAPIs = null;
    $scope.pageHeading = '';
    
    initVM();

    function initVM() {
        $rootScope.$broadcast('resetKeywordPlease', {});
        loadLatestApi();
    }

    function loadLatestApi() {

        $scope.pageHeading = "Yo! Welcome to Developer API documentation page. Unfortunately we can't give you any documentation right now co'z we are still developing our api. You are also allowed to save your api documentation here. Just click the Register Your API at the bottom of this page.";
        //start loading gif here
        //first param is a flag whether to hardcoded test data or not
        
        //check here why angular cache my data
        apiModel.getLatestApi(10, function (data) {
            if (data.length > 0) {
                $scope.topAPIs = data;
                $scope.pageHeading = "Most Recent APIs";
            }
            
            //stop loading gif here
        });//this is from services

    }
});
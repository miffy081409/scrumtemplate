var searchAppModule = window.searchApp;

searchAppModule.controller("searchViewModel", function ($scope, $http, $location) {
    
    var origList = new Array();
    
    $scope.searchKeyword = '';
    $scope.searchTitle = '';
    $scope.results = new Array();

    //test data only
    for (var ctr = 1; ctr <= 10; ctr++) {
        origList[ctr - 1] = { ID: ctr, Title: 'API Name ' + ctr, Description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum' };
    }

    $scope.keywordChanged = function ()
    {
        if ($scope.searchKeyword.length > 0) {

            var result = new Array();
            var resultCount = 0;
            angular.forEach(origList, function (key, value) {
                if (key.Title.toLowerCase().indexOf($scope.searchKeyword.toLowerCase()) >= 0) {
                    result[resultCount] = key;
                    resultCount++;
                }
            }, result);

            $scope.searchTitle = 'Search for api keyword "' + $scope.searchKeyword + '"';
            $scope.results = result;
        }
        else {
            //$scope.searchTitle = 'API List';
            //$scope.results = origList;

            //go back to home
            $location.url('/');
            return;
        }
        
        $location.url('/search?q=' + $scope.searchKeyword);
    }

    //$scope.$watch("searchKeyword", function (newValue, oldValue) {
        
    //});
});
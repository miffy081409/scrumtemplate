var searchAppModule = window.searchApp;

searchAppModule.controller("searchViewModel", function ($scope, $http, $location, apiModel) {
    
    var origList = apiModel.getData();//get data from service
    
    $scope.searchKeyword = '';
    $scope.searchTitle = '';
    $scope.results = new Array();

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

            if (result.length > 0) {
                $scope.searchTitle = 'Search for api keyword "' + $scope.searchKeyword + '"';
            }
            else {
                $scope.searchTitle = 'No result found for api keyword "' + $scope.searchKeyword + '"';
            }
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
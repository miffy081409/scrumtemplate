var searchAppModule = window.searchApp;

searchAppModule.controller('searchViewModel', function ($rootScope, $scope, $location, apiModel) { 
    $scope.searchKeyword = '';
    $scope.searchTitle = '';
    $scope.results = null;
    $scope.keywordChanged = keywordTextChanged;

    initVM();

    //angular broadcasting(custom event resetKeywordPlease)
    $rootScope.$on('resetKeywordPlease', function () {
        $scope.searchKeyword = '';
    });

    function initVM() {
        $scope.searchKeyword = $location.search().q || '';//try to get keyword from query string
        if ($scope.searchKeyword != '') {
            keywordTextChanged();
        }
    }

    function keywordTextChanged()
    {
        if ($scope.searchKeyword.length > 0) {
            //start wait screen here
            apiModel.searchApi($scope.searchKeyword, function (data) {

                if (data.length > 0) {
                    $scope.searchTitle = 'Results for keyword "' + $scope.searchKeyword + '"';
                }
                else {
                    $scope.searchTitle = 'No result found for keyword "' + $scope.searchKeyword + '"';
                }
                $scope.results = data;
                //stop wait screen here


                //var result = new Array();
                //var resultCount = 0;
                //angular.forEach(origList, function (key, value) {
                //    if (key.Name.toLowerCase().indexOf($scope.searchKeyword.toLowerCase()) >= 0) {
                //        result[resultCount] = key;
                //        resultCount++;
                //    }
                //}, result);
            });
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

});
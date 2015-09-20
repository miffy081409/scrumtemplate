var searchAppModule = window.searchApp;

searchAppModule.controller('apiPageDocumentationViewModel', function ($rootScope, $scope, $location, apiModel) {
    
    $scope.pageHeading = 'Unable to load API documentation.';
    $scope.apiDocumentationModel = {};

    initVM();

    function initVM() {
        $rootScope.$broadcast('resetKeywordPlease', {});
        var id = $location.search().id || '';
        apiModel.getApi(id, function (data) {
            if (data.length > 0)
            {
                $scope.apiDocumentationModel = data[0];
                $scope.pageHeading = $scope.apiDocumentationModel.Name;
            }
        });
    }


});
var searchAppModule = window.searchApp;

searchAppModule.controller('apiPageDocumentationViewModel', function ($scope, $http) {
    
    $scope.pageHeading = '';

    initVM();



    function initVM() {
        $scope.pageHeading = 'Show Page Documentation here';
    }


});
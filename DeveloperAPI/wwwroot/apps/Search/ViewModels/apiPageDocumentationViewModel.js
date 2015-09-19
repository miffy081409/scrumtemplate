var searchAppModule = window.searchApp;

searchAppModule.controller('apiPageDocumentationViewModel', function ($rootScope, $scope, apiModel) {
    
    $scope.pageHeading = '';

    initVM();

    function initVM() {
        $rootScope.$broadcast('resetKeywordPlease', {});
        $scope.pageHeading = 'Show Page Documentation here';
    }


});
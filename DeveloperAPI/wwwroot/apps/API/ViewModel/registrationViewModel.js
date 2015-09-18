var apiApp = window.apiApp;

apiApp.controller('registrationViewModel', function ($rootScope, $scope, $http, $location) {

    $scope.pageHeading = '';

    initVM();

    function initVM() {
        if ($location.absUrl().indexOf('register') >= 0) {
            $scope.pageHeading = "Register your api here";
        }

        if ($location.absUrl().indexOf('update') >= 0) {
            $scope.pageHeading = "Update your api here";
        }
    }

});